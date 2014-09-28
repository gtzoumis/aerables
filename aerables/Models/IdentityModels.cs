using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace aerables.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Device> Devices { get; set; }
    }

    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public int Device_Id { get; set; }
        public string APIKey { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string Last_entry { get; set; }
        public virtual ICollection<Feed> Measurements { get; set; }
    }

    public class Feed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public int Entry_Id { get; set; }
        public DateTime Created_at { get; set; }
        public int MeasurementField1 { get; set; }
        public int MeasurementField2 { get; set; }
        public int MeasurementField3 { get; set; }
        public int MeasurementField4 { get; set; }
    }

    public class ErrorLog {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
        public string Message { get; set; }
        public string CallStack { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public DbSet<Feed> Feed { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
    }
}