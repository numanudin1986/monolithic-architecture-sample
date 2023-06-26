using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyApp.DataAccess.DataBaseContext
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AgentRecord> AgentRecords { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TblLogging> TblLoggings { get; set; }
        public virtual DbSet<TblRawDatum> TblRawData { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TestDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentCode)
                    .HasName("PK__AGENTS__843A8BBACE1BC3AF");

                entity.ToTable("AGENTS");

                entity.Property(e => e.AgentCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.AgentName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_NAME")
                    .IsFixedLength(true);

                entity.Property(e => e.Commission)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("COMMISSION");

                entity.Property(e => e.Country)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NO")
                    .IsFixedLength(true);

                entity.Property(e => e.WorkingArea)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("WORKING_AREA")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<AgentRecord>(entity =>
            {
                entity.ToTable("AgentRecord");

                entity.Property(e => e.AgentName).IsUnicode(false);

                entity.Property(e => e.Commission).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.PhoneNo).IsUnicode(false);

                entity.Property(e => e.WorkingArea).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustCode)
                    .HasName("PK__CUSTOMER__8393C4A193DD0A52");

                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CUST_CODE");

                entity.Property(e => e.AgentCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.CustCity)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUST_CITY")
                    .IsFixedLength(true);

                entity.Property(e => e.CustCountry)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUST_COUNTRY");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.Grade)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("GRADE");

                entity.Property(e => e.OpeningAmt)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("OPENING_AMT");

                entity.Property(e => e.OutstandingAmt)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("OUTSTANDING_AMT");

                entity.Property(e => e.PaymentAmt)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("PAYMENT_AMT");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NO");

                entity.Property(e => e.ReceiveAmt)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("RECEIVE_AMT");

                entity.Property(e => e.WorkingArea)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("WORKING_AREA");

                entity.HasOne(d => d.AgentCodeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AgentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CUSTOMER__AGENT___267ABA7A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdNum)
                    .HasName("PK__ORDERS__27AB607C869BFE9E");

                entity.ToTable("ORDERS");

                entity.Property(e => e.OrdNum)
                    .HasColumnType("decimal(6, 0)")
                    .HasColumnName("ORD_NUM");

                entity.Property(e => e.AdvanceAmount)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("ADVANCE_AMOUNT");

                entity.Property(e => e.AgentCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AGENT_CODE")
                    .IsFixedLength(true);

                entity.Property(e => e.CustCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CUST_CODE");

                entity.Property(e => e.OrdAmount)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("ORD_AMOUNT");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("date")
                    .HasColumnName("ORD_DATE");

                entity.Property(e => e.OrdDescription)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ORD_DESCRIPTION");

                entity.HasOne(d => d.AgentCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AgentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS__AGENT_CO__2A4B4B5E");

                entity.HasOne(d => d.CustCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS__CUST_COD__29572725");
            });

            modelBuilder.Entity<TblLogging>(entity =>
            {
                entity.ToTable("TblLogging");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DebugMessage).IsUnicode(false);

                entity.Property(e => e.ExceptionMessage).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.InnerExceptionMessage).IsUnicode(false);

                entity.Property(e => e.LineNumber).IsUnicode(false);

                entity.Property(e => e.MehtodName).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<TblRawDatum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("TblUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
