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

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CommentBlog> CommentBlogs { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackReply> FeedbackReplies { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=DESKTOP-B0D0J2Q;initial catalog=CoffeeShopDB;integrated security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__AdminUse__719FE488AEA4D148");

            entity.HasIndex(e => e.Username, "UQ__AdminUse__536C85E4A1113E40").IsUnique();

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
            entity.HasKey(e => e.AttendanceId).HasName("PK__attendan__20D6A968112AD20A");

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
                .HasConstraintName("FK__attendanc__emplo__6383C8BA");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(500);

            entity.HasOne(d => d.Admin).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.Adminid)
                .HasConstraintName("FK_Blog_AdminUsers");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7B755D70717");

            entity.ToTable("Cart");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__product_id__571DF1D5");
        });

        modelBuilder.Entity<CommentBlog>(entity =>
        {
            entity.ToTable("CommentBlog");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Blog).WithMany(p => p.CommentBlogs)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK_CommentBlog_Blog");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA8657F2DBD");

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
                        .HasConstraintName("FK__employee___role___60A75C0F"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__employee___emplo__5FB337D6"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "RoleId").HasName("PK__employee__124E9DF4F37E7D60");
                        j.ToTable("employee_roles");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("employee_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6C347C229");

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
                .HasConstraintName("FK__Feedback__produc__4F7CD00D");
        });

        modelBuilder.Entity<FeedbackReply>(entity =>
        {
            entity.HasKey(e => e.ReplyId).HasName("PK__Feedback__C25E4609DC345E82");

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
                .HasConstraintName("FK__FeedbackR__feedb__534D60F1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF50454249");

            entity.ToTable("Order");

            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(100)
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(15)
                .HasDefaultValueSql("(getdate())")
                .IsFixedLength()
                .HasColumnName("customerPhone");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C26FF4103");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__order__44FF419A");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__produ__45F365D3");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD60FFA471");

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
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CCEE0822C4");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__salaries__A3C71C51E881F720");

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
                .HasConstraintName("FK__salaries__employ__66603565");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__sales__E1EB00B2F3DA6164");

            entity.ToTable("sales");

            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Sales)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__sales__employee___6C190EBB");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__shifts__7B26722010448B99");

            entity.ToTable("shifts");

            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.ShiftDate).HasColumnName("shift_date");
            entity.Property(e => e.StartTime).HasColumnName("start_time");

            entity.HasOne(d => d.Employee).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__shifts__employee__693CA210");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbContac__3213E83F897573DC");

            entity.ToTable("tbContact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
