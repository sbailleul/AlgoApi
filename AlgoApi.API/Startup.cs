using AlgoApi.Core.CostCalculating;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.MatrixGenerating;
using AlgoApi.Core.NodeHandling;
using AlgoApi.Core.PathFinding;
using AlgoApi.Core.Sorting;
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
            services.AddTransient(serviceProvider =>
                new SorterService<NaiveSearch<string>, string>(new NaiveSearch<string>()));
            services.AddTransient(serviceProvider =>
                new SorterService<GeneticAlgorithm<string>, string>(new GeneticAlgorithm<string>()));
            services.AddTransient(serviceProvider =>
                new SorterService<SimulatedAnnealing<string>, string>(new SimulatedAnnealing<string>()));
            services.AddTransient(serviceProvider => new PathFinderService<Dijkstra>(new Dijkstra(new GraphNodeHandler(), new GraphCostCalculator())));
            services.AddTransient(serviceProvider => new PathFinderService<AStar>(
                new AStar(
                    new GridNodeHandler(),
                    new GridCostCalculator(new Matrix8DGenerator(), new OctileDistance()))));
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