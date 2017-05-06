using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace conseilMoi
{
    [Activity(Label = "Produit")]
    public class Produit : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Produit);


            string IDproduit = Intent.GetStringExtra("IDproduit") ?? "Data not available";
        }
        
    }
}