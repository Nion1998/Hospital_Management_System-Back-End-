namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 30),
                        Rent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientIPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        FatherName = c.String(nullable: false, maxLength: 200),
                        MotherName = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Occupation = c.String(maxLength: 80),
                        Nid = c.Int(),
                        AdmissionDate = c.DateTime(),
                        RoomDetails = c.String(maxLength: 180),
                        RefdBy = c.String(nullable: false, maxLength: 180),
                        DutyDoctor = c.String(maxLength: 180),
                        PaidAmount = c.Double(nullable: false),
                        DoctorId = c.Int(),
                        CabinId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cabins", t => t.CabinId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId)
                .Index(t => t.CabinId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Qualification = c.String(nullable: false, maxLength: 300),
                        Specialization = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerOPDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 20),
                        BloodGroup = c.String(),
                        Phone = c.String(nullable: false, maxLength: 15),
                        RefdBy = c.String(nullable: false, maxLength: 180),
                        Remark = c.String(maxLength: 180),
                        DeliveryDate = c.DateTime(),
                        DeliveryStatus = c.String(maxLength: 40),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.OPDBillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ItemTotal = c.Double(nullable: false),
                        Discount = c.Double(),
                        TotalBill = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        CustomerOPDId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOPDs", t => t.CustomerOPDId, cascadeDelete: true)
                .Index(t => t.CustomerOPDId);
            
            CreateTable(
                "dbo.OPDOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 200),
                        TotalPrice = c.Int(nullable: false),
                        CustomerOPDId = c.Int(nullable: false),
                        ItemExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOPDs", t => t.CustomerOPDId, cascadeDelete: true)
                .ForeignKey("dbo.ItemExams", t => t.ItemExamId, cascadeDelete: true)
                .Index(t => t.CustomerOPDId)
                .Index(t => t.ItemExamId);
            
            CreateTable(
                "dbo.ItemExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OTDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        PatientId = c.String(nullable: false, maxLength: 200),
                        Details = c.String(nullable: false, maxLength: 200),
                        Surgeon = c.String(nullable: false, maxLength: 250),
                        Anesthetist = c.String(nullable: false),
                        OTDate = c.DateTime(nullable: false),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.CustomerPharmacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PharmacyBillings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ItemTotal = c.Double(nullable: false),
                        Discount = c.Double(),
                        TotalBill = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        DueAmount = c.Double(nullable: false),
                        CustomerPharmacyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerPharmacies", t => t.CustomerPharmacyId, cascadeDelete: true)
                .Index(t => t.CustomerPharmacyId);
            
            CreateTable(
                "dbo.PharmacyOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicineName = c.String(nullable: false, maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        CustomerPharmacyId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerPharmacies", t => t.CustomerPharmacyId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.CustomerPharmacyId)
                .Index(t => t.MedicineId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Role = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Details = c.String(nullable: false, maxLength: 200),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TKey = c.String(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        ExpirationTime = c.DateTime(),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PharmacyOrderDetails", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Medicines", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PharmacyOrderDetails", "CustomerPharmacyId", "dbo.CustomerPharmacies");
            DropForeignKey("dbo.PharmacyBillings", "CustomerPharmacyId", "dbo.CustomerPharmacies");
            DropForeignKey("dbo.PatientIPDs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.OTDetails", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.OPDOrderDetails", "ItemExamId", "dbo.ItemExams");
            DropForeignKey("dbo.OPDOrderDetails", "CustomerOPDId", "dbo.CustomerOPDs");
            DropForeignKey("dbo.OPDBillings", "CustomerOPDId", "dbo.CustomerOPDs");
            DropForeignKey("dbo.CustomerOPDs", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientIPDs", "CabinId", "dbo.Cabins");
            DropIndex("dbo.Medicines", new[] { "SupplierId" });
            DropIndex("dbo.PharmacyOrderDetails", new[] { "MedicineId" });
            DropIndex("dbo.PharmacyOrderDetails", new[] { "CustomerPharmacyId" });
            DropIndex("dbo.PharmacyBillings", new[] { "CustomerPharmacyId" });
            DropIndex("dbo.OTDetails", new[] { "DoctorId" });
            DropIndex("dbo.OPDOrderDetails", new[] { "ItemExamId" });
            DropIndex("dbo.OPDOrderDetails", new[] { "CustomerOPDId" });
            DropIndex("dbo.OPDBillings", new[] { "CustomerOPDId" });
            DropIndex("dbo.CustomerOPDs", new[] { "DoctorId" });
            DropIndex("dbo.PatientIPDs", new[] { "CabinId" });
            DropIndex("dbo.PatientIPDs", new[] { "DoctorId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Materials");
            DropTable("dbo.Employees");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Medicines");
            DropTable("dbo.PharmacyOrderDetails");
            DropTable("dbo.PharmacyBillings");
            DropTable("dbo.CustomerPharmacies");
            DropTable("dbo.OTDetails");
            DropTable("dbo.ItemExams");
            DropTable("dbo.OPDOrderDetails");
            DropTable("dbo.OPDBillings");
            DropTable("dbo.CustomerOPDs");
            DropTable("dbo.Doctors");
            DropTable("dbo.PatientIPDs");
            DropTable("dbo.Cabins");
        }
    }
}
