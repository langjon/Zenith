using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalDatabaseFirst.Models
{
    public partial class finalAssigContext : DbContext
    {
        public finalAssigContext()
        {
        }

        public finalAssigContext(DbContextOptions<finalAssigContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeLogin> EmployeeLogin { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=finalAssig;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.CreditCardId)
                    .HasColumnName("CreditCardID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.CreditCardHolderName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardProvider)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardSecurityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CusId)
                    .HasColumnName("CusID")
                    .HasColumnType("numeric(9, 0)");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__CreditCar__CusID__276EDEB3");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("CusPK");

                entity.Property(e => e.CusId)
                    .HasColumnName("CusID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.CusAddress)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CusEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CusPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CusPostalCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("EmpPK");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.EmpAddress)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPostalCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeLogin>(entity =>
            {
                entity.Property(e => e.EmployeeLoginId)
                    .HasColumnName("EmployeeLoginID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeLogin)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeL__EmpID__2D27B809");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("OrdersPK");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("PaymentID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.ProdId)
                    .HasColumnName("ProdID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.StatusUpdate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Orders__EmpID__37A5467C");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Orders__PaymentI__35BCFE0A");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__Orders__ProdID__36B12243");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .HasColumnName("PaymentID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.CreditCardId)
                    .HasColumnName("CreditCardID")
                    .HasColumnType("numeric(9, 0)");

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK__Payment__CreditC__2A4B4B5E");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("ProdPK");

                entity.Property(e => e.ProdId)
                    .HasColumnName("ProdID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.ProdMaterial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdQuantity).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProdSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductBriefDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.Property(e => e.ProductionId)
                    .HasColumnName("ProductionID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.ProdId)
                    .HasColumnName("ProdID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.StatusUpdate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Productio__EmpID__31EC6D26");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__Productio__ProdI__32E0915F");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.Property(e => e.ShippingId)
                    .HasColumnName("ShippingID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasColumnType("numeric(9, 0)");

                entity.Property(e => e.TrackingCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipping)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Shipping__OrderI__3A81B327");
            });
        }
    }
}
