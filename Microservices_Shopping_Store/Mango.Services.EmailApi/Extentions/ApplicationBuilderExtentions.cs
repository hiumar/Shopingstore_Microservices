using Mango.Services.EmailAPI.Messaging;

namespace Mango.Services.EmailApi.Extentions
{
    public static class ApplicationBuilderExtentions
    {
        private static IAzureServiceBusConsumer ServiceBusConsumer { get; set; }
        public static IApplicationBuilder UseAzureServiceBusConsumber(this IApplicationBuilder app)
        {
            ServiceBusConsumer = app.ApplicationServices.GetService<IAzureServiceBusConsumer>();
            var hostApplicationLife = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStopping.Register(OnStop);
            return app;

        }
         private static void OnStart()
         {
            ServiceBusConsumer?.Start();
         }
        private static void OnStop()
        {
            ServiceBusConsumer.Stop();
        }

        
    }
}
