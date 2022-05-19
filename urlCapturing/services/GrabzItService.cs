using System;
using GrabzIt;
using Microsoft.Extensions.Configuration;

namespace urlCapturing.services
{
	public class GrabzItService
	{
		public void grabzItShot()
		{
			var grabzItConfig = new ConfigurationBuilder()
							  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
							  .AddJsonFile("settings.json").Build();

			string apiKey = grabzItConfig.GetSection("GrabzItConfig:ApiKey").Value;
			string apiSecret = grabzItConfig.GetSection("GrabzItConfig:ApiSecret").Value;
			var weburl = "https://bbc.com";

			//Create the GrabzItClient class
			GrabzItClient grabzIt = new GrabzItClient(apiKey, apiSecret);
			// To take a image screenshot
			grabzIt.URLToImage(weburl);
			string imagePath = "./../../../grabzIt-bbc.jpg";
			grabzIt.SaveTo(imagePath);
		}
	}
}

