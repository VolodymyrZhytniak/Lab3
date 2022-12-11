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
	public class GetBookingSteps : BaseStep
	{
		private RestRequest request;
		private RestResponse response;
		private int id;
		[Given("id of booking")]
		public void GivenIdOfBooking()
		{
			id = JsonConvert.DeserializeObject<List<BookingIdModel>>(client.Execute(new RestRequest("booking?firstname=Jim", Method.Get)).Content).First().BookingId;
		}
		[When("creating get booking with id and send request")]
		public void WhenCreatingGetBooking()
		{
			request = new RestRequest($"booking/{id}", Method.Get);
			request.AddHeaders(new Dictionary<string, string> {
				{ "Accept", "application/json" }
			});
			response = client.Execute(request);
		}
		[Then(@"booking has found")]
		public void ThenResponseIsSuccess()
		{
			Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}