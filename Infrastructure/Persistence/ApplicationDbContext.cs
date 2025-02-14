using Microsoft.EntityFrameworkCore;
using PruebaBackend.Core.Domain.Entities;

namespace PruebaBackend.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Agency> agencies { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<PreferredHotel> preferredhotels { get; set; }
        public DbSet<Traveler> travelers { get; set; }
        public DbSet<EmergencyContact> emergencycontacts { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<ReservationRoom> ReservationRooms { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>(agency =>
            {
                agency.ToTable("agencies");
                agency.HasKey(a => a.agencyId);
                agency.Property(a => a.agencyId).HasColumnName("agencyid").ValueGeneratedOnAdd();
                agency.Property(a => a.name).HasColumnName("name").IsRequired().HasMaxLength(100);
                agency.Property(a => a.address).HasColumnName("address").HasMaxLength(255);
                agency.Property(a => a.email).HasColumnName("email").HasMaxLength(100);
                agency.HasIndex(a => a.email).IsUnique();
                agency.Property(a => a.phone).HasColumnName("phone").HasMaxLength(20);
                agency.Property(a => a.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                agency.Property(a => a.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Hotel>(hotel =>
            {
                hotel.ToTable("hotels");
                hotel.HasKey(h => h.hotelId);
                hotel.Property(h => h.hotelId).HasColumnName("hotelid").ValueGeneratedOnAdd();
                hotel.Property(h => h.identificationNumber).HasColumnName("identificationnumber").IsRequired().HasMaxLength(50);
                hotel.HasIndex(h => h.identificationNumber).IsUnique();
                hotel.Property(h => h.name).HasColumnName("name").IsRequired().HasMaxLength(100);
                hotel.Property(h => h.location).HasColumnName("location").IsRequired().HasMaxLength(100);
                hotel.Property(h => h.address).HasColumnName("address").HasMaxLength(255);
                hotel.Property(h => h.status).HasColumnName("status").HasDefaultValue("Enabled").HasMaxLength(10);
                hotel.Property(h => h.capacityPersons).HasColumnName("capacitypersons").IsRequired();
                hotel.Property(h => h.description).HasColumnName("description").HasColumnType("TEXT");
                hotel.Property(h => h.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                hotel.Property(h => h.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Room>(room =>
            {
                room.ToTable("rooms");
                room.HasKey(r => r.roomId);
                room.Property(r => r.roomId).HasColumnName("roomid").ValueGeneratedOnAdd();
                room.Property(r => r.hotelId).HasColumnName("hotelid").IsRequired();
                room.Property(r => r.roomNumber).HasColumnName("roomnumber").IsRequired().HasMaxLength(10);
                room.Property(r => r.roomType).HasColumnName("roomtype").HasMaxLength(50);
                room.Property(r => r.capacityPersons).HasColumnName("capacitypersons");
                room.Property(r => r.baseCost).HasColumnName("basecost").HasColumnType("decimal(10,2)");
                room.Property(r => r.taxesPercentage).HasColumnName("taxespercentage").HasColumnType("decimal(5,2)");
                room.Property(r => r.price).HasColumnName("price").HasColumnType("decimal(10,2)");
                room.Property(r => r.location).HasColumnName("location").HasMaxLength(100);
                room.Property(r => r.status).HasColumnName("status").HasDefaultValue("Available").HasMaxLength(10);
                room.Property(r => r.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                room.Property(r => r.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
                room.HasIndex(r => new { r.hotelId, r.roomNumber }).IsUnique();
                room.HasOne<Hotel>().WithMany().HasForeignKey(r => r.hotelId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PreferredHotel>(preferredHotel =>
            {
                preferredHotel.ToTable("preferredhotels");
                preferredHotel.HasKey(ph => new { ph.agencyId, ph.hotelId });
                preferredHotel.Property(ph => ph.agencyId).HasColumnName("agencyid").IsRequired();
                preferredHotel.Property(ph => ph.hotelId).HasColumnName("hotelid").IsRequired();
                preferredHotel.Property(ph => ph.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                preferredHotel.Property(ph => ph.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
                preferredHotel.HasOne<Agency>().WithMany().HasForeignKey(ph => ph.agencyId).OnDelete(DeleteBehavior.Cascade);
                preferredHotel.HasOne<Hotel>().WithMany().HasForeignKey(ph => ph.hotelId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Traveler>(traveler =>
            {
                traveler.ToTable("travelers");
                traveler.HasKey(t => t.travelerId);
                traveler.Property(t => t.travelerId).HasColumnName("travelerid").ValueGeneratedOnAdd();
                traveler.Property(t => t.firstName).HasColumnName("firstname").IsRequired().HasMaxLength(100);
                traveler.Property(t => t.lastName).HasColumnName("lastname").IsRequired().HasMaxLength(100);
                traveler.Property(t => t.dateOfBirth).HasColumnName("dateofbirth");
                traveler.Property(t => t.gender).HasColumnName("gender").HasMaxLength(10);
                traveler.Property(t => t.documentType).HasColumnName("documenttype").HasMaxLength(50);
                traveler.Property(t => t.documentNumber).HasColumnName("documentnumber").IsRequired().HasMaxLength(50);
                traveler.HasIndex(t => t.documentNumber).IsUnique();
                traveler.Property(t => t.email).HasColumnName("email").HasMaxLength(100);
                traveler.Property(t => t.phoneNumber).HasColumnName("phonenumber").HasMaxLength(20);
                traveler.Property(t => t.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                traveler.Property(t => t.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<EmergencyContact>(contact =>
            {
                contact.ToTable("emergencycontacts");
                contact.HasKey(e => e.emergencyContactId);
                contact.Property(e => e.emergencyContactId).HasColumnName("emergencycontactid").ValueGeneratedOnAdd();
                contact.Property(e => e.firstName).HasColumnName("firstname").IsRequired().HasMaxLength(100);
                contact.Property(e => e.lastName).HasColumnName("lastname").IsRequired().HasMaxLength(100);
                contact.Property(e => e.phoneNumber).HasColumnName("phonenumber").IsRequired().HasMaxLength(20);
                contact.Property(e => e.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                contact.Property(e => e.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Reservation>(reservation =>
            {
                reservation.ToTable("reservations");
                reservation.HasKey(r => r.reservationId);
                reservation.Property(r => r.reservationId).HasColumnName("reservationid").ValueGeneratedOnAdd();
                reservation.Property(r => r.travelerId).HasColumnName("travelerid").IsRequired();
                reservation.Property(r => r.hotelId).HasColumnName("hotelid").IsRequired();
                reservation.Property(r => r.checkIn).HasColumnName("check_in").IsRequired();
                reservation.Property(r => r.checkOut).HasColumnName("check_out").IsRequired();
                reservation.Property(r => r.status).HasColumnName("status").HasMaxLength(20).HasDefaultValue("Pending");
                reservation.Property(r => r.emergencyContactId).HasColumnName("emergencycontactid");
                reservation.Property(r => r.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                reservation.Property(r => r.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
                reservation.HasOne<Traveler>().WithMany().HasForeignKey(r => r.travelerId).OnDelete(DeleteBehavior.Cascade);
                reservation.HasOne<Hotel>().WithMany().HasForeignKey(r => r.hotelId).OnDelete(DeleteBehavior.Cascade);
                reservation.HasOne<EmergencyContact>().WithMany().HasForeignKey(r => r.emergencyContactId).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Guest>(guest =>
            {
                guest.ToTable("guests");
                guest.HasKey(g => g.guestId);
                guest.Property(g => g.guestId).HasColumnName("guestid").ValueGeneratedOnAdd();
                guest.Property(g => g.reservationId).HasColumnName("reservationid").IsRequired();
                guest.Property(g => g.firstName).HasColumnName("firstname").IsRequired().HasMaxLength(100);
                guest.Property(g => g.lastName).HasColumnName("lastname").IsRequired().HasMaxLength(100);
                guest.Property(g => g.email).HasColumnName("email").HasMaxLength(100);
                guest.Property(g => g.phone).HasColumnName("phone").HasMaxLength(20);
                guest.Property(g => g.dateOfBirth).HasColumnName("dateofbirth");
                guest.Property(g => g.nationality).HasColumnName("nationality").HasMaxLength(50);
                guest.Property(g => g.gender).HasColumnName("gender").HasMaxLength(10);
                guest.Property(r => r.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                guest.Property(r => r.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
                guest.HasOne<Reservation>().WithMany().HasForeignKey(g => g.reservationId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReservationRoom>(reservationRoom =>
            {
                reservationRoom.ToTable("reservationrooms");
                reservationRoom.HasKey(rr => new { rr.reservationId, rr.roomId });
                reservationRoom.Property(rr => rr.reservationId).HasColumnName("reservationid").IsRequired();
                reservationRoom.Property(rr => rr.roomId).HasColumnName("roomid").IsRequired();
                reservationRoom.Property(r => r.createdAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
                reservationRoom.Property(r => r.updatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
                reservationRoom.HasOne<Reservation>().WithMany().HasForeignKey(rr => rr.reservationId).OnDelete(DeleteBehavior.Cascade);
                reservationRoom.HasOne<Room>().WithMany().HasForeignKey(rr => rr.roomId).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}