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
    [Activity(Label = "Produit")]
    public class Produit : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Produit);


            SetContentView(Resource.Layout.Produit);

            MobileBarcodeScanner.Initialize(Application);
            //Récupère le ID_Produit
            string IDproduit = Intent.GetStringExtra("IDproduit") ?? "Data not available";


            var menuProfil = FindViewById<ImageView>(Resource.Id.imageViewProduitProfil);
            var menuHistorique = FindViewById<ImageView>(Resource.Id.imageViewProduitHistorique);
            var menuScanner = FindViewById<ImageView>(Resource.Id.imageViewProduitScann);
            var menuConseil = FindViewById<ImageView>(Resource.Id.imageViewProduitConseil);
            var menuAvertissement = FindViewById<ImageView>(Resource.Id.imageViewProduitAvertissement);


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

            //Clik sur le bouton scanner
            menuScanner.Click += async (sender, e) =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {
                    //Intent garde la variable ID Produit et la transmet à l'activité Produit
                    Intent produit = new Intent(this, typeof(Produit));
                    produit.PutExtra("IDproduit", result.Text);
                    StartActivity(produit);
                }
                else { }
            };

            menuAvertissement.Click += delegate
            {
                StartActivity(typeof(Avertissement));
            };
        }
        
    }
}