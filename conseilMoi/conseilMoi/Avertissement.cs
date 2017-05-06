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
using ZXing.Mobile;

namespace conseilMoi
{
    [Activity(Label = "Avertissement")]
    public class Avertissement : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Avertissement);
            MobileBarcodeScanner.Initialize(Application);

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
            


            menuConseil.Click += delegate
            {
                StartActivity(typeof(Conseil));
            };

            menuScanner.Click += async (sender, e) =>
            {

                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                {
                    Intent produit = new Intent(this, typeof(Produit));
                    produit.PutExtra("IDproduit", result.Text);
                    StartActivity(produit);
                }
                else { }
            };








        }
    }
}