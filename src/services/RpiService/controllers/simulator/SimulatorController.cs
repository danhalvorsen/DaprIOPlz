using Dapr.Client;
using Dapr.Client.Autogen.Grpc.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RpiService.controllers.pubsub;

namespace RpiService.controllers.simulator {
	[Route("api/[controller]")]
	[ApiController]
	public class SimulatorController: ControllerBase {
		public SimulatorController() {
		}

		[HttpGet]
		public async Task<IOResult> PublishEventRequestAsync(IOState state) {
			var daprClient = new DaprClientBuilder().Build();
			var result = new IOResult();
			await daprClient.PublishEventAsync<IOResult>("pubsub",topicName: "ioresult",result);
			return result;
		}

	}
}
