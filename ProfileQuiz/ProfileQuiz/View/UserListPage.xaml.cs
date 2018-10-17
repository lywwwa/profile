using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ProfileQuiz.Model;
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
      
        //UOM uom;

        public UserListPage ()
		{
           
            InitializeComponent();
           

            InitializeComponent();
           BindingContext = new UserViewModel(this);

        }

       


        public void Add_Clicked(object sender, EventArgs a)

        {
            this.Navigation.PushAsync(new View.AddUserPage());
        }

    }
}