using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = CreateHostBuilder(args).Build();
Application app = host.Services.GetRequiredService<Application>();

static IHostBuilder CreateHostBuilder(string[] args) {
  var builder = Host.CreateDefaultBuilder(args)
  .ConfigureAppConfiguration(c => c.AddJsonFile("appsettings.json",optional: false,reloadOnChange: true))
  .ConfigureServices((hostContext,services) => {

    IConfiguration configuration = hostContext.Configuration;
    var config = configuration.GetSection(nameof(TheModuleConfiguration));
    services.AddLogging(b => b.AddConsole());
    // services.Configure<RulesEngineServiceOptions>(configuration.GetSection(nameof(RulesEngineServiceOptions)));

    //services.AddTransient<IIntegerField, IntegerField>();
    //services.AddTransient<IBInputs, BInputs>();
    //services.AddTransient<IBRule, BRule> ();

    //services.AddMediatR(typeof(ExecuteWorkflow));

    //services.AddTransient<IPipelineBehavior<ExecuteWorkflowsRequest, WorkflowResponse>, LoadRuleBehavior>();
    //services.AddTransient<IPipelineBehavior<ExecuteWorkflowsRequest, WorkflowResponse>, LoadInputBehavior>();

    //services.AddOptions<HttpClientConfig>();
    //services.AddOptions<RulesEngineServiceConfig>();
    services
            .AddSingleton<Application,Application>()
            .AddSingleton<IAppConfig,AppConfig>();
    //        .AddTransient<IRulesEngineService, FakePipeline>();
    //services.AddHttpClient<RulesEngineService>();
  });
  return builder;
}

internal interface IAppConfig {
  string Setting { get; }
}

internal class AppConfig: IAppConfig {
  public string Setting { get; }
  public AppConfig() {
    Console.WriteLine("AppConfig constructed");
  }
}

internal class Application {
  private readonly IAppConfig config;

  public Application(IAppConfig config,ILogger<Application> logger) {
    this.config = config;
    logger.Log(LogLevel.Information,"Application constructed");
    this.config = config;
  }
}
