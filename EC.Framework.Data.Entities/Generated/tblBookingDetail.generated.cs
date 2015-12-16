//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EC.Framework.Data.Entities
{
    using System;
    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    [Table("tblBookingDetail", Schema = "dbo")]
    public partial class tblBookingDetail 
    {        

        [DataMember]
        [Key, Column(Order = 0), ForeignKey("tblBooking")]
        public int BookingId { get; set; }
        [DataMember]
        [Key, Column(Order = 1), ForeignKey("tblCustomer")]
        public int CustomerId { get; set; }
        [DataMember]
        [Key, Column(Order = 2), ForeignKey("tblRoom")]
        public short RoomId { get; set; }
        [DataMember]
        [Key, Column(Order = 3)]
        public DateTime Date { get; set; }
        [DataMember]
        public bool Cancelled { get; set; }
        [DataMember]
        public int Occupants { get; set; }

        [DataMember]
        [ForeignKey("BookingId")]
        public virtual tblBooking tblBooking { get; set; }
        [DataMember]
        [ForeignKey("CustomerId")]
        public virtual tblCustomer tblCustomer { get; set; }
        [DataMember]
        [ForeignKey("RoomId")]
        public virtual tblRoom tblRoom { get; set; }

 
        public void SetValues(tblBookingDetail item)
        {
            this.BookingId = item.BookingId;
            this.CustomerId = item.CustomerId;
            this.RoomId = item.RoomId;
            this.Date = item.Date;
            this.Cancelled = item.Cancelled;
            this.Occupants = item.Occupants;

        }
    }
}