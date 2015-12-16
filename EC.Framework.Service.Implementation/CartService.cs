namespace EC.Framework.Service.Implementations
{
  using System.Collections.Generic;
  using System.Linq;

  using AutoMapper.QueryableExtensions;
  using EC.Framework.Common.Entities;
  using EC.Framework.Data.Contracts.UnitOfWorks;
  using EC.Framework.Data.Entities;
  using EC.Framework.Service.Contracts;
  using EC.Framework.Service.Entities;
  using System;
  public class CartService : ICartService
  {
    private readonly IDormitoryUnitOfWork unitOfWork;
    public CartService(IDormitoryUnitOfWork unitOfWork)
    {
      this.unitOfWork = unitOfWork;
    }
    public IEnumerable<CartItem> GetCartDetails(long CartID)
    {
      return this.unitOfWork
        .Repository<tblCartDetail>()
        .Query(x => x.CartId == CartID)
        .Select(x => new CartItem
        {
          CartDetailID = x.CartDetailId,
          RoomNo = x.tblRoom.RoomNo,
          Date = x.Date,
          RoomRent = x.tblRoom.tblRoomType.Rent,
          Food = x.tblRoom.tblRoomType.Food,
          Occupancy = x.Occupants          //,
          //RemainingCapacity = this.unitOfWork.Repository<tblBookingDetail>().Query(y => y.Date == x.Date && x.RoomId == y.RoomId).Select(z => z.Occupants).Sum()
        }).ToList();
    }

    public Response SaveCart(long id, Int16 roomid, Dictionary<DateTime, int> dates)
    {
      var response = new Response();
      unitOfWork.BeginTransaction();

      var cart = unitOfWork.Repository<tblCart>().Find(id);//id

      if (cart == null)
      {
        cart = new tblCart();
        cart.CreatedDate = DateTime.Now;
        cart.CreatedBy = 1;
        unitOfWork.Repository<tblCart>().Add(cart);
        unitOfWork.SaveChanges();
      }
      id = cart.CartId;
      Dictionary<long, DateTime> existingDates = this.unitOfWork.Repository<tblCartDetail>().Query(x => x.CartId == id && x.RoomId == roomid)
        .Select()
        .ToDictionary(y => y.CartDetailId, y => y.Date);

      foreach (var item in existingDates)
      {
        if (!dates.Keys.Contains(item.Value))
        {
          this.unitOfWork.Repository<tblCartDetail>().Delete(item.Key);
          this.unitOfWork.SaveChanges();
        }
        else
        {
          dates.Remove(item.Value);
        }
      }

      foreach (var item in dates)
      {
        unitOfWork.Repository<tblCartDetail>().Add(new tblCartDetail() { CartId = id, Date = item.Key, Occupants = item.Value, RoomId = roomid });
        unitOfWork.SaveChanges();
      }

      if (!unitOfWork.Commit().IsOk)
      {
        unitOfWork.Rollback();
        response.Error("Save Failed");
      }
      else
      {
        response.Success(id.ToString());
        response.ReturnValue = new { CartId = id.ToString(), TotalDates = unitOfWork.Repository<tblCartDetail>().Query(x => x.CartId == id).Select().Count() };
      }

      return response;
    }

    public Response ConfirmCart(long id, String ContactName, String ContactEmail, String ContactNo)
    {
      var response = new Response();
      this.unitOfWork.BeginTransaction();

      var booking = new tblBooking()
      {
        CustomerId = 1,
        BookedOn = DateTime.Now,
        ContactName = ContactName,
        ContactEmail = ContactEmail,
        ContactNo = ContactNo
      };
      if (booking != null)
      {
        this.unitOfWork.Repository<tblBooking>().Add(booking);
        this.unitOfWork.SaveChanges();

        List<tblCartDetail> lst = this.unitOfWork.Repository<tblCartDetail>().Query(x => x.CartId == id).Select().ToList();

        if (lst != null)
        {
          foreach (var item in lst)
          {
            this.unitOfWork.Repository<tblBookingDetail>().Add(new tblBookingDetail()
            {
              BookingId = booking.BookingId,
              CustomerId = booking.CustomerId,
              RoomId = item.RoomId,
              Date = item.Date,
              Cancelled = false,
              Occupants = item.Occupants
            });
            this.unitOfWork.SaveChanges();

          }
        }
      }

      if (!unitOfWork.Commit().IsOk)
      {
        unitOfWork.Rollback();
        response.Error("Save Failed");
      }
      else
      {
        response.Success("Success");
        response.ReturnValue = booking.BookingId;
        this.RemoveCart(id);
      }

      return response;
    }

    public Response RemoveCartDetailByID(long CartDetailId)
    {
      var response = new Response();

      var CartDetail = this.unitOfWork.Repository<tblCartDetail>().Find(CartDetailId);
      if (CartDetail != null)
      {
        this.unitOfWork.Repository<tblCartDetail>().Delete(CartDetail);
      }
      if (!this.unitOfWork.SaveChanges().IsOk)
      {
        response.Error("Failed");
      }
      else
      {
        response.Success("Failed");
      }
      return response;
    }

    private Boolean RemoveCart(long id)
    {
      bool res = false;
      this.unitOfWork.BeginTransaction();

      this.unitOfWork.Repository<tblCartDetail>().DeleteItems(this.unitOfWork.Repository<tblCartDetail>().Query(x => x.CartId == id).Select());
      this.unitOfWork.SaveChanges();

      this.unitOfWork.Repository<tblCart>().DeleteItems(this.unitOfWork.Repository<tblCart>().Query(x => x.CartId == id).Select());
      this.unitOfWork.SaveChanges();

      if (!unitOfWork.Commit().IsOk)
      {
        unitOfWork.Rollback();
        res = false;
      }
      else
      {
        res = true;
      }

      return res;
    }
  }
}
