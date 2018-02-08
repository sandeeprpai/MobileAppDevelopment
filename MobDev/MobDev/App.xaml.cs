using MobDev.Models;
using MobDev.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobDev
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
		{
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new StartPage())
                    {
                        Title = "Game",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new SettingsPage())
                    {
                        Title = "Settings",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new MonsterPage())
                    {
                        Title="Monster",
                        Icon= Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new PlayerPage())
                    {
                        Title="Player",

                    },
                    new NavigationPage(new ItemsPage() { BindingContext = new ItemsFromAPI() })
                    {
                        Title="Items",

                    },
                    new NavigationPage(new DBDumpPage())
                    {
                        Title="Clear DB",

                    }
                }
            };
        }
	}
}
