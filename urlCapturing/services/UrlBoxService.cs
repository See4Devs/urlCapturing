using System;
using Microsoft.Extensions.Configuration;
using UrlBox;

namespace urlCapturing.services
{
	public class UrlBoxService
	{
		public void urlBoxScreenShots()
		{
            var urlBoxConfig = new ConfigurationBuilder()
                              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile("settings.json").Build();

            string apiKey = urlBoxConfig.GetSection("UrlBoxConfig:ApiKey").Value;
            string apiSecret = urlBoxConfig.GetSection("UrlBoxConfig:ApiSecret").Value;
            var urlBox = new UrlBoxClient(apiKey, apiSecret);
            var weburl = "https://bbc.com";

            //simple screenshot
            var requestSimpleScreenshot = new ScreenshotRequest(new Uri(weburl));
            var outputSimple = urlBox.GetSignedUrl(requestSimpleScreenshot);
            Console.WriteLine(outputSimple);


            //fullscreen without Ads anc cookie banners
            var requestFullNoAds = new ScreenshotRequest(new Uri(weburl))
            {
                FullPage = true,
                BlockAds = true,
                HideCookieBanners = true
            };
            var outputFullNoAds = urlBox.GetSignedUrl(requestFullNoAds);
            Console.WriteLine(outputFullNoAds);


            //Retina quality png based on subset of a page
            var requestRetina = new ScreenshotRequest(new Uri(weburl))
            {
                Width = 768,
                UserAgent = "mobile",
                Retina = true,
                BlockAds = true,
                HideCookieBanners = true,
                Selector = ".module--editors-picks",
                Delay = TimeSpan.FromSeconds(10),
                FailIfSelectorMissing = true,
                FailOn4xx = true,
                FailOn5xx = true
            };
            var outputRetina = urlBox.GetSignedUrl(requestRetina);
            Console.WriteLine(outputRetina);

            //Full-page pdf Document with Highlights
            var requestPDF = new ScreenshotRequest(new Uri(weburl), "pdf")
            {
                FullPage = true,
                BlockAds = true,
                HideCookieBanners = true,
                PdfBackground = false,
                Highlight = "Supreme Court",
                HighlightBg = "red",
                HighlightFg = "white"
            };

            var outputPDF = urlBox.GetSignedUrl(requestPDF);
            Console.WriteLine(outputPDF);
        }

	}
}

