using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Yoga_App_V1.ViewModels
{
    public class ExternalResourcesViewModel
    {
        public ObservableCollection<Resource> ExternalResources { get; set; }

        public ExternalResourcesViewModel()
        {
            ExternalResources = new ObservableCollection<Resource>()
            {
                new Resource()
                {
                    Icon="betterhelpicon.PNG",
                    IconHeight=50,
                    IconWidth=500,
                    Content="<p>An independant source of online counciling made easy. The easiest way to access conciling, at affordable pricing with no pressure</p>",
                    ContentHeight = 120,
                    ContentWidth = 1000,
                    BoundCommand = new Command(async () => await TravelToLink("https://www.betterhelp.com/about/")),
                    ButtonVisible = true
                },
                new Resource()
                {
                    Icon="nhslogo.png",
                    IconHeight=40,
                    IconWidth=500,
                    Content="<p>Find Information and ways to reach out for support on mental health issues. A wide array of resources at no charge.</p>",
                    ContentHeight = 110,
                    ContentWidth = 1000,
                    BoundCommand = new Command(async () => await TravelToLink("https://www.nhs.uk/mental-health/")),
                    ButtonVisible = true
                },
                new Resource()
                {
                    Icon="psych2goicon.PNG",
                    IconHeight=40,
                    IconWidth=100,
                    Content="<p>A popular and respected video on mental health warning signs. If you're on the fence about needing help this video may give you a clearer picture</p>" +
                    "<iframe min-width=\"800vw\" min-height=\"800vh\" src=\"https://www.youtube.com/embed/9B-wTp2PZH8 \" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope;\" allowfullscreen></iframe>",
                    ContentHeight = 800,
                    ContentWidth = 1000,
                    BoundCommand = new Command(async () => await TravelToLink("https://www.youtube.com/watch?v=9B-wTp2PZH8")),
                    ButtonVisible = false
                },
            };
        }

        public async Task TravelToLink(string link)
        {
            try
            {
                await Browser.OpenAsync(link, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.External,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.AliceBlue,
                    PreferredControlColor = Color.Violet
                });
            }
            catch
            {
                Debug.WriteLine("An unexpected error occured. No browser may be installed on the device");
            }
        }
    }

    public class Resource
    {
        public string Icon { get; set; }
        public int IconHeight { get; set; }
        public int IconWidth { get; set; }
        public string Content { get; set; }
        public int ContentHeight { get; set; }
        public int ContentWidth { get; set; }
        public Command BoundCommand { get; set; }
        public bool ButtonVisible { get; set; }
    }
}
