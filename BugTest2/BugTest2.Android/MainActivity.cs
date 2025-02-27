﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;

namespace BugTest2.Droid {
	[Activity(Theme = "@style/MainTheme",
			  ConfigurationChanges = ConfigChanges.ScreenSize
								   | ConfigChanges.Orientation
								   | ConfigChanges.UiMode
								   | ConfigChanges.ScreenLayout
								   | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			global::Rg.Plugins.Popup.Popup.Init(this);

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			LoadApplication(new App(new AndroidInitializer()));
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		public override void OnBackPressed() {
			if (true) {
				PopupPlugin.OnBackPressed();
			} else {
				if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed)) {
					// Do something if there are some pages in the `PopupStack`
				} else {
					// Do something if there are not any pages in the `PopupStack`
				}
			}
		}
	}

	public class AndroidInitializer : IPlatformInitializer {
		public void RegisterTypes(IContainerRegistry containerRegistry) {
			// Register any platform specific implementations
		}
	}
}

