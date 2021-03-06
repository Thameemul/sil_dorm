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
    [Table("tblCheckOut", Schema = "dbo")]
    public partial class tblCheckOut 
    {        

        [DataMember]
        [Key, Column(Order = 0)]
        public int BookingId { get; set; }
        [DataMember]
        [Key, Column(Order = 1)]
        public short RoomId { get; set; }
        [DataMember]
        [Key, Column(Order = 2)]
        public int CustomerId { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public decimal Rent { get; set; }
        [DataMember]
        public decimal? Food { get; set; }
        [DataMember]
        public decimal? Advance { get; set; }
        [DataMember]
        public decimal Total { get; set; }


 
        public void SetValues(tblCheckOut item)
        {
            this.BookingId = item.BookingId;
            this.RoomId = item.RoomId;
            this.CustomerId = item.CustomerId;
            this.FromDate = item.FromDate;
            this.ToDate = item.ToDate;
            this.Rent = item.Rent;
            this.Food = item.Food;
            this.Advance = item.Advance;
            this.Total = item.Total;

        }
    }
}