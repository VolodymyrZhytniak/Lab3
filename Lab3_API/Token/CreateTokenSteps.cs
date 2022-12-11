using Lab3.Booking.Steps;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.Token
{
	[Binding]
	public class CreateTokenSteps : BaseStep
	{
		private RestRequest request;
		private RestResponse response;
		[Given("token request")]
		public void GivenTokenRequest()
		{
			request = new RestRequest("auth", Method.Post);
			request.AddJsonBody(new { username = "admin", password = "password123" });
		}
		[When("send token request")]
		public void WhenSendRequest()
		{
			response = client.Execute(request);
		}
		[Then(@"response is success")]
		public void ThenResponseIsSuccess()
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}