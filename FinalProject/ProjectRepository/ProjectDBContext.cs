using ProjectEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectRepository
{
     class ProjectDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RentAd> RentAds { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}
