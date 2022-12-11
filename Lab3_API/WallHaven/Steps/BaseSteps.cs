using RestSharp;
using TechTalk.SpecFlow;

namespace Lab3.WallHaven.Steps
{
	[Binding]
	public class BaseSteps
	{
		protected static RestClient image { get; set; }
		[BeforeFeature]
		public static void BeforeFeature()
		{
			image = new RestClient("https://wallhaven.cc/help/api");
		}
	}
}