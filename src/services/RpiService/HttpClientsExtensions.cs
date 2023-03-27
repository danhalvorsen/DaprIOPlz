using RpiService.config;
using RpiService.services;

namespace RpiService {
	/// <summary>
	/// 
	/// </summary>
	public static class HttpClientsExtensions {

		/// <summary>
		/// Adds the HTTP client configuration.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddHttpClientConfiguration(
			 this IServiceCollection services,IConfiguration configuration) {
			return services.Configure<HttpClientConfigOptions>(
								configuration.GetSection(HttpClientConfigOptions.HttpClientConfig));
		}
		/// <summary>
		/// Adds the HTTP client configuration dependencies.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddHttpClientConfigDependencies(
		this IServiceCollection services) {
			services.AddHttpClient<RpiServiceHttpService>(
						client => {
							client.BaseAddress = new
								System.Uri("https://jsonplaceholder.typicode.com/");
							client.DefaultRequestHeaders.UserAgent
								.ParseAdd("dotnet-docs");
						});
			services.AddTransient<IRpiServiceHttpService,RpiServiceHttpService>();

			return services;
		}

	}

}
