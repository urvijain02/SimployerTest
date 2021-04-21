using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using TopicTweets.Data.AppContext;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Filters;
using TopicTweets.Handler.ConfigModels;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Integrations;
using TopicTweets.Handler.Mappers;

namespace TopicTweets
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {



            services.Configure<TwitterSettings>(Configuration.GetSection(nameof(TwitterSettings)));
            services.AddHttpClient<ITwitterClient>();

            // Application services DI
            services.AddTransient<ITwitterClient, TwitterClient>();
            services.AddTransient<IMappings, Mappings>();
            services.AddTransient<ITopicDataAccess, TopicDataAccess>();
            services.AddTransient<ITweetDataAccess, TweetDataAccess>();
            services.AddTransient<ITopicHandler, TopicHandler>();
            services.AddTransient<ITweetHandler, TweetHandler>();

            // Inject Logger DI
            services.AddLogging();

            var sqlconn = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(sqlconn);
            });
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AppExceptionFilter));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopicTweets", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="context"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("v1/swagger.json", "TopicTweets v1");
            }
            );

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}