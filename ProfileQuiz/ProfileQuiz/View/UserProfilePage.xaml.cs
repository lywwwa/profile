using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;
using System.Diagnostics;
using Plugin.Media;
using ProfileQuiz.ViewModel;
using ProfileQuiz.Model;

namespace ProfileQuiz.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfilePage : ContentPage
	{
		public UserProfilePage()
		{
			InitializeComponent ();
            BindingContext = new UserViewModel(null, null);
        }

      

        public void Edit_Clicked(object sender, EventArgs a)

        {
            //change photo
        }

        public void Delete_Clicked(object sender, EventArgs a)

        {
            //change photo
        }

/*        public async void PhotoAction(string _action)
        {

            if (_action.Equals("Take Photo"))
            {
                
                //cant take pic
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    AllowCropping = true,
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");

                Image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }

            else if(_action.Equals("Pick Photo"))
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });


                    if (file == null)
                        return;

                    Image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }
            }*/
        }
    }
