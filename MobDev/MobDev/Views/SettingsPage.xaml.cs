using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public static bool isServerOn { get; set; }
        public static int isRandomOn { get; set; }
        public static int isSuperOn { get; set; }
        public static bool isMagicOn { get; set; }
        public static bool isHealingOn { get; set; }
        public static bool isBattleEventsOn { get; set; }
        public static bool isCriticalHitMissOn { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
            Label debuglabel = new Label
            {
                Text = "Debug Mode"
            };


            Label random_results_label = new Label
            {
                Text = "Random Results"
            };

            Switch random_results_switch = new Switch
            {
                
            };
            random_results_switch.Toggled += random_results_switch_Toggled;

            void random_results_switch_Toggled(object sender, ToggledEventArgs e)
            {
                if (e.Value.Equals("true"))
                {
                    SettingsPage.isRandomOn = 1;
                }
                else if (e.Value.Equals("false"))
                {
                    SettingsPage.isRandomOn = 0;
                }
                

            };

            Label super_results_label = new Label
            {
                Text = "Super Results"
            };

            Switch super_results_switch = new Switch
            {
            };
            super_results_switch.Toggled += super_results_switch_Toggled;

            void super_results_switch_Toggled(object sender, ToggledEventArgs e)
            {
                if(e.Value.Equals("true"))
                {
                    SettingsPage.isSuperOn = 1;
                }
                else if (e.Value.Equals("false"))
                {
                    SettingsPage.isSuperOn = 0;
                }
                
            };

            Label server_items_label = new Label
            {
                Text = "Server Items"
            };

            Switch server_items_switch = new Switch
            {
               
            };
            server_items_switch.Toggled += server_items_switch_Toggled;


            // maybe changing not on/off, but get new set of items
            void server_items_switch_Toggled(object sender, ToggledEventArgs e)
            {
                SettingsPage.isServerOn = e.Value;
                //server_items_label.Text = String.Format("Server Items", e.Value);
                if (server_items_switch.IsToggled == false)
                {

                    random_results_switch.IsToggled = false;
                    random_results_switch.IsEnabled = false;
                    SettingsPage.isRandomOn = 0;

                    super_results_switch.IsToggled = false;
                    super_results_switch.IsEnabled = false;
                    SettingsPage.isSuperOn = 0;
                }
                else
                {
                    random_results_switch.IsEnabled = true;
                    super_results_switch.IsEnabled = true;
                    SettingsPage.isRandomOn = 1;
                    SettingsPage.isSuperOn = 1;
                }


            };




            Label critical_label = new Label
            {
                Text = "Critical Hits/Miss"
            };
            


            Switch critical_switch = new Switch
            {
            };
            critical_switch.Toggled += critical_hit_switch_Toggled;

           
            void critical_hit_switch_Toggled(object sender, ToggledEventArgs e)
            {
                SettingsPage.isCriticalHitMissOn = e.Value;
            };


           Label item_use_label = new Label
            {
                Text = "Item Usage"
            };

            Switch item_use_switch = new Switch
            {
            };
            item_use_switch.Toggled += item_use_switch_Toggled;

            void item_use_switch_Toggled(object sender, ToggledEventArgs e)
            {

            };


            Label magic_use_label = new Label
            {
                Text = "Magic Usage"
            };

            Switch magic_use_switch = new Switch
            {
            };
            magic_use_switch.Toggled += magic_use_switch_Toggled;

            void magic_use_switch_Toggled(object sender, ToggledEventArgs e)
            {
                SettingsPage.isMagicOn = e.Value;
            };


            Label healing_use_label = new Label
            {
                Text = "Healing Usage"
            };

            Switch healing_use_switch = new Switch
            {
            };
            healing_use_switch.Toggled += healing_use_switch_Toggled;

            void healing_use_switch_Toggled(object sender, ToggledEventArgs e)
            {
                SettingsPage.isHealingOn = e.Value;
            };


            Label battle_events_label = new Label
            {
                Text = "Battle Events"
            };

            Switch battle_events_switch = new Switch
            {
            };
            battle_events_switch.Toggled += battle_events_switch_Toggled;

            void battle_events_switch_Toggled(object sender, ToggledEventArgs e)
            {
                SettingsPage.isBattleEventsOn = e.Value;
            };



            Switch debugswitch = new Switch
            {
            };
            debugswitch.Toggled += debugswitch_Toggled;



            void debugswitch_Toggled(object sender, ToggledEventArgs e)
            {
                if (debugswitch.IsToggled == false)
                {
                    turnOffButtons();
                }
                else
                {
                    turnOnButtons();
                }
            };


            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 0
            };

            turnOffButtons();

            layout.Children.Add(server_items_label);
            layout.Children.Add(server_items_switch);
            layout.Children.Add(random_results_label);
            layout.Children.Add(random_results_switch);
            layout.Children.Add(super_results_label);
            layout.Children.Add(super_results_switch);

            debugswitch.IsEnabled = true;
            debugswitch.IsToggled = false;

            random_results_switch.IsEnabled = false;
            random_results_switch.IsToggled = false;
            SettingsPage.isRandomOn = 0;

            super_results_switch.IsToggled = false;
            super_results_switch.IsEnabled = false;
            SettingsPage.isSuperOn = 0;


            layout.Children.Add(debuglabel);
            layout.Children.Add(debugswitch);

            layout.Children.Add(critical_label);
            layout.Children.Add(critical_switch);
            
            layout.Children.Add(item_use_label);
            layout.Children.Add(item_use_switch);

            layout.Children.Add(magic_use_label);
            layout.Children.Add(magic_use_switch);

            layout.Children.Add(healing_use_label);
            layout.Children.Add(healing_use_switch);

            layout.Children.Add(battle_events_label);
            layout.Children.Add(battle_events_switch);


            var scrollView = new ScrollView { Content = layout };
            Content = scrollView;


            void turnOffButtons()
            {
                critical_switch.IsToggled = false;
                critical_switch.IsEnabled = false;
                SettingsPage.isCriticalHitMissOn = false;
                
                item_use_switch.IsToggled = false;
                item_use_switch.IsEnabled = false;


                magic_use_switch.IsToggled = false;
                magic_use_switch.IsEnabled = false;
                SettingsPage.isMagicOn = false;

                healing_use_switch.IsToggled = false;
                healing_use_switch.IsEnabled = false;
                SettingsPage.isHealingOn = false;

                battle_events_switch.IsToggled = false;
                battle_events_switch.IsEnabled = false;
                SettingsPage.isBattleEventsOn = false;
            }

            void turnOnButtons()
            {
                critical_switch.IsEnabled = true;
                critical_switch.IsToggled = true;
                SettingsPage.isCriticalHitMissOn = true;

                item_use_switch.IsToggled = true;
                item_use_switch.IsEnabled = true;

                magic_use_switch.IsToggled = true;
                magic_use_switch.IsEnabled = true;
                SettingsPage.isMagicOn = true;

                healing_use_switch.IsToggled = true;
                healing_use_switch.IsEnabled = true;
                SettingsPage.isHealingOn = true;

                battle_events_switch.IsToggled = true;
                battle_events_switch.IsEnabled = true;
                SettingsPage.isBattleEventsOn = true;
            }
        }
    }
}