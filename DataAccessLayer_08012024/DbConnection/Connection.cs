using AllModels.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_08012024.DbConnection
{
    public class Connection:DbContext
    {
        public Connection(DbContextOptions<Connection> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateMaster>()
                .HasOne<CountryMaster>(s => s.CountryMasters)
                .WithMany(g => g.StateMasters)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<DistrictMaster>()
               .HasOne<StateMaster>(s => s.StateMasters)
               .WithMany(g => g.DistrictMasters)
               .HasForeignKey(s => s.StateId);

            modelBuilder.Entity<GotraMaster>()
              .HasOne<SubCasteMaster>(s => s.CasteMasters)
              .WithMany(g => g.GotraMasters)
              .HasForeignKey(s => s.SubCasteId);

        }

        public DbSet<CountryMaster> CountryMasterTabb { get; set; }
        public DbSet<StateMaster> StateMasterTabb { get; set; }
        public DbSet<DistrictMaster> DistrictMasterTabb { get; set; }
        public DbSet<SubCasteMaster> SubCasteMasterTabb { get; set; }
        public DbSet<GotraMaster> GotraMasterTabb { get; set; }
        public DbSet<EducationMaster> EducationMaasterTabb { get; set; }
        public DbSet<Enquiry> EnquiryTables { get; set; }
        public DbSet<ProfessionMaster> ProfessionTab { get; set; }
        public DbSet<QualificationMaster> QualificationTabb { get; set; }

        public DbSet<FileUploadMODEL> FileTabb { get; set; }

        public DbSet<UserModel> UserTabb { get; set; }
        public DbSet<NewRegistrationModel> NewRegistarTabb { get; set; }





    }
}
