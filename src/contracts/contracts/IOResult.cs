namespace RpiService.controllers.pubsub {
	public class IOResult {
		public int Pin { get; set; } = 0;
		public bool State { get; set; } = false;

		public IOResult() {
			Pin = 1;
			State = !State;
		}
	}
}
