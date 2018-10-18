using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ProfileQuiz.Model;
using ProfileQuiz.ViewModel;
using System.Diagnostics;
using ProfileQuiz.ViewModel;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProfileQuiz.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserListPage : ContentPage
	{
    
        public UserListPage ()
        {

            BindingContext = new UserViewModel(null, null);

            InitializeComponent();

        }


        public void Add_Clicked(object sender, EventArgs a)
        {
            this.Navigation.PopAsync();
            this.Navigation.PushAsync(new View.AddUserPage(null));
        }

        private void Userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PopAsync();
            this.Navigation.PushAsync(new View.AddUserPage(Userlist.SelectedItem as UserInfo));
        }
    }
}