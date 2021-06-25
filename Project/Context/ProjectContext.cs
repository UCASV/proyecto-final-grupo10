using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project.Context
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<CitizenoxVaccination> CitizenoxVaccinations { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<EssentialInstitution> EssentialInstitutions { get; set; }
        public virtual DbSet<LoginRegister> LoginRegisters { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<SideEffect> SideEffects { get; set; }
        public virtual DbSet<TypeAppointment> TypeAppointments { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Project;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCitizen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_citizen");

                entity.Property(e => e.IdManager).HasColumnName("id_manager");

                entity.Property(e => e.IdTypeAppointment).HasColumnName("id_type_appointment");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place");

                entity.Property(e => e.ProcessDate)
                    .HasColumnType("datetime")
                    .HasColumnName("process_date");

                entity.Property(e => e.ReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("reservation_date");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCitizen)
                    .HasConstraintName("FK__Appointme__id_ci__3C69FB99");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("FK__Appointme__id_ma__3B75D760");

                entity.HasOne(d => d.IdTypeAppointmentNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdTypeAppointment)
                    .HasConstraintName("FK__Appointme__id_ty__3A81B327");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("Cabin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("adress");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__Citizen__C03671B828074866");

                entity.ToTable("Citizen");

                entity.Property(e => e.Dui)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DUI");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adress");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cname");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdEssentialInstitution).HasColumnName("id_essential_institution");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.HasOne(d => d.IdEssentialInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdEssentialInstitution)
                    .HasConstraintName("FK__Citizen__id_esse__3D5E1FD2");
            });

            modelBuilder.Entity<CitizenoxVaccination>(entity =>
            {
                entity.ToTable("CitizenoxVaccination");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("citizen_id");

                entity.Property(e => e.VaccinationId).HasColumnName("vaccination_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.CitizenoxVaccinations)
                    .HasForeignKey(d => d.CitizenId)
                    .HasConstraintName("FK__Citizenox__citiz__3F466844");

                entity.HasOne(d => d.Vaccination)
                    .WithMany(p => p.CitizenoxVaccinations)
                    .HasForeignKey(d => d.VaccinationId)
                    .HasConstraintName("FK__Citizenox__vacci__403A8C7D");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("Disease");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disease1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("disease");

                entity.Property(e => e.IdCitizen)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_citizen");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Diseases)
                    .HasForeignKey(d => d.IdCitizen)
                    .HasConstraintName("FK__Disease__id_citi__3E52440B");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("Employee_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TemployeeType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("temployee_type");
            });

            modelBuilder.Entity<EssentialInstitution>(entity =>
            {
                entity.ToTable("Essential_institution");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EssentialInstitution1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("essential_institution");
            });

            modelBuilder.Entity<LoginRegister>(entity =>
            {
                entity.ToTable("Login_Register");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CabinAdress)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("cabin_adress");

                entity.Property(e => e.CabinEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cabin_email");

                entity.Property(e => e.ManagerEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("manager_email");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("manager_name");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_date");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HomeAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("home_adress");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdEmployeeType).HasColumnName("id_employee_type");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("manager_name");

                entity.Property(e => e.ManagerUser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("manager_user");

                entity.Property(e => e.Mpassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mpassword");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.IdCabin)
                    .HasConstraintName("FK__Manager__id_cabi__398D8EEE");

                entity.HasOne(d => d.IdEmployeeTypeNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.IdEmployeeType)
                    .HasConstraintName("FK__Manager__id_empl__38996AB5");
            });

            modelBuilder.Entity<SideEffect>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Side_Effects");

                entity.Property(e => e.SideEffects)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Side_Effects");

                entity.Property(e => e.VaccinationId).HasColumnName("vaccination_id");

                entity.HasOne(d => d.Vaccination)
                    .WithMany()
                    .HasForeignKey(d => d.VaccinationId)
                    .HasConstraintName("FK__Side_Effe__vacci__412EB0B6");
            });

            modelBuilder.Entity<TypeAppointment>(entity =>
            {
                entity.ToTable("Type_Appointment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeAppointment1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_appointment");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("Vaccination");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EffectTime).HasColumnName("effect_time");

                entity.Property(e => e.VaccinationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("vaccination_date");

                entity.Property(e => e.Vaccinator)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vaccinator");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
