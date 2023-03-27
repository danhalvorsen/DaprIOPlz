using Microsoft.Extensions.Options;
using RpiService.config;

class Notification {
}
namespace RpiService.services {
	public interface IRpiServiceHttpService {
		void Dispose();
	}
	public sealed class RpiServiceHttpService: IDisposable, IRpiServiceHttpService {
		public RpiServiceHttpService(HttpClient httpClient,
			ILogger<RpiServiceHttpService> logger,
			IOptions<HttpClientConfigOptions> options) {

		}
		public void Dispose() {
			throw new NotImplementedException();
		}
	}

}
