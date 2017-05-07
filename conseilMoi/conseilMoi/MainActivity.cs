using Android.App;
using Android.Widget;
using Android.OS;
using conseilMoi.Resources.MaBase;

namespace conseilMoi
{
    [Activity(Label = "conseilMoi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            MaBase db = new MaBase();
            db.ExistBase();
            db.ConnexionOpen();
            db.ConnexionClose();


            StartActivity(typeof(Profil));
            //SetContentView (Resource.Layout.Avertissement);
        }
    }
}

