namespace Asp.Demo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            // first middleware 
            app.Use(async (context, next) =>
            {
                Console.WriteLine("before");
                await next.Invoke(context);
                Console.WriteLine("after");
            });

            // second middleware  calcualte time request
            app.Use(async (context, next) =>
            {
                var startTime = DateTime.Now;

                await next.Invoke(context);
                var endTime = DateTime.Now;
                var duration = endTime - startTime;
                Console.WriteLine(duration);

            });


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();

            // Routing   convention routing (Route Pattern)  => like redirection
            app.MapControllerRoute
            (
              name: "shop",   // there is no controll shop
              pattern: "shop/{id}",
              defaults: new
              {
                  Controller = "Products",         // redirect to products controller
                  action = "GetProductById"          // redirect to getproducts action
              }
            );

            // default convention routing
            app.MapControllerRoute( 
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
