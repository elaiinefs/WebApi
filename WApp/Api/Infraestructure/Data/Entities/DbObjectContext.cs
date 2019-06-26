using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WApp.Api.Infraestructure.Data.Queries;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class DbObjectContext : DbContext
    {
        public DbObjectContext()
        {
        }

        public DbObjectContext(DbContextOptions<DbObjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountQuestions> AccountQuestions { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressUsers> AddressUsers { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CompInfo> CompInfo { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CustInfo> CustInfo { get; set; }
        public virtual DbSet<CustMonthlyAct> CustMonthlyAct { get; set; }
        public virtual DbSet<Deposits> Deposits { get; set; }
        public virtual DbSet<DialyActSummary> DialyActSummary { get; set; }
        public virtual DbSet<DropDowns> DropDowns { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<InvoiceMsg> InvoiceMsg { get; set; }
        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersProducts> OrdersProducts { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<PopUpsMessage> PopUpsMessage { get; set; }
        public virtual DbSet<ProductCompany> ProductCompany { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleLog> ScheduleLog { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<UserCredentials> UserCredentials { get; set; }
        public virtual DbSet<UserFile> UserFile { get; set; }
        public virtual DbSet<UserSession> UserSession { get; set; }
        public virtual DbSet<UserSetups> UserSetups { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        //Queries
        public DbQuery<GetProductsView> GetProducts { get; set; }
        public DbQuery<GetOrdersView> GetOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AccountQuestions>(entity =>
            {
                entity.ToTable("accountQuestions");

                entity.Property(e => e.Answer1).HasMaxLength(50);

                entity.Property(e => e.Answer2).HasMaxLength(50);

                entity.Property(e => e.Answer3).HasMaxLength(50);

                entity.Property(e => e.Question1).HasMaxLength(50);

                entity.Property(e => e.Question2).HasMaxLength(50);

                entity.Property(e => e.Question3).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.AccountDesc).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.ApartmentNumber).HasMaxLength(15);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Province).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.StreetNumber).HasMaxLength(15);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(12);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CompInfo>(entity =>
            {
                entity.ToTable("Comp_info");

                entity.Property(e => e.Addr)
                    .HasColumnName("addr")
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20);

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.WebPage)
                    .HasColumnName("webPage")
                    .HasMaxLength(50);

                entity.Property(e => e.Zcode)
                    .HasColumnName("zcode")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Amount).HasMaxLength(20);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasMaxLength(50);

                entity.Property(e => e.Percent).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasMaxLength(50);
            });

            modelBuilder.Entity<CustInfo>(entity =>
            {
                entity.Property(e => e.CustTaxRate)
                    .HasColumnName("custTaxRate")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstPurchaseDate)
                    .HasColumnName("firstPurchaseDate")
                    .HasMaxLength(50);

                entity.Property(e => e.LastPaidDate)
                    .HasColumnName("lastPaidDate")
                    .HasMaxLength(20);

                entity.Property(e => e.LastPurchDate)
                    .HasColumnName("lastPurchDate")
                    .HasMaxLength(50);

                entity.Property(e => e.LastPurchaseDate)
                    .HasColumnName("lastPurchaseDate")
                    .HasMaxLength(50);

                entity.Property(e => e.PermanentDiscount)
                    .HasColumnName("permanentDiscount")
                    .HasMaxLength(50);

                entity.Property(e => e.TotalCostPurchase)
                    .HasColumnName("totalCostPurchase")
                    .HasMaxLength(50);

                entity.Property(e => e.TotalPurchase)
                    .HasColumnName("totalPurchase")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<CustMonthlyAct>(entity =>
            {
                entity.ToTable("Cust_Monthly_Act");

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.Credits).HasMaxLength(50);

                entity.Property(e => e.CustId).HasColumnName("custId");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasMaxLength(25);

                entity.Property(e => e.PaidAmnt)
                    .HasColumnName("paid_Amnt")
                    .HasMaxLength(50);

                entity.Property(e => e.Purch)
                    .HasColumnName("purch")
                    .HasMaxLength(50);

                entity.Property(e => e.Returns).HasMaxLength(50);

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Deposits>(entity =>
            {
                entity.ToTable("deposits");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50);

                entity.Property(e => e.Iamount)
                    .HasColumnName("iamount")
                    .HasMaxLength(50);

                entity.Property(e => e.InvNumber)
                    .HasColumnName("invNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeofPayment)
                    .HasColumnName("typeofPayment")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DialyActSummary>(entity =>
            {
                entity.ToTable("dialyActSummary");

                entity.Property(e => e.Ammount)
                    .HasColumnName("ammount")
                    .HasMaxLength(50);

                entity.Property(e => e.AmountSold)
                    .HasColumnName("amountSold")
                    .HasMaxLength(50);

                entity.Property(e => e.CostOfSales)
                    .HasColumnName("costOfSales")
                    .HasMaxLength(50);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemsSold)
                    .HasColumnName("itemsSold")
                    .HasMaxLength(50);

                entity.Property(e => e.LayawayAmount)
                    .HasColumnName("layawayAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.LayawayDeposit)
                    .HasColumnName("layawayDeposit")
                    .HasMaxLength(50);

                entity.Property(e => e.MonthSubT)
                    .HasColumnName("monthSubT")
                    .HasMaxLength(50);

                entity.Property(e => e.NumofSales)
                    .HasColumnName("numofSales")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderAmount)
                    .HasColumnName("orderAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.RefAmount)
                    .HasColumnName("refAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.Refunds)
                    .HasColumnName("refunds")
                    .HasMaxLength(50);

                entity.Property(e => e.Tax1Collect)
                    .HasColumnName("tax1Collect")
                    .HasMaxLength(50);

                entity.Property(e => e.Tax1Refund)
                    .HasColumnName("tax1Refund")
                    .HasMaxLength(50);

                entity.Property(e => e.Tax2Collect)
                    .HasColumnName("tax2Collect")
                    .HasMaxLength(50);

                entity.Property(e => e.Tax2Refund)
                    .HasColumnName("tax2Refund")
                    .HasMaxLength(50);

                entity.Property(e => e.YToDateSales)
                    .HasColumnName("yToDateSales")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DropDowns>(entity =>
            {
                entity.Property(e => e.DdCategory).HasMaxLength(50);

                entity.Property(e => e.DdDesc).HasMaxLength(50);

                entity.Property(e => e.DdInfo).HasMaxLength(50);

                entity.Property(e => e.DdName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.EmergencyContact)
                    .HasColumnName("emergencyContact")
                    .HasMaxLength(50);

                entity.Property(e => e.EmergencyPhone)
                    .HasColumnName("emergencyPhone")
                    .HasMaxLength(50);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hireDate")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(50);

                entity.Property(e => e.MaritalStatus).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.RateType).HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasMaxLength(50);

                entity.Property(e => e.TerminationDate)
                    .HasColumnName("terminationDate")
                    .HasMaxLength(50);

                entity.Property(e => e.UName)
                    .HasColumnName("uName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("errorLog");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.InnerException).HasColumnName("inner exception");

                entity.Property(e => e.StackTrace).HasColumnName("stackTrace");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasColumnName("target")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(50);

                entity.Property(e => e.HistoryDate)
                    .HasColumnName("historyDate")
                    .HasMaxLength(50);

                entity.Property(e => e.HistoryDesc).HasColumnName("historyDesc");

                entity.Property(e => e.HistoryTitle)
                    .HasColumnName("historyTitle")
                    .HasMaxLength(50);

                entity.Property(e => e.PcInfo)
                    .HasColumnName("pcInfo")
                    .HasMaxLength(50);

                entity.Property(e => e.UserAccount)
                    .HasColumnName("userAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.UserEmail)
                    .HasColumnName("userEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<InvoiceMsg>(entity =>
            {
                entity.ToTable("invoiceMsg");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoiceID")
                    .HasMaxLength(50);

                entity.Property(e => e.Line1)
                    .HasColumnName("line1")
                    .HasMaxLength(50);

                entity.Property(e => e.Line2)
                    .HasColumnName("line2")
                    .HasMaxLength(50);

                entity.Property(e => e.Line3)
                    .HasColumnName("line3")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Keys>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Parent).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(500);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(75);

                entity.Property(e => e.Name).HasMaxLength(75);

                entity.Property(e => e.Specifications).HasMaxLength(100);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasMaxLength(50);

                entity.Property(e => e.ParentId).HasMaxLength(50);

                entity.Property(e => e.ParentType).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.CreatedBy);

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.CustomerId).HasMaxLength(50);

                entity.Property(e => e.Deposit).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EmployeeId);

                entity.Property(e => e.Items).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy);

                entity.Property(e => e.ModifiedDate).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.OrderTotal).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasMaxLength(50);

                entity.Property(e => e.TaxAmount).HasMaxLength(50);

                entity.Property(e => e.TaxAmount2).HasMaxLength(50);

                entity.Property(e => e.TaxName).HasMaxLength(50);

                entity.Property(e => e.TaxName2).HasMaxLength(50);

                entity.Property(e => e.VendorId);
            });

            modelBuilder.Entity<OrdersProducts>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.Property(e => e.PlanDesc).HasMaxLength(50);

                entity.Property(e => e.PlanNumber).HasMaxLength(50);

                entity.Property(e => e.PlanPrice).HasMaxLength(50);

                entity.Property(e => e.PlanType).HasMaxLength(50);
            });

            modelBuilder.Entity<PopUpsMessage>(entity =>
            {
                entity.ToTable("popUpsMessage");

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCompany>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasMaxLength(50);

                entity.Property(e => e.ProductId).HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.BrandId).HasMaxLength(50);

                entity.Property(e => e.Collection).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Dimensions).HasMaxLength(50);

                entity.Property(e => e.Features).HasMaxLength(500);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.Sku).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VendorId).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.AssignedComp).HasMaxLength(50);

                entity.Property(e => e.AssignedGrp).HasMaxLength(50);

                entity.Property(e => e.Assignee).HasMaxLength(50);

                entity.Property(e => e.CatDetail).HasMaxLength(50);

                entity.Property(e => e.CategoryDescription).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.Desc).HasMaxLength(200);

                entity.Property(e => e.IncCategory).HasMaxLength(50);

                entity.Property(e => e.IncMonth).HasMaxLength(50);

                entity.Property(e => e.IncPriority).HasMaxLength(50);

                entity.Property(e => e.IncType).HasMaxLength(50);

                entity.Property(e => e.IncYear).HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportedBy).HasMaxLength(50);

                entity.Property(e => e.ResolutionBy)
                    .HasColumnName("Resolution_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ResolutionComment)
                    .HasColumnName("Resolution_Comment")
                    .HasMaxLength(200);

                entity.Property(e => e.ResolutionDate)
                    .HasColumnName("Resolution_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StatusReason)
                    .HasColumnName("Status_Reason")
                    .HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<ScheduleLog>(entity =>
            {
                entity.HasKey(e => e.InclogId)
                    .HasName("PK__Incident__ID");

                entity.Property(e => e.InclogId).HasColumnName("INCLogId");

                entity.Property(e => e.AssignedComp).HasMaxLength(50);

                entity.Property(e => e.AssignedGrp).HasMaxLength(50);

                entity.Property(e => e.Assignee).HasMaxLength(50);

                entity.Property(e => e.CatDetail).HasMaxLength(50);

                entity.Property(e => e.CategoryDescription).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.Desc).HasMaxLength(200);

                entity.Property(e => e.IncCategory).HasMaxLength(50);

                entity.Property(e => e.IncMonth).HasMaxLength(50);

                entity.Property(e => e.IncPriority).HasMaxLength(50);

                entity.Property(e => e.IncType).HasMaxLength(50);

                entity.Property(e => e.IncYear).HasMaxLength(50);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("Modified_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.ReportedBy).HasMaxLength(50);

                entity.Property(e => e.ResolutionBy)
                    .HasColumnName("Resolution_By")
                    .HasMaxLength(50);

                entity.Property(e => e.ResolutionComment)
                    .HasColumnName("Resolution_Comment")
                    .HasMaxLength(200);

                entity.Property(e => e.ResolutionDate)
                    .HasColumnName("Resolution_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StatusReason)
                    .HasColumnName("Status_Reason")
                    .HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(75);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DiscountDays)
                    .HasColumnName("discountDays")
                    .HasMaxLength(50);

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discountPercent")
                    .HasMaxLength(50);

                entity.Property(e => e.LastPaymenttoVendor).HasMaxLength(50);

                entity.Property(e => e.LastPurchasetoVendor).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).IsRowVersion();
            });

            modelBuilder.Entity<UserCredentials>(entity =>
            {
                entity.ToTable("userCredentials");

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .HasColumnName("userCode")
                    .HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.Property(e => e.PhotoId).HasColumnName("photoId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<UserSession>(entity =>
            {
                entity.ToTable("userSession");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(50);

                entity.Property(e => e.Browser)
                    .HasColumnName("browser")
                    .HasMaxLength(50);

                entity.Property(e => e.PcInfo)
                    .HasColumnName("pcInfo")
                    .HasMaxLength(50);

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionID")
                    .HasMaxLength(50);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasMaxLength(50);

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<UserSetups>(entity =>
            {
                entity.ToTable("userSetups");

                entity.Property(e => e.ReceiveEmails).HasColumnName("receiveEmails");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(150);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birthDate")
                    .HasMaxLength(150);

                entity.Property(e => e.Business)
                    .HasColumnName("business")
                    .HasMaxLength(150);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.EmergencyContact)
                    .HasColumnName("emergencyContact")
                    .HasMaxLength(50);

                entity.Property(e => e.EmergencyPhone)
                    .HasColumnName("emergencyPhone")
                    .HasMaxLength(50);

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasMaxLength(150);

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasMaxLength(200);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(150);

                entity.Property(e => e.MainGroup)
                    .HasColumnName("mainGroup")
                    .HasMaxLength(150);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);

                entity.Property(e => e.StripeId)
                    .HasColumnName("stripeId")
                    .HasMaxLength(300);

                entity.Property(e => e.UName)
                    .HasColumnName("uName")
                    .HasMaxLength(150);

                entity.Property(e => e.ZCode)
                    .HasColumnName("zCode")
                    .HasMaxLength(50);
            });
        }
    }
}
