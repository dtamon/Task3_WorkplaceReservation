using Microsoft.EntityFrameworkCore;

namespace Task3_WorkplaceReservation.Domain
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentForWorkplace> EqupmentForWorkplace { get; set; }
    }
}
