using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZOO_API2.Models
{
    public partial class ZooContext : DbContext
    {
        public ZooContext()
        {
        }

        public ZooContext(DbContextOptions<ZooContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Am> Ams { get; set; } = null!;
        public virtual DbSet<AmView> AmViews { get; set; } = null!;
        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalView> AnimalViews { get; set; } = null!;
        public virtual DbSet<Aviary> Aviaries { get; set; } = null!;
        public virtual DbSet<Child> Children { get; set; } = null!;
        public virtual DbSet<DiseaseCard> DiseaseCards { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeConcat> EmployeeConcats { get; set; } = null!;
        public virtual DbSet<HistoryAnimal> HistoryAnimals { get; set; } = null!;
        public virtual DbSet<HistoryEmployee> HistoryEmployees { get; set; } = null!;
        public virtual DbSet<HoursWeek> HoursWeeks { get; set; } = null!;
        public virtual DbSet<MedicalBook> MedicalBooks { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<StatusAnimal> StatusAnimals { get; set; } = null!;
        public virtual DbSet<StatusEmployee> StatusEmployees { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<SwapStatus> SwapStatuses { get; set; } = null!;
        public virtual DbSet<TypeOfAnimal> TypeOfAnimals { get; set; } = null!;
        public virtual DbSet<TypeOfWork> TypeOfWorks { get; set; } = null!;
        public virtual DbSet<VaccinationCard> VaccinationCards { get; set; } = null!;
        public virtual DbSet<Zoo> Zoos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7NUBAMDH\\SQLEXPRESS;Initial Catalog=Zoo;Persist Security Info=True;User ID=sa;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Am>(entity =>
            {
                entity.HasKey(e => e.IdAm);

                entity.ToTable("AM");

                entity.Property(e => e.IdAm).HasColumnName("ID_AM");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");

                entity.Property(e => e.ComponentId).HasColumnName("Component_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.TypeOfWorkId).HasColumnName("Type_of_Work_ID");

               
            });

            modelBuilder.Entity<AmView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AM_View");

                entity.Property(e => e.ВидРаботы)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Вид работы");

                entity.Property(e => e.Животное)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.Компонент)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Соотрудник)
                    .HasMaxLength(54)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal);

                entity.ToTable("Animal");

                entity.Property(e => e.IdAnimal).HasColumnName("ID_Animal");

                entity.Property(e => e.AviaryId).HasColumnName("Aviary_ID");

                entity.Property(e => e.DiseaseId).HasColumnName("Disease_ID");

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NameAnimal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Animal");

                entity.Property(e => e.StatusAnimalId).HasColumnName("Status_Animal_ID");

                entity.Property(e => e.TypeOfAnimalId).HasColumnName("Type_of_Animal_ID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

              
            });

            modelBuilder.Entity<AnimalView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Animal_View");

                entity.Property(e => e.Вес).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Животное)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.НомерВольера).HasColumnName("Номер вольера");

                entity.Property(e => e.НомерКарточкиБолезни).HasColumnName("Номер карточки болезни");

                entity.Property(e => e.Рост).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Aviary>(entity =>
            {
                entity.HasKey(e => e.IdAviary);

                entity.ToTable("Aviary");

                entity.Property(e => e.IdAviary).HasColumnName("ID_Aviary");

                entity.Property(e => e.Parametrs).IsUnicode(false);

                entity.Property(e => e.Square).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasKey(e => e.IdChild);

                entity.ToTable("Child");

                entity.Property(e => e.IdChild).HasColumnName("ID_Child");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");

                entity.Property(e => e.ZooId).HasColumnName("Zoo_ID");

              
            });

            modelBuilder.Entity<DiseaseCard>(entity =>
            {
                entity.HasKey(e => e.IdDisease)
                    .HasName("PK_Disease");

                entity.ToTable("Disease_card");

                entity.Property(e => e.IdDisease).HasColumnName("ID_Disease");

                entity.Property(e => e.DateEndIllness)
                    .HasColumnType("date")
                    .HasColumnName("Date_End_Illness");

                entity.Property(e => e.DateStartIllness)
                    .HasColumnType("date")
                    .HasColumnName("Date_Start_Illness");

                entity.Property(e => e.Diseases)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberCardDiseases).HasColumnName("Number_Card_Diseases");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.ConcatId).HasColumnName("Concat_ID");

                entity.Property(e => e.Login)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalBookId).HasColumnName("Medical_Book_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportData)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Passport_Data");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.StatusEmployeeId).HasColumnName("Status_Employee_ID");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

               
            });

            modelBuilder.Entity<EmployeeConcat>(entity =>
            {
                entity.HasKey(e => e.IdConcat)
                    .HasName("PK_Concat");

                entity.ToTable("Employee_Concat");

                entity.Property(e => e.IdConcat).HasColumnName("ID_Concat");

                entity.Property(e => e.HoursId).HasColumnName("Hours_ID");

                entity.Property(e => e.Salary).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.TaskList)
                    .IsUnicode(false)
                    .HasColumnName("Task_List");

               
            });

            modelBuilder.Entity<HistoryAnimal>(entity =>
            {
                entity.HasKey(e => e.IdHa)
                    .HasName("PK_HA");

                entity.ToTable("History_Animal");

                entity.Property(e => e.IdHa).HasColumnName("ID_HA");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NameAnimal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Animal");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type");

                entity.Property(e => e.NumberCardDiseases).HasColumnName("Number_Card_Diseases");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<HistoryEmployee>(entity =>
            {
                entity.HasKey(e => e.IdHe)
                    .HasName("PK_HE");

                entity.ToTable("History_Employee");

                entity.Property(e => e.IdHe).HasColumnName("ID_HE");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Login)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassportData)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("Passport_Data");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Post)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HoursWeek>(entity =>
            {
                entity.HasKey(e => e.IdHours)
                    .HasName("PK_Hours");

                entity.ToTable("Hours_Week");

                entity.Property(e => e.IdHours).HasColumnName("ID_Hours");
            });

            modelBuilder.Entity<MedicalBook>(entity =>
            {
                entity.HasKey(e => e.IdMedicalBook);

                entity.ToTable("Medical_Book");

                entity.Property(e => e.IdMedicalBook).HasColumnName("ID_Medical_Book");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Result).IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost);

                entity.ToTable("Post");

                entity.Property(e => e.IdPost).HasColumnName("ID_Post");

                entity.Property(e => e.NamePost)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Post");
            });

            modelBuilder.Entity<StatusAnimal>(entity =>
            {
                entity.HasKey(e => e.IdStatusAnimal);

                entity.ToTable("Status_Animal");

                entity.Property(e => e.IdStatusAnimal).HasColumnName("ID_Status_Animal");

                entity.Property(e => e.StatusAnimal1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Animal");
            });

            modelBuilder.Entity<StatusEmployee>(entity =>
            {
                entity.HasKey(e => e.IdStatusEmployee);

                entity.ToTable("Status_Employee");

                entity.Property(e => e.IdStatusEmployee).HasColumnName("ID_Status_Employee");

                entity.Property(e => e.StatusEmployee1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Employee");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdComponent)
                    .HasName("PK_Component");

                entity.ToTable("Stock");

                entity.Property(e => e.IdComponent).HasColumnName("ID_Component");

                entity.Property(e => e.NameComponent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Component");

                entity.Property(e => e.Quality).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<SwapStatus>(entity =>
            {
                entity.HasKey(e => e.IdSs)
                    .HasName("PK_SS");

                entity.ToTable("Swap_Status");

                entity.Property(e => e.IdSs).HasColumnName("ID_SS");

                entity.Property(e => e.NameStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Status");
            });

            modelBuilder.Entity<TypeOfAnimal>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfAnimal);

                entity.ToTable("Type_of_Animal");

                entity.Property(e => e.IdTypeOfAnimal).HasColumnName("ID_Type_of_Animal");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type");
            });

            modelBuilder.Entity<TypeOfWork>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfWork);

                entity.ToTable("Type_of_Work");

                entity.Property(e => e.IdTypeOfWork).HasColumnName("ID_Type_of_Work");

                entity.Property(e => e.NameTypeOfWork)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type_of_Work");
            });

            modelBuilder.Entity<VaccinationCard>(entity =>
            {
                entity.HasKey(e => e.IdVaccination)
                    .HasName("PK_Vaccination");

                entity.ToTable("Vaccination_Card");

                entity.Property(e => e.IdVaccination).HasColumnName("ID_Vaccination");

                entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");

                entity.Property(e => e.DateTimeVaccination)
                    .HasColumnType("date")
                    .HasColumnName("DateTime_Vaccination");

                entity.Property(e => e.Drug)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberCardVaccination).HasColumnName("Number_Card_Vaccination");

                
            });

            modelBuilder.Entity<Zoo>(entity =>
            {
                entity.HasKey(e => e.IdZoo);

                entity.ToTable("Zoo");

                entity.Property(e => e.IdZoo).HasColumnName("ID_Zoo");

                entity.Property(e => e.Adress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateSwap)
                    .HasColumnType("date")
                    .HasColumnName("Date_Swap");

                entity.Property(e => e.NameZoo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Zoo");

                entity.Property(e => e.SsId).HasColumnName("SS_ID");

               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
