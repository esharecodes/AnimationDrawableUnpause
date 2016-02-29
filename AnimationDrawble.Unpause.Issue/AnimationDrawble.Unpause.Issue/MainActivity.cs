using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AnimationDrawble.Unpause.Issue
{
    [Activity(Label = "AnimationDrawble.Unpause.Issue", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var imageView = FindViewById<ImageView>(Resource.Id.imgView_animation);
            imageView.SetImageResource(Resource.Drawable.d_animation);

            var startButton = FindViewById<Button>(Resource.Id.btn_start);
            var pauseButton = FindViewById<Button>(Resource.Id.btn_pause);
            var resumeButton = FindViewById<Button>(Resource.Id.btn_resume);

            startButton.Click +=
                (sender, args) => 
                {
                    ((Android.Graphics.Drawables.AnimationDrawable) imageView.Drawable).Start();
                    startButton.Enabled = false;
                    pauseButton.Enabled = true;
                    resumeButton.Enabled = false;
                };

            pauseButton.Click +=
                (sender, args) =>
                {
                    ((Android.Graphics.Drawables.AnimationDrawable) imageView.Drawable).SetVisible(false, false);
                    pauseButton.Enabled = false;
                    resumeButton.Enabled = true;
                };

            resumeButton.Click +=
                (sender, args) =>
                {
                    // http://developer.android.com/reference/android/graphics/drawable/AnimationDrawable.html#setVisible%28boolean,%20boolean%29
                    // SetVisible(visible, restart) - "If restart is false, the animation will resume from the most recent frame."
                    ((Android.Graphics.Drawables.AnimationDrawable) imageView.Drawable).SetVisible(true, false);
                    pauseButton.Enabled = true;
                    resumeButton.Enabled = false;
                };
        }
    }
}

