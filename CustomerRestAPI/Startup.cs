using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomerRestAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //COMMENT EVERYTHING TILL THE NEXT COMMENT WHEN CONNECTING WITH A DATABASE
                var facade = new BLLFacade();
                var address = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City="Berat",
                        Street="5 Maji",
                        Number="25"
                    });

                var address2 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Tirane",
                        Street = "Dritan Hoxha",
                        Number = "20"
                    });


                var address3 = facade.AddressService.Create(
                    new AddressBO()
                    {
                        City = "Tirane",
                        Street = "4 Deshmoret",
                        Number = "20"
                    });


                var cust = facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "ARSEN",
                        LastName = "TABAKU",
                        AddressIds = new List<int>() { address.Id, address3.Id }
                    });

                facade.CustomerService.Create(
                    new CustomerBO()
                    {
                        FirstName = "VISAR",
                        LastName = "MANCE",
                        AddressIds = new List<int>() { address.Id, address2.Id }
                    });


                for(int i=0; i<5; i++)
                {
                    facade.OrderService.Create(
                        new OrderBO()
                        {
                            DeliveryDate = DateTime.Now.AddMonths(1),
                            OrderDate = DateTime.Now.AddMonths(-1),
                            CustomerId = cust.Id    //this means that the order should not create a customer but just use the customer id
                        });
                }   
                //TILL HERE
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
