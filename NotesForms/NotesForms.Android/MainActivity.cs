using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using NotesForms.Droid.Services;
using NotesForms.Services;
using Xamarin.Essentials;

namespace NotesForms.Droid
{
    [Activity(
        Theme = "@style/MainTheme",
        MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize |
            ConfigChanges.Orientation |
            ConfigChanges.UiMode      |
            ConfigChanges.ScreenLayout|
            ConfigChanges.SmallestScreenSize
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var dialer      = new PhoneDialerService();
            var smsSender   = new SMSService();
            var textSpeaker = new TextToSpeechService();
            var emailSender = new EmailService();

            dialer.Context      = this;
            smsSender.Context   = this;
            textSpeaker.Context = this;
            emailSender.Context = this;

            DependencyService.RegisterSingleton<IPhoneDialer>(dialer);
            DependencyService.RegisterSingleton<ISMS>(smsSender);
            DependencyService.RegisterSingleton<ITextToSpeech>(textSpeaker);
            DependencyService.RegisterSingleton<IEmail>(emailSender);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
