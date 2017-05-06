using Android.App;
using Android.Widget;
using Android.OS;

namespace conseilMoi
{
    [Activity(Label = "conseilMoi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            StartActivity(typeof(Avertissement));
            //SetContentView (Resource.Layout.Avertissement);
        }
    }
}

