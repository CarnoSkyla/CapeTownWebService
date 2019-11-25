using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuthApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public Color Red { get; private set; }

       
        private void Name_Focused(object sender, FocusEventArgs e)
        {
            Name.BackgroundColor = Color.Aquamarine;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            
            var name = Name.Text;

            var x = string.IsNullOrEmpty(name);
            var password = Password.Text;
            var y = string.IsNullOrEmpty(password);
           

           

            if(x || y)
            {
                Message.Text = "Please enter a name or password";
            }
            else
            {
                var token = password.Substring(0, 3) + "%$#" + name.Substring(0, 3);
                DisplayName.Text = "Your name is: " + name;
                DisplayPassword.Text = "Your token is " + token;
            }
            

            
            


        }

        private async void NextPageBtn_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Page1());
        }
    }
}
