using Lab3.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.Booking.Steps
{
	[Binding]
	public class DeleteBookingSteps : BaseStep
	{
		private RestRequest request;
		private RestResponse response;
		private string AuthToken;
		private int id;

		[Given("token and id for delete the booking")]
		public void GivenTokenAndId()
		{
			var authRequest = new RestRequest("auth", Method.Post);
			authRequest.AddJsonBody(new { username = "admin", password = "password123" });
			var authResponse = client.Execute(authRequest);
			AuthToken = JsonConvert.DeserializeObject<TokenModel>(authResponse.Content).Token;
			id = JsonConvert.DeserializeObject<List<BookingIdModel>>(client.Execute(new RestRequest("booking?firstname=Jim", Method.Get)).Content).First().BookingId;
		}
		[When("send request for delete the booking")]
		public void WhenDeleteBooking()
		{
			request = new RestRequest($"booking/{id}", Method.Delete);
			request.AddHeaders(new Dictionary<string, string> {
				{ "Content-Type", "application/json" },
				{ "Cookie", $"token={AuthToken}"}
			});

			response = client.Execute(request);
		}
		[Then(@"booking is deleted")]
		public void ThenResponseIsSuccess()
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
		}
	}
}