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
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Serializable]
    [Table("tblOrganization", Schema = "dbo")]
    public partial class tblOrganization 
    {        
        public tblOrganization()
        {
            this.tblCustomers = new List<tblCustomer>();
        }


        [DataMember]
        [Key, Column(Order = 0)]
        public short OrganizationId { get; set; }
        [DataMember]
        public string OrganizationName { get; set; }

        [DataMember]
        [InverseProperty("tblOrganization")]
        public virtual ICollection<tblCustomer> tblCustomers { get; set; }

 
        public void SetValues(tblOrganization item)
        {
            this.OrganizationId = item.OrganizationId;
            this.OrganizationName = item.OrganizationName;

        }
    }
}