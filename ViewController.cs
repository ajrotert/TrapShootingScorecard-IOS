using System;
using Foundation;
using UIKit;

namespace AR.TrapScorecard
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public static Shooter[] shooters;
        //UITextField NameInputTextBox = new UITextField();
        int current = 0;
        int pos = 0;
        public static int max;
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            /*for (int a = 0; a < 5; a++)
            {
                shooters[a] = new Shooter("Shooter " + (a + 1).ToString());
            }*/
            // HitButton.Enabled = false;
            // MissButton.Enabled = false;
            // PauseButton.Enabled = false;

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
                //if(shooters[a] != null && (shooters[a].Name == "" || shooters[a].Name==""))
                    shooters[a] = new Shooter("Shooter " + (a+1).ToString());
            }
            StartButton.Enabled = false;
            PauseButton.Enabled = true;
            MissButton.Enabled = true;
            HitButton.Enabled = true;
            UpdateBoxes();
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
            if(NumberOfShooterSlider.Value == 1)
            {
                RedBox1.Hidden = false;
                RedBox2.Hidden = true;
                RedBox3.Hidden = true;
                RedBox4.Hidden = true;
                RedBox5.Hidden = true;

            }
            else if (NumberOfShooterSlider.Value == 2)
            {
                RedBox1.Hidden = false;
                RedBox2.Hidden = false;
                RedBox3.Hidden = true;
                RedBox4.Hidden = true;
                RedBox5.Hidden = true;
            }
            else if (NumberOfShooterSlider.Value == 3)
            {
                RedBox1.Hidden = false;
                RedBox2.Hidden = false;
                RedBox3.Hidden = false;
                RedBox4.Hidden = true;
                RedBox5.Hidden = true;
            }
            else if (NumberOfShooterSlider.Value == 4)
            {
                RedBox1.Hidden = false;
                RedBox2.Hidden = false;
                RedBox3.Hidden = false;
                RedBox4.Hidden = false;
                RedBox5.Hidden = true;
            }
            else if (NumberOfShooterSlider.Value == 5)
            {
                RedBox1.Hidden = false;
                RedBox2.Hidden = false;
                RedBox3.Hidden = false;
                RedBox4.Hidden = false;
                RedBox5.Hidden = false;
            }
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
                pos++;
                current++;
                if (current % (max * 5) == 0 && current != 0)
                    GetText("Rotate", null);
                if (pos == max)
                    pos = 0;
                UpdateBoxes();
            }
        }

        public void UpdateBoxes()
        {
            RedBox1.Hidden = true;
            RedBox2.Hidden = true;
            RedBox3.Hidden = true;
            RedBox4.Hidden = true;
            RedBox5.Hidden = true;
                if ((pos+current / (5*max)) % 5 == 0)
                    RedBox1.Hidden = false;
                else if ((pos+current / (5 * max)) % 5 == 1)
                    RedBox2.Hidden = false;
                else if ((pos+current / (5 * max)) % 5 == 2)
                    RedBox3.Hidden = false;
                else if ((pos+current / (5 * max)) % 5 == 3)
                    RedBox4.Hidden = false;
                else if ((pos+current / (5 * max)) % 5 == 4)
                    RedBox5.Hidden = false;

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
                message += Environment.NewLine + shooters[a].Name + "\t\t" + shooters[a].GetTotal().ToString();
            }
            GetText(title, message);
            StartButton.Enabled = true;
            NumberOfShooterSlider.Enabled = true;
            current = 0;
            pos = 0;


        }

        /* public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var sNameController = segue.DestinationViewController as SNameController;

            if (sNameController != null)
            { }
        }*/
        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {

            if (segueIdentifier == "SegueToResults" || segueIdentifier == "SegueToResults2")
            {
                if (!HitButton.Enabled || !MissButton.Enabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
