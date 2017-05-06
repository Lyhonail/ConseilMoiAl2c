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
    [Activity(Label = "Avertissement")]
    public class Avertissement : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Avertissement);

            var menuProfil = FindViewById<ImageView>(Resource.Id.imageViewAvertissementProfil);
            var menuHistorique = FindViewById<ImageView>(Resource.Id.imageViewAvertissementHistorique);
            var menuScanner = FindViewById<ImageView>(Resource.Id.imageViewAvertissementScann);
            var menuConseil = FindViewById<ImageView>(Resource.Id.imageViewAvertissementConseil);
            var menuAvertissement = FindViewById<ImageView>(Resource.Id.imageViewAvertissementAvertissement);

           


            menuProfil.Click += delegate
            {
                StartActivity(typeof(Profil));
            };
            menuHistorique.Click += delegate
            {
                StartActivity(typeof(Historique));
            };
            menuScanner.Click += delegate
            {
                StartActivity(typeof(Produit));
            };
            menuConseil.Click += delegate
            {
                StartActivity(typeof(Conseil));
            };
        





        }
    }
}