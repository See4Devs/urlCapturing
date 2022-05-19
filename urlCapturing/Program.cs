
using urlCapturing.services;

namespace urlCapturing
{
    class Program
    {
        static void Main(string[] args)
        {

            // Taking screenshots with Selenium
            var seleniumShot = new SeleniumService();
            seleniumShot.seleniumScreenShot();
            //end

            // Taking screenshots with GrabzIt
            var grabzItShot = new GrabzItService();
            grabzItShot.grabzItShot();
            //end

            // Taking screenshots with UrlBox 
            var urlBox = new UrlBoxService();
            urlBox.urlBoxScreenShots();
            //end
        }
    }
}
