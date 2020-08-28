//using InspireCoders.Domain;
//using InspireCoders.Infrastructure;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace InspireCoders.Presentation
//{
//    public static class WebHostExtension
//    {
//        private static IAccountService _service;

//        public static IWebHost SeedData(this IWebHost host,IAccountService service)
//        {
//            using (var scope = host.Services.CreateScope())
//            {
//                _service = service;
//                var services = scope.ServiceProvider;
//                var context = services.GetService<TContext>();

//                // now we have the DbContext. Run migrations
//                context.Database.Migrate();

//                // now that the database is up to date. Let's seed

//                _service.SeedAsync();
//               // new PostTypesSeeder(context).SeedData();

//                // if we are debugging, then let's run the test data seeder
//                // alternatively, check against the environment to run this seeder
//               // new TestDataSeeder(context).SeedData();
            
//            }

//            return host;
//        }
//    }
//}
