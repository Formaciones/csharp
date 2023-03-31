using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Programando.CSharp.WebApplication1.Model;

public partial class ModelNorthwind : DbContext
{
    public ModelNorthwind()
    {
    }

    public ModelNorthwind(DbContextOptions<ModelNorthwind> options)
        : base(options)
    {
    }

    public virtual DbSet<Alphabetical_list_of_product> Alphabetical_list_of_products { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Category_Sales_for_1997> Category_Sales_for_1997s { get; set; }

    public virtual DbSet<Current_Product_List> Current_Product_Lists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }

    public virtual DbSet<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Order_Detail> Order_Details { get; set; }

    public virtual DbSet<Order_Details_Extended> Order_Details_Extendeds { get; set; }

    public virtual DbSet<Order_Subtotal> Order_Subtotals { get; set; }

    public virtual DbSet<Orders_Qry> Orders_Qries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Product_Sales_for_1997> Product_Sales_for_1997s { get; set; }

    public virtual DbSet<Products_Above_Average_Price> Products_Above_Average_Prices { get; set; }

    public virtual DbSet<Products_by_Category> Products_by_Categories { get; set; }

    public virtual DbSet<Quarterly_Order> Quarterly_Orders { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Sales_Totals_by_Amount> Sales_Totals_by_Amounts { get; set; }

    public virtual DbSet<Sales_by_Category> Sales_by_Categories { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters { get; set; }

    public virtual DbSet<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alphabetical_list_of_product>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Alphabetical list of products");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<Category_Sales_for_1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Category Sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.CategorySales).HasColumnType("money");
        });

        modelBuilder.Entity<Current_Product_List>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Current Product List");

            entity.Property(e => e.ProductID).ValueGeneratedOnAdd();
            entity.Property(e => e.ProductName).HasMaxLength(40);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);

            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerDemo",
                    r => r.HasOne<CustomerDemographic>().WithMany()
                        .HasForeignKey("CustomerTypeID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerID", "CustomerTypeID").IsClustered(false);
                        j.ToTable("CustomerCustomerDemo");
                        j.IndexerProperty<string>("CustomerID")
                            .HasMaxLength(5)
                            .IsFixedLength();
                        j.IndexerProperty<string>("CustomerTypeID")
                            .HasMaxLength(10)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<CustomerDemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeID).IsClustered(false);

            entity.Property(e => e.CustomerTypeID)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
        });

        modelBuilder.Entity<Customer_and_Suppliers_by_City>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Customer and Suppliers by City");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.Relationship)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PhotoPath).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTerritory",
                    r => r.HasOne<Territory>().WithMany()
                        .HasForeignKey("TerritoryID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeID", "TerritoryID").IsClustered(false);
                        j.ToTable("EmployeeTerritories");
                        j.IndexerProperty<string>("TerritoryID").HasMaxLength(20);
                    });
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Invoices");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CustomerName).HasMaxLength(40);
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.Salesperson).HasMaxLength(31);
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerID, "CustomerID");

            entity.HasIndex(e => e.CustomerID, "CustomersOrders");

            entity.HasIndex(e => e.EmployeeID, "EmployeeID");

            entity.HasIndex(e => e.EmployeeID, "EmployeesOrders");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "ShippedDate");

            entity.HasIndex(e => e.ShipVia, "ShippersOrders");

            entity.Property(e => e.CustomerID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerID)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeID)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<Order_Detail>(entity =>
        {
            entity.HasKey(e => new { e.OrderID, e.ProductID }).HasName("PK_Order_Details");

            entity.ToTable("Order Details");

            entity.HasIndex(e => e.OrderID, "OrderID");

            entity.HasIndex(e => e.OrderID, "OrdersOrder_Details");

            entity.HasIndex(e => e.ProductID, "ProductID");

            entity.HasIndex(e => e.ProductID, "ProductsOrder_Details");

            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Order).WithMany(p => p.Order_Details)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.Order_Details)
                .HasForeignKey(d => d.ProductID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<Order_Details_Extended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Details Extended");

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Order_Subtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Order Subtotals");

            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<Orders_Qry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Orders Qry");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerID)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryID, "CategoriesProducts");

            entity.HasIndex(e => e.CategoryID, "CategoryID");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.HasIndex(e => e.SupplierID, "SupplierID");

            entity.HasIndex(e => e.SupplierID, "SuppliersProducts");

            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryID)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierID)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<Product_Sales_for_1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Product Sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<Products_Above_Average_Price>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products Above Average Price");

            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Products_by_Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Products by Category");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        });

        modelBuilder.Entity<Quarterly_Order>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Quarterly Orders");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerID)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionID).IsClustered(false);

            entity.ToTable("Region");

            entity.Property(e => e.RegionID).ValueGeneratedNever();
            entity.Property(e => e.RegionDescription)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sales_Totals_by_Amount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales Totals by Amount");

            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.SaleAmount).HasColumnType("money");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Sales_by_Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Sales by Category");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("money");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<Summary_of_Sales_by_Quarter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Quarter");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<Summary_of_Sales_by_Year>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Summary of Sales by Year");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("money");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryID).IsClustered(false);

            entity.Property(e => e.TerritoryID).HasMaxLength(20);
            entity.Property(e => e.TerritoryDescription)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
