using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

// see strings.xml for italian/french string arrays

namespace RadioBtns_Lists
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spinner;
        RadioGroup radioGrp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            radioGrp = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            var toggleBtn = FindViewById<ToggleButton>(Resource.Id.toggleButton1);
            var layout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

            // switch layout On/Off depneding on toggleBtn
            toggleBtn.CheckedChange += delegate {
                if (toggleBtn.Checked)
                    layout.Visibility = Android.Views.ViewStates.Visible;
                else
                    layout.Visibility = Android.Views.ViewStates.Gone;
            };

            radioGrp.CheckedChange += delegate {
                ChangeList();
            };

            ChangeList(); // call this once initially to populate the spinner list

        }

        void ChangeList() {
            var checkedId = radioGrp.CheckedRadioButtonId;

            ArrayAdapter adapter;

            if(checkedId == Resource.Id.radioBtnItalian) {
                adapter = ArrayAdapter.CreateFromResource(this,
                    Resource.Array.italian, Android.Resource.Layout.SimpleSpinnerItem);
            } else {
                adapter = ArrayAdapter.CreateFromResource(this,
                    Resource.Array.french, Android.Resource.Layout.SimpleSpinnerItem);
            }

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }
    }
}

