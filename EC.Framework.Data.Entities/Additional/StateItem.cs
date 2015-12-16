using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Framework.Data.Entities.Additional
{
	using System;

	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	[Table("tblState", Schema = "dbo")]
	public partial class tblState
	{

		[DataMember]
		[Key, Column(Order = 0)]
		public short StateId { get; set; }
		[DataMember]
		public string StateName { get; set; }
		[DataMember]
		public short CountryId { get; set; }
		public string CountryName { get; set; }
		[DataMember]
		[ForeignKey("CountryId")]
		public virtual tblCountry tblCountry { get; set; }


		public void SetValues(Entities.tblState item)
		{
			this.StateId = item.StateId;
			this.StateName = item.StateName;
			this.CountryId = item.CountryId;
			this.CountryName = item.tblCountry.CountryName;
		}
	}
}
