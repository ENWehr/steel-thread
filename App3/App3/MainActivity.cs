using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Text;

namespace App3
{
    [Activity(Label = "App3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnSend;
        private EditText editTextPost;
        private string editTextString;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //var activity = this.ApplicationContext as Activity;
            //activity.SetContentView(Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);

            btnSend = FindViewById<Button>(Resource.Id.btnSendToAzure);
            editTextPost = FindViewById<EditText>(Resource.Id.editTextToAzure);

        }

        protected override void OnStart()
        {
            base.OnStart();

            btnSend.Click += Send_OnClick;
        }

        protected override void OnStop()
        {
            

            btnSend.Click -= Send_OnClick;
            base.OnStop();
        }


        private void Send_OnClick(object sender, EventArgs e)
        {
            editTextString = editTextPost.Text;
            using (HttpClient client = new HttpClient())
            {
                var url = "https://evanproject.azurewebsites.net/api/EvanThread?code=BMZ3aZoCmkQ4nxGoBqj/fBvgnEZ99zO2oL26TNDymXnpz018hT3zqQ==";
                                                      //string passed, encoding (how its read), format
                var postContent = new StringContent("{passedString:'" + editTextString + "'}", Encoding.UTF8, "application/json");
                client.PostAsync(new Uri(url), postContent).Result.EnsureSuccessStatusCode();
            }
        }   
    }  
}

