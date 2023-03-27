using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using RpiService.controllers.pubsub;

namespace RpiService.controllers.pubsub {
	[Route("api/[controller]")]
	[ApiController]
	public class DigitalIOController: ControllerBase {

		[HttpPost(template: "iodata")]
		public async Task<ActionResult<IOResult>> RaiseAsync() 
		{
			var daprClient = new DaprClientBuilder().Build();
			var result = new IOResult();
			await daprClient.PublishEventAsync<IOResult>("pubsub",topicName: "ioresult", result);
			return result;
		}
	}
}
