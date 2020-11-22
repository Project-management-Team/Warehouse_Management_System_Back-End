using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Shared.Database.Entities;

namespace WarehouseManagementSystem.Shared.Database.Context
{
    public partial class WHManagmentSystemContext : DbContext
    {
        public WHManagmentSystemContext()
        {
        }

        public WHManagmentSystemContext(DbContextOptions<WHManagmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<StatusStrings> StatusStrings { get; set; }
        public virtual DbSet<TruckCells> TruckCells { get; set; }
        public virtual DbSet<Trucks> Trucks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Whcells> Whcells { get; set; }
        public virtual DbSet<Whlockers> Whlockers { get; set; }
        public virtual DbSet<Whzones> Whzones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=den1.mssql8.gear.host;Database=whmanagmentsys;User Id=whmanagmentsys;Password=Yp5HJ8~c8G8_;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Items__3214EC069A81A942")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<StatusStrings>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__StatusSt__3214EC06E4000EE3")
                    .IsUnique();

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<TruckCells>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__TruckCel__3214EC0626C7C55B")
                    .IsUnique();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TruckCells)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TruckCells_Items");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.TruckCells)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckCells_Trucks");
            });

            modelBuilder.Entity<Trucks>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Trucks__3214EC068BC71562")
                    .IsUnique();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Users__3214EC06936379BF")
                    .IsUnique();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Warehous__3214EC06BC2FCE01")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048);
            });

            modelBuilder.Entity<Whcells>(entity =>
            {
                entity.ToTable("WHCells");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__WHCells__3214EC06BD9DBA38")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.WhlockerId).HasColumnName("WHLockerId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Whcells)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_WHCells_Items");

                entity.HasOne(d => d.Whlocker)
                    .WithMany(p => p.Whcells)
                    .HasForeignKey(d => d.WhlockerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WHCells_WHLocker");
            });

            modelBuilder.Entity<Whlockers>(entity =>
            {
                entity.ToTable("WHLockers");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__WHLocker__3214EC06411B371C")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.WhzoneId).HasColumnName("WHZoneId");

                entity.HasOne(d => d.Whzone)
                    .WithMany(p => p.Whlockers)
                    .HasForeignKey(d => d.WhzoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WHLocker_WHZones");
            });

            modelBuilder.Entity<Whzones>(entity =>
            {
                entity.ToTable("WHZones");

                entity.HasIndex(e => e.Id)
                    .HasName("UQ__WHZones__3214EC068C557E36")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.Whid).HasColumnName("WHId");

                entity.HasOne(d => d.Wh)
                    .WithMany(p => p.Whzones)
                    .HasForeignKey(d => d.Whid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WHZones_Warehouse");
            });
        }
    }
}
