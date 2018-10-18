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

namespace ProfileQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");
            var db = new SQLiteConnection(dbPath);
            Trace.WriteLine("DB File located at: " + dbPath);
        }

        public void AddUser_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
            this.Navigation.PushAsync(new View.AddUserPage(null));
        }

        public void Users_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
            this.Navigation.PushAsync(new View.UserListPage());
        }
    }
}
