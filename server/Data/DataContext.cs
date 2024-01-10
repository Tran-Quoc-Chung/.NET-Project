using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<SystemStatus> SystemStatus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserToRole> UserToRoles { get; set; }
        public DbSet<RoleToPermission> RoleToPermissions { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DialShape> DialShapes { get; set; }
        public DbSet<DialSize> DialSizes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<StrapMaterial> StrapMaterials { get; set; }
        public DbSet<VoucherStatus> VoucherStatus { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<WaterResistance> WaterResistances { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StatusInvoice> StatusInvoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryDetail> inventoryDetails { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Partner> Partners { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemStatus>().ToTable("SystemStatus").HasKey(key=>key.StatusID);
            modelBuilder.Entity<User>().ToTable("User").HasKey(key=>key.UserID);
            modelBuilder.Entity<Role>().ToTable("Role").HasKey(key=>key.RoleID);
            modelBuilder.Entity<Permission>().ToTable("Permission").HasKey(key=>key.PermissionID);
            modelBuilder.Entity<UserToRole>().ToTable("UserToRole").HasKey(table=>new{
                table.RoleID,table.UserID
            });
            modelBuilder.Entity<RoleToPermission>().ToTable("RoleToPermission").HasKey(table=>new{
                table.RoleID, table.PermissionID
            });
            modelBuilder.Entity<Customer>().ToTable("Customer").HasKey(key=>key.CustomerID);
            modelBuilder.Entity<Brand>().ToTable("Brand").HasKey(key=>key.BrandID);
            modelBuilder.Entity<DialShape>().ToTable("DialShape").HasKey(key=>key.DialShapeID);     
            modelBuilder.Entity<DialSize>().ToTable("DialSize").HasKey(key=>key.DialSizeID);
            modelBuilder.Entity<Tag>().ToTable("Tag").HasKey(key=>key.TagID);
            modelBuilder.Entity<WaterResistance>().ToTable("WaterResistance").HasKey(key=>key.WaterResistanceID);
            modelBuilder.Entity<StrapMaterial>().ToTable("StrapMaterial").HasKey(key=>key.StrapMaterialID);
            modelBuilder.Entity<Gender>().ToTable("Gender").HasKey(key=>key.GenderID);
            modelBuilder.Entity<Product>().ToTable("Product").HasKey(key=>key.ProductID);
            modelBuilder.Entity<Cart>().ToTable("Cart").HasKey(key=>key.CartID);
            modelBuilder.Entity<CartDetail>().ToTable("CartDetail").HasKey(key=>key.CartDetailID);
            modelBuilder.Entity<VoucherStatus>().ToTable("VoucherStatus").HasKey(key=>key.VoucherStatusID);
            modelBuilder.Entity<Voucher>().ToTable("Voucher").HasKey(key=>key.VoucherCode);
            modelBuilder.Entity<StatusInvoice>().ToTable("StatusInvoice").HasKey(key=>key.StatusInvoiceID);
            modelBuilder.Entity<Invoice>().ToTable("Invoice").HasKey(key=>key.InvoiceID);
            modelBuilder.Entity<InvoiceDetail>().ToTable("InvoiceDetail").HasKey(key=>key.InvoiceDetailID);
            modelBuilder.Entity<Comment>().ToTable("Comment").HasKey(key=>key.CommentID);
            modelBuilder.Entity<Inventory>().ToTable("Inventory").HasKey(key => key.InventoryID);
            modelBuilder.Entity<InventoryDetail>().ToTable("InventoryDetail").HasKey(key => key.ID);
            modelBuilder.Entity<Images>().ToTable("Images").HasKey(key => key.ImagesID);
            modelBuilder.Entity<Partner>().ToTable("Partner").HasKey(key => key.PartnerId);
            
        }
    }
}