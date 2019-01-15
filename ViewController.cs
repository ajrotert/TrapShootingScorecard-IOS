using System;

using UIKit;

namespace AR.TrapScorecard
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public Shooter[] shooters;
        UITextField NameInputTextBox = new UITextField();
        int current = 0;
        int pos = 0;
        int max;
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            HitButton.Enabled = false;
            MissButton.Enabled = false;
            PauseButton.Enabled = false;

            // Perform any additional setup after loading the view, typically from a nib.
        }  

        partial void Pause_Clicked(UIButton sender)
        {
            if(!HitButton.Enabled)
            {
                HitButton.Enabled = true;
                MissButton.Enabled = true;
                PauseButton.SetTitle("Pause", UIControlState.Normal);
            }
            else
            {
                HitButton.Enabled = false;
                MissButton.Enabled = false;
                PauseButton.SetTitle("Resume", UIControlState.Normal);
            }
        }

        partial void Start_Clicked(UIButton sender)
        { 
            max = Convert.ToInt32(NumberOfShooterSlider.Value);
            shooters = new Shooter[max];
            NumberOfShooterSlider.Enabled = false;
            for (int a = 0; a < max; a++)
            {
                shooters[a] = new Shooter("Tesing Development");
            }
            StartButton.Enabled = false;
            PauseButton.Enabled = true;
            MissButton.Enabled = true;
            HitButton.Enabled = true;
        }
        public void GetText(string title, string message)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = title,
                //Title = "Enter the shooters names",
                Message = message
            };
            //alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;

            //NameInputTextBox = alert.GetTextField(0);
            //alert.Clicked += delegate (object s, UIButtonEventArgs e)
            //{
                //test = getTexField(0).Text//doesn't set text until the button is clicked, does not reutrn anything
            //};
            alert.AddButton("OK");
            alert.Show();
        }

        partial void Slider_Changed(UISlider sender)
        {
            NumberOfShooterSlider.Value = (float)Math.Floor(NumberOfShooterSlider.Value);
            NumShootersLabel.Text = "Shooters: " + NumberOfShooterSlider.Value.ToString();
        }

        partial void Hit_Clicked(UIButton sender)
        {
            shooters[pos].UpdateScore(true); //Shooter.Current
            Update();
        }

        partial void Miss_Clicked(UIButton sender)
        {
            shooters[pos].UpdateScore(false);
            Update();
        }
        public void Update()
        {
            if (current == (max * 25) -1)
            {
                End();
            }
            else
            {
                if (current % (max * 5) == 0 && current != 0)
                    GetText("Rotate", null);
                pos++;
                current++;
                if (pos == max)
                    pos = 0;
            }
        }
        public void End()
        {
            HitButton.Enabled = false;
            MissButton.Enabled = false;
            PauseButton.Enabled = false;

            string message = "";
            string title = "Shooter:\t\tScore:";
            for(int a =0; a<max; a++)
            {
                message += "\n" + shooters[a].Name + "\t\t" + shooters[a].GetTotal().ToString();
            }
            GetText(title, message);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
