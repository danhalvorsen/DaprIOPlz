using MediatR;
using Microsoft.Extensions.Options;

public class FooPipelineModule: ITheModule {
  private readonly IMediator _mediator;

  public TheModuleConfiguration config { get; set; }

  public FooPipelineModule(
  IMediator mediator,
  IOptions<TheModuleConfiguration> config) {

    _mediator = mediator;
  }
}
