using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Bu alttakileri böyle yapmak yerine Autofac, Ninject, Postsharp gibi IOC Container kullanarak projede AOP yaklaþýmý da kullanabilmeyi saðlayacaðýz. Bir de bunlarý burada yaparsak ileri de projeye baþka bir API ekleyeceðimiz zaman sýkýntý yaþayabiliriz. O yüzden back-end tarafýnda kullanacaðýz. Bu proje için Business katmanýna Autofac ve Autofac.Extras.DynamicProxy kurulacak. Business'ta DependencyResolvers adýnda klasör oluþturup, içine Autofac bir teknoloji olduðu için onun içinde bir klasör oluþturup, yine bunun içine AutofacBusinessModule adýyla class oluþturup ilgili iþlemler oraya eklenecek. Her projede kullanýlabilecek olan iþlemler ise Core katmanýna eklenecek.

            //Orada ilgili iþlemleri yaptýktan sonra API'de program.cs içerisinde API'ye kendi configürasyonunu deðil bizim sonradan eklediðimiz Autofac yapýlanmasýný kullanacaðýmýzý belirtip tanýtmamýz gerekiyor.
            
            //services.AddSingleton<IProductService, ProductManager>();
            //services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
