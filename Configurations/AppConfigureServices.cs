using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configurations
{
    public static class AppConfigureServices
    {
        public static IServiceCollection ConfigureWebOptimizer(this IServiceCollection services, IWebHostEnvironment env)
        {

            bool[] options = new bool[] { true, false };
            if (env.IsProduction())
            {
                services.AddWebOptimizer(minifyJavaScript: false, minifyCss: false);
            }
            else
            {
                services.AddWebOptimizer(pipeline =>
                {
                    pipeline.AddCssBundle("/css/bundle.css", "wwwroot/app.css", "wwwroot/bootstrap/bootstrap.min.css");
                    pipeline.AddJavaScriptBundle("/js/bundle.js", "wwwroot/app.js").UseContentRoot();
                });
            }

            //web optimizer registration    
            //builder.Services.AddWebOptimizer(pipeline =>
            //{
            //    pipeline.AddJavaScriptBundle("/bundle.js", "_content/RazorLibrary/wwwroot/js/site.js", "node_modules/RazorLibrary/wwwroot/js/site2.js")
            //        .UseContentRoot();
            //    pipeline.AddCssBundle("/bundle.css", "_content/RazorLibrary/wwwroot/css/site.css", "node_modules/RazorLibrary/wwwroot/css/site2.css").UseContentRoot();
            //});

            //builder.Services.AddWebOptimizer(pipeline =>
            //{
            //    pipeline.AddCssBundle("/css/bundle.css", "wwwroot/css/*.css").UseContentRoot();
            //    pipeline.AddJavaScriptBundle("/js/bundle.js", "wwwroot/js/*.js").UseContentRoot();
            //});

            return services;
        }
    }
}
