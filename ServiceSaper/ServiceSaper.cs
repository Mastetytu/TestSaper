using AbstractSeviceBase.DB;
using AbstractSeviceBase;
using Infrastruct;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSaper.DB;
using SaperModel;
namespace ServiceSaper
{ 
    public static class MyExtentionDisease
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            services.AddDbContext<AppDBModelSaper>();
            services.AddTransient<IServiceModel<Saper>, ServiceSaper>();

            return services;
        }
    }



    public class ServiceSaper : AbstractBaseServise<Saper>
    {
        AppDBModel _appDB;
        public ServiceSaper(AppDBModelSaper _appDB) : base(_appDB)
        {

        }

        public IEnumerable<Saper> getDisease()
        {
            return base.GetValues();
        }

        public Saper? UpdDisease(Saper saper)
        {
            return base.UpdValue(saper.games, saper);
        }

        public Saper? AddDisease(Saper saper)
        {
            return base.setValue(saper);
        }

        public Saper getDisease(Guid Id)
        {
            return base.GetValue(Id);
        }


    }
}
