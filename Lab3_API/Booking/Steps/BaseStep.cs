using RestSharp;
using TechTalk.SpecFlow;

namespace Lab3.Booking.Steps
{
	[Binding]
	public class BaseStep
	{
		protected static RestClient client { get; set; }
		[BeforeFeature]
		public static void BeforeFeature()
		{
			client = new RestClient("https://restful-booker.herokuapp.com/");
		}
	}
}