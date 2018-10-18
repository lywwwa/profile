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
    public class UserViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChangedCallback = PropertyChanged;
            propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SaveNewUserCommand { get; set; }

        public ICommand UpdateUserCommand { get; set; }
        public ICommand RefreshListCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        

        AddUserPage Page;

       

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

        private String _FilePath;
        public String FilePath
        {
            get
            {
                return _FilePath;
            }

            set
            {
                if (_FilePath != value)
                {
                    _FilePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        public UserViewModel(AddUserPage page, UserInfo ui)
        {
            Page = page;
            if (ui == null) userinfo = new UserInfo();
            else userinfo = ui;
            RefreshUserList();
            
            SaveNewUserCommand = new Command(SaveUser);
            RefreshListCommand = new Command(RefreshUserList);
            DeleteUserCommand = new Command(DeleteUser);

        }

        public void SaveUser()
        {
           string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");
           Database db = new Database(dbPath);
            GetImagePath();
            db.SaveUserInfoAsync(userinfo);
            Trace.WriteLine("ADDQUAN: " + userinfo.Id + "/" + userinfo.FullName + "/" + userinfo.ProfilePic + "/" + userinfo.UserName + "/" + userinfo.UserEmail + "/" + userinfo.CellNo + "/" + userinfo.ProfilePic);
            userinfo = new UserInfo();
            RefreshUserList();
            Page.Navigation.PopAsync();
            Page.Navigation.PushAsync(new MainPage());
        }

        public void DeleteUser()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");
            Database db = new Database(dbPath);
            db.DeleteUserInfoAsync(userinfo);
            RefreshUserList();
            Trace.WriteLine("Deleted!!");
            Page.Navigation.PopAsync();
            Page.Navigation.PushAsync(new MainPage());
        }


        public async void RefreshUserList()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DBProfileQuiz.db3");

            Database db = new Database(dbPath);
            var list = await db.GetUsersInfoAsync();

            Userlist = new ObservableCollection<UserInfo>(list);
            if (Userlist == null)
            {
                Trace.WriteLine("NULL??");
            }
            else Trace.WriteLine("NO");


        }
        
        public void GetImagePath()
        {
            userinfo.ProfilePic = Page.FilePath;
        }

    }
}
