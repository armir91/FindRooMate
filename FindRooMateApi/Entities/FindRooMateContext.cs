using Microsoft.EntityFrameworkCore;

namespace FindRooMateApi.Entities
{
    public partial class FindRooMateContext : DbContext
    {
        public FindRooMateContext()
        {
        }

        public FindRooMateContext(DbContextOptions<FindRooMateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<Dormitory> Dormitories { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomStudent> RoomStudents { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AVJOL-DELL\\SQLEXPRESS01;Database=FindRooMate;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.ApplicationDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Announcement)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.AnnouncementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applications_Announcements");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applications_Students");
            });

            modelBuilder.Entity<Dormitory>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Dormitory)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.DormitoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Dormitories");
            });

            modelBuilder.Entity<RoomStudent>(entity =>
            {
                entity.ToTable("RoomStudent");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomStudents)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomStudent_Rooms");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RoomStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomStudent_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
