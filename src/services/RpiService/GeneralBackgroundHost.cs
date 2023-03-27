internal class GeneralBackgroundHost: BackgroundService {
	protected override Task ExecuteAsync(CancellationToken stoppingToken) {
		return Task.CompletedTask;
	}
}