using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.Data
{
    public class ITechArtSurvayContext : DbContext
    {
        public ITechArtSurvayContext()
            : base("iTechArtSurvayDb")
        {
                
        }

        public DbSet<User> Users { get; set; }
    }
}