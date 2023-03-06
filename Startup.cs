using DeriDeveloperWebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DeriDeveloperWebApp
{
    public class Startup
    {
        public delegate Task RequestDelegate(HttpContext context);

        IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            DeriLibrary.Console.Worker.NotifyMessageCall($"startup -> env.WebRootPath: {env.WebRootPath} ; env.WebRootFileProvider: {env.WebRootFileProvider}");

            Configuration = configuration;
            _env = env;
            Services.Background.Worker.WebHostEnvironment = env;
            Init();
        }

        private void Init()
        {
            DeriLibrary.Config.FolderPhoto = $"images";
            DeriLibrary.Config.FolderPhotoRoot = $"{_env.WebRootPath}";
            
            DeriLibrary.WorkerImages.Init();


            CheckFolderIamgesCourseCertificates();



        
			CreateDefaultFolders();

			if (Services.DataBase.Config.RestartDB)
			{
				Services.DataBase.Worker.RestartDataBase();
			}

			if (Services.DataBase.Config.FillDefaultDB)
			{
				Services.DataBase.Worker.FillDefaultData();
			}


			/*WorkerDB.AddTable("Softs", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                        "name TEXT NOT NULL," +
                                        "description TEXT NOT NULL," +
                                        "path_program TEXT NOT NULL," +
                                        "path_logo TEXT NOT NULL DEFAULT \"NoLogo.png\"," +
                                        "images_id TEXT NOT NULL");

            WorkerDB.AddTable("Images", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                        "path TEXT NOT NULL");

            WorkerDB.AddTable("PortfolioCategories", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                                     "title TEXT NOT NULL");

            WorkerDB.AddTable("ReviewsWorks", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                         "work_id INTEGER NOT NULL REFERENCES PortfolioWorks(id)," +
                                         "name TEXT NOT NULL," +
                                         "description TEXT NOT NULL," +
                                         "estimation INT NOT NULL CHECK (estimation between 0 and 5)," +
                                         "path_avatar TEXT NOT NULL," +
                                         "path_emoji_estimation TEXT NOT NULL," +
                                         "date DATETIME NOT NULL");

            WorkerDB.AddTable("ReviewsWorksTokens", "work_id INTEGER NOT NULL REFERENCES PortfolioWorks(id)," +
                                                    "token TEXT NOT NULL UNIQUE," +
                                                    "status BOOLEAN NOT NULL DEFAULT 0");

            WorkerDB.AddTable("PortfolioWorks", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                                "category_id INTEGER NOT NULL REFERENCES PortfolioCategories (id)," +
                                                "title TEXT NOT NULL," +
                                                "description TEXT NOT NULL DEFAULT \"\"," +
                                                "date DATETIME NOT NULL," +
                                                "number_of_views INT NOT NULL DEFAULT 0," +
                                                "images_id TEXT NOT NULL DEFAULT \"0\"");

            WorkerDB.AddTable("CourseCertificates", "id INTEGER NOT NULL UNIQUE PRIMARY KEY AUTOINCREMENT," +
                                                    "title TEXT NOT NULL ," +
                                                    "description TEXT NOT NULL ," +
                                                    "name_file TEXT NOT NULL UNIQUE," +
                                                    "name_school TEXT NOT NULL");

            WorkerDB.RescanTables();*/




		}

		private static void CreateDefaultFolders()
		{
			List<string> paths = new List<string>()
			{
				Config.PathFolderSofts
			};

			string pathFolderResources = Services.Background.Worker.GetFolderResorces();

			foreach (var path in paths)
			{
				var tempFullPath = pathFolderResources + "/" + path;

				if (!Directory.Exists(tempFullPath))
				{
					Directory.CreateDirectory(tempFullPath);
				}
			}
		}

		private static void CheckFolderIamgesCourseCertificates()
        {
            string fullPathToCourseCertificates = DeriLibrary.Config.FolderPhotoRoot + "\\images\\" + Config.PathToCourseCertificates;

            if (!Directory.Exists(fullPathToCourseCertificates))
            {
                Directory.CreateDirectory(fullPathToCourseCertificates);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageSender messageSender, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error","?code={0}");

            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("softs.html");
            //app.UseDefaultFiles(options);

            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true, //allow unkown file types also to be served
                DefaultContentType = "Whatver you want eg: plain/text" //content type to returned if fileType is not known.
            });

            //app.UseHttpsRedirection();
            app.UseRouting();

            /*
            app.Map("/home", ap => ap.Run(async (context) =>
            {
                logger.LogError("Processing request {0}", context.Request.Path);

                await context.Response.WriteAsync("Hellooooo");
                await context.Response.WriteAsync(messageSender.Send());
            }));

            app.Map("/error", ap => ap.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);

                await context.Response.WriteAsync($"Error: {context.Request.Query["code"]}");
            }));*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


        }

       
    }
}
