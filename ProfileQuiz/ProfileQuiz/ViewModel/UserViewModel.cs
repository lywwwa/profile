using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProfileQuiz.Model;
using ProfileQuiz.View;

using Xamarin.Forms;

namespace ProfileQuiz.ViewModel
{
    class UserViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChangedCallback = PropertyChanged;
            propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveNewUserCommand { get; set; }
     
        ContentPage Page;

       

        private UserInfo _userinfo;
        public UserInfo userinfo
        {
            get
            {
                return _userinfo;
            }

            set
            {
                if (_userinfo != value)
                {
                    _userinfo = value;
                    OnPropertyChanged("userinfo");
                }
            }
        }


       

        private ObservableCollection<UserInfo> _UserList;
        public ObservableCollection<UserInfo> Userlist
        {
            get
            {
                return _UserList;
            }

            set
            {
                if (_UserList != value)
                {
                    _UserList = value;
                    OnPropertyChanged("Userlist");
                }
            }
        }

     

        public UserViewModel(ContentPage page)
        {
            Page = page;
           
            userinfo = new UserInfo();

            RefreshItemList();
            SaveNewUserCommand = new Command<Button>(SaveUser);
 
        }

        public void SaveUser(Button btn)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");

            Database db = new Database(dbPath);

            if (btn.Text.ToLower().Contains("Add User".ToLower()))
            {
               
               //userinfo = new UserInfo();
              Trace.WriteLine("ADDQUAN: " + userinfo.Id + "/" + userinfo.FullName + "/" + userinfo.ProfilePic+"/"+ userinfo.UserName + "/"+ userinfo.UserEmail + "/"+userinfo.CellNo);
               

            }


            db.SaveUserInfoAsync(userinfo);
            RefreshItemList();
            Page.Navigation.PushAsync(new UserListPage());
        }

    
        public async void RefreshItemList()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");

            Database db = new Database(dbPath);
            var list = await db.GetUsersInfoAsync();
           
            Userlist = new ObservableCollection<UserInfo>(list);
        }


       


    }
}
