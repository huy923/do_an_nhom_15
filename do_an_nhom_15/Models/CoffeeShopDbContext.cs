using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace do_an_nhom_15.Models;

public partial class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext()
    {
    }

    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackReply> FeedbackReplies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__AdminUse__719FE488D6B34957");

            entity.HasIndex(e => e.Username, "UQ__AdminUse__536C85E41931B961").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__attendan__20D6A9687BE3544F");

            entity.ToTable("attendance");

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.CheckOut).HasColumnName("check_out");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__attendanc__emplo__5070F446");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B7516B1D99");

            entity.ToTable("Cart");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__product_id__440B1D61");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA82DD5278E");

            entity.ToTable("employees", tb => tb.HasTrigger("trg_InsertEmployeeID"));

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");

            entity.HasMany(d => d.Roles).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employee___role___4D94879B"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employee___emplo__4CA06362"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "RoleId").HasName("PK__employee__124E9DF4084F0F8D");
                        j.ToTable("employee_roles");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD62F4290D6");

            entity.ToTable("Feedback");

            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.FeedbackDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("feedback_date");
            entity.Property(e => e.IsAnswered)
                .HasDefaultValue(false)
                .HasColumnName("is_answered");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__produc__3C69FB99");
        });

        modelBuilder.Entity<FeedbackReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__Feedback__C25E4609983F1779");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.RepliedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("replied_by");
            entity.Property(e => e.ReplyContent)
                .HasColumnType("text")
                .HasColumnName("reply_content");
            entity.Property(e => e.ReplyDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("reply_date");

            entity.HasOne(d => d.Feedback).WithMany(p => p.FeedbackReplies)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeedbackR__feedb__403A8C7D");
        });


        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD23C46355");

            entity.ToTable(tb => tb.HasTrigger("trg_InsertProductID"));

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CCDA94EEBD");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__salaries__A3C71C5183749A59");

            entity.ToTable("salaries");

            entity.Property(e => e.SalaryId).HasColumnName("salary_id");
            entity.Property(e => e.BaseSalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("base_salary");
            entity.Property(e => e.Bonus)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("bonus");
            entity.Property(e => e.Deductions)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deductions");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.TotalSalary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_salary");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__salaries__employ__534D60F1");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__sales__E1EB00B2EBA0780F");

            entity.ToTable("sales");

            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__sales__employee___59063A47");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__shifts__7B26722013A58C66");

            entity.ToTable("shifts");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.ShiftDate).HasColumnName("shift_date");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Employee).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__shifts__employee__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
