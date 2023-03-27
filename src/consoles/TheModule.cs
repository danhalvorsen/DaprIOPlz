
using Microsoft.Extensions.Options;
public interface ITheModule { }
public class TheModule: ITheModule {
  public TheModuleConfiguration config { get; set; }

  public TheModule(IOptions<TheModuleConfiguration> config) {
    this.config = config.Value;
  }
}
