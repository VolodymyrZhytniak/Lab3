using Lab3.WallHaven.Steps;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.WallHaven.Steps
{
	[Binding]
	public class GetSteps : BaseSteps
	{
		private RestRequest request;
		private RestResponse response;
		[Given("request to get wallpaper")]
		public void GivenRequestToGetWallpaper()
		{
			request = new RestRequest("?results", Method.Get);
			request.AddHeaders(new Dictionary<string, string> {
				{ "Accept", "application/json" },
				{ "Content-Type", "application/json" }
			});
		}
		[When("send request to get wallpaper")]
		public void WhenSendRequestToGetQuote()
		{
			response = image.Execute(request);
		}
		[Then("successful response with wallpaper data")]
		public void ThenResponseIsSuccess()
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}