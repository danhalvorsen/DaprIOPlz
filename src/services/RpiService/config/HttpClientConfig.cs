using FluentValidation;

namespace RpiService.config {
	public interface IHttpClientConfig {
		string Agents { get; set; }
		string BaseAddress { get; set; }

		string RelativePath { get; set; }
		List<KeyValuePair<string,string>> Headers { get; set; }
	}

	public class HttpClientConfig: IHttpClientConfig {
		/// <inheritdoc/>
		public string Agents { get; set; }
		public string BaseAddress { get; set; }
		public string RelativePath { get; set; }
		public List<KeyValuePair<string,string>> Headers { get; set; }

		public HttpClientConfig() {
			Agents = string.Empty;
			BaseAddress = string.Empty;
			RelativePath = string.Empty;
			Headers = new List<KeyValuePair<string,string>>();
		}
	};

	public class HttpClientConfigValidator: AbstractValidator<IHttpClientConfig> {
		//public HttpClientConfigValidator(IValidator<IHttpHeaderField> validation,
		//                                 IValidator<IUriField> uriValidator) {
		//  RuleFor(m => m.BaseAddress).SetValidator(uriValidator);
		//  RuleFor(m => m.RelativePath).SetValidator(uriValidator);
		//  RuleForEach(m => m.Headers).SetValidator(validation);
		//}
	}
}
