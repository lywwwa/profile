using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using ProfileQuiz.ViewModel;
using ProfileQuiz.Model;
using System.Diagnostics;

namespace ProfileQuiz.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddUserPage : ContentPage
	{
        UserInfo userInfo;
        public string FilePath;
        //string path;
		public AddUserPage (UserInfo UI)
		{
            userInfo = UI;
			InitializeComponent ();
            BindingContext = new UserViewModel(this, userInfo);
            if (userInfo != null)
            {
                UserButton.Text = "Update User";
                DeleteUserButton.IsVisible = true;
            }
        }

        public async void OnActionSheetSimpleClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("", "Cancel", null, "Take Photo", "Pick Photo");
           // Debug.WriteLine("Action: " + action);
            PhotoAction(action);

        }

      

        public async void PhotoAction(string _action)
        {
            await CrossMedia.Current.Initialize();

            if (_action.Equals("Take Photo"))
            {

                //cant take pic
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                Trace.WriteLine("HMM0");
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                   
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                    CustomPhotoSize = 90, 
                    Directory = "Sample",
                    Name = "test.jpg",
                   
                });
                Trace.WriteLine("HMM");
                if (file == null)
                    return;

              //  await DisplayAlert("File Location", file.Path.ToString(), "OK");
                FilePath = file.Path.ToString();
                Image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                   // path= file.ToString();//
                    file.Dispose();
                    return stream;
                });

             //   getImageSource(path);
            }

            else if (_action.Equals("Pick Photo"))
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {

                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                    CustomPhotoSize = 90,

                });


                if (file == null)
                    return;

                FilePath = file.Path.ToString();
                Image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                 
                    file.Dispose();
                    return stream;
                });
               
            }
        }
    }
}