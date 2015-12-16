namespace EC.Framework.Data.Implementations
{
    using System.Data.Entity;
    using Data.Entities;
    
    public class DormitoryContext : BaseContext<DormitoryContext>
    {
        public DormitoryContext(string connectionString)
            : base(connectionString)
        {
        }
        
        public DbSet<tblAddress> tblAddresses { get; set; }
        public DbSet<tblAdvance> tblAdvances { get; set; }
        public DbSet<tblBooking> tblBookings { get; set; }
        public DbSet<tblBookingDetail> tblBookingDetails { get; set; }
        public DbSet<tblCart> tblCarts { get; set; }
        public DbSet<tblCartDetail> tblCartDetails { get; set; }
        public DbSet<tblCheckIn> tblCheckIns { get; set; }
        public DbSet<tblCheckOut> tblCheckOuts { get; set; }
        public DbSet<tblCity> tblCities { get; set; }
        public DbSet<tblCountry> tblCountries { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblDocumentType> tblDocumentTypes { get; set; }
        public DbSet<tblFloor> tblFloors { get; set; }
        public DbSet<tblMaintenance> tblMaintenances { get; set; }
        public DbSet<tblOrganization> tblOrganizations { get; set; }
        public DbSet<tblRoom> tblRooms { get; set; }
        public DbSet<tblRoomType> tblRoomTypes { get; set; }
        public DbSet<tblStaff> tblStaffs { get; set; }
        public DbSet<tblState> tblStates { get; set; }
        public DbSet<tblStatus> tblStatuses { get; set; }
    }   
}