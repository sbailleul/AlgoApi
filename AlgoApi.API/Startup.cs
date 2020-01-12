using AlgoApi.Core.MatrixHandling;
using AlgoApi.Core.PathFinding;
using AlgoApi.Core.PathFinding.Interfaces;
using AlgoApi.Core.Sorting;
using AlgoApi.Core.Sorting.Interfaces;
using AlgoApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlgoApi.API
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
            services.AddTransient<IMatrixHandler, MatrixHandler>();
            services.AddTransient<INaiveSearch<string>, NaiveSearch<string>>();
            services.AddTransient<IGeneticAlgorithm<string>, GeneticAlgorithm<string>>();
            services.AddTransient<ISimulatedAnnealing<string>, SimulatedAnnealing<string>>();
            services.AddTransient<IDijkstra, Dijkstra>();
            services.AddTransient<IAStar, AStar>();
            services.AddDbContext<AlgoApiContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}