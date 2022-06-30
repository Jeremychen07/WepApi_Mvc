using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
	public class Startup
	{
		private string cnstr = "";
		public Startup(IWebHostEnvironment webHostEnvironment)
		{
			cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={webHostEnvironment.ContentRootPath}\\App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True";
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(cnstr));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=index}/{id?}");				
			});
		}
	}
}
