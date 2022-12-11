using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.Booking.Steps
{
	[Binding]
	public class CreateBookingSteps : BaseStep
	{
		private RestRequest request;
		private RestResponse response;
		[Given("connect to client for creating booking")]
		public void GivenConnectToClient()
		{
			request = new RestRequest("booking", Method.Post);
			request.AddHeaders(new Dictionary<string, string> {
				{ "Accept", "application/json" },
				{ "Content-Type", "application/json" }
			});
			request.AddJsonBody(new
			{
				firstname = "Jim",
				lastname = "Brown",
				totalprice = 111,
				depositpaid = true,
				bookingdates = new { checkin = "2018-01-01", checkout = "2019-01-01" },
				additionalneeds = "Breakfast"
			});
		}
		[When("send request for create booking")]
		public void WhenSendRequest()
		{
			response = client.Execute(request);
		}
		[Then(@"booking is created")]
		public void ThenResponseIsSuccess()
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}