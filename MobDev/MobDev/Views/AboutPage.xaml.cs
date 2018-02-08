
using Xamarin.Forms;

namespace MobDev.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();

            System.DateTime dateTime = System.DateTime.Now;
            int hour = int.Parse(dateTime.ToString("hh"));
            int min = int.Parse(dateTime.ToString("mm"));
            int sec = int.Parse(dateTime.ToString("ss"));
            string ampm = dateTime.ToString("tt");
            details.Text = "Date/Time - " + dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + ", " + hour + ":" + min + " " + ampm;
        }
	}
}
