using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace CalcSmall_App
{
    class Client
    {
        private HttpClient client;
        private string uri;

        public Client()
        {
            client = new HttpClient();
           // uri = @"http://localhost:8888/";
            uri = "http://192.168.0.118:9050/";
          
        }

        public int RequestCalcResultAsync(int a, int b, char op)
        {
            try
            {
                string temp = uri + "?a=" + a + "&b=" + b + "&op=" + op;
                string response = client.GetStringAsync(temp).Result;
                return int.Parse(response);
            }
            catch (AggregateException e)
            {
                return 0;
            }
          
        }
    }
}