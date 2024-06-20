using System;
using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Widget;

namespace Xamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button;
        private TextView textView;
        private EditText editText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            button = FindViewById<Button>(Resource.Id.button);
            textView = FindViewById<TextView>(Resource.Id.textView2);
            editText = FindViewById<EditText>(Resource.Id.editTextTextPersonName);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Отримання коефіцієнтів з текстового поля
            string input = editText.Text;
            string[] parts = input.Split(',');

            if (parts.Length != 3)
            {
                textView.Text = "Неправильний формат введення. Спробуйте a=1, b=2, c=3.";
                return;
            }

            double a, b, c;

            try
            {
                a = double.Parse(parts[0].Split('=')[1]);
                b = double.Parse(parts[1].Split('=')[1]);
                c = double.Parse(parts[2].Split('=')[1]);
            }
            catch (FormatException)
            {
                textView.Text = "Неправильний формат введення. Спробуйте a=1, b=2, c=3.";
                return;
            }

            // Вирішення квадратного рівняння
            double discriminant = b * b - 4.0 * a * c;

            if (discriminant < 0)
            {
                textView.Text = "Рівняння не має дійсних коренів.";
            }
            else
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2.0 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2.0 * a);

                textView.Text = "x1 = " + x1.ToString("F2") + ", x2 = " + x2.ToString("F2");
            }
        }
    }
}
