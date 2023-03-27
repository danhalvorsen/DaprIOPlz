using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsiblities {
  public static class ServicesConfiguration {
    public static void SetupMediatR(this IServiceCollection services) {
      //services.AddMediatR(Assembly.GetExecutingAssembly());
      //services.AddSingleton<WeatherForecastService>();
    }
  };
}
