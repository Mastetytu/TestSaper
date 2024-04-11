using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AbstractSeviceBase;
using AbstractSeviceBase.DB;
using SaperModel;
using Microsoft.EntityFrameworkCore;
namespace ServiceSaper.DB
{

    public class AppDBModelSaper : AppDBModel
    {
        public DbSet<Saper> Saper { get; set; }
       


        public AppDBModelSaper(DbContextOptions<AppDBModel> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
