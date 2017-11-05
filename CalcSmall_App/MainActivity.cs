using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CalcSmall_App
{
    [Activity(Label = "CalcSmall_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnRes;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnRes = FindViewById<Button>(Resource.Id.btnRes);
            btnRes.Click += btnRes_Click;
        }
        void btnRes_Click(object sender, EventArgs e)
        {
            EditText textA = FindViewById<EditText>(Resource.Id.textA);
            EditText textB = FindViewById<EditText>(Resource.Id.textB);
            EditText textOp = FindViewById<EditText>(Resource.Id.textOp);
            EditText textRes = FindViewById<EditText>(Resource.Id.textRes);

            int a = int.Parse(textA.Text);
            int b = int.Parse(textB.Text);
            char op = char.Parse(textOp.Text);

            Client client = new Client();
            int res = client.RequestCalcResultAsync(a, b, op);
            

            textRes.Text = res.ToString();
        }
        
    }
}

