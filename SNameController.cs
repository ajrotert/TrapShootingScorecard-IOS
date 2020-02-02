using Foundation;
using System;
using UIKit;

namespace AR.TrapScorecard
{
    public partial class SNameController : UIViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ShooterTextBox1.Enabled = false;
            ShooterTextBox2.Enabled = false;
            ShooterTextBox3.Enabled = false;
            ShooterTextBox4.Enabled = false;
            ShooterTextBox5.Enabled = false;

            RB1.Hidden = true;
            RB2.Hidden = true;
            RB3.Hidden = true;
            RB4.Hidden = true;
            RB5.Hidden = true;
            OneLabel.Hidden = true;
            TwoLabel.Hidden = true;
            ThreeLabel.Hidden = true;
            FourLabel.Hidden = true;
            FiveLabel.Hidden = true;

            Update();

            ShooterTextBox1.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
            ShooterTextBox2.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            }; 
            ShooterTextBox3.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            }; 
            ShooterTextBox4.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            }; 
            ShooterTextBox5.ShouldReturn = (textField) => {
                textField.ResignFirstResponder();
                return true;
            };
        }

        public void Update()
        {
            if (ViewController.max == 5)
                AddButton.Hidden = true;

            if (ViewController.max >= 1)
            {
                ShooterTextBox1.Enabled = true;
                RB1.Hidden = false;
                OneLabel.Hidden = false;
            }
            if (ViewController.max >= 2)
            {
                ShooterTextBox2.Enabled = true;
                RB2.Hidden = false;
                TwoLabel.Hidden = false;
            }
            if (ViewController.max >= 3)
            {
                ShooterTextBox3.Enabled = true;
                RB3.Hidden = false;
                ThreeLabel.Hidden = false;
            }
            if (ViewController.max >= 4)
            {
                ShooterTextBox4.Enabled = true;
                RB4.Hidden = false;
                FourLabel.Hidden = false;
            }
            if (ViewController.max >= 5)
            {
                ShooterTextBox5.Enabled = true;
                RB5.Hidden = false;
                FiveLabel.Hidden = false;
            }

        }

        public SNameController(IntPtr handle) : base(handle)
        {
           
        }

        partial void Shooter5_Changed(UITextField sender)
        {
            if (ViewController.shooters[4] == null)
            {
                ViewController.shooters[4] = new Shooter(ShooterTextBox5.Text);
            }
            else if (ShooterTextBox5.Text != "" && ShooterTextBox5.Text != null)
                ViewController.shooters[4].Name = ShooterTextBox5.Text;
            else
                ViewController.shooters[0].Name = "Shooter 5";

        }

        partial void Shooter4_Changed(UITextField sender)
        {
            if (ViewController.shooters[3] == null)
            {
                ViewController.shooters[3] = new Shooter(ShooterTextBox4.Text);
            }
            else if (ShooterTextBox4.Text != "" && ShooterTextBox4.Text != null)
                ViewController.shooters[3].Name = ShooterTextBox4.Text;
            else
                ViewController.shooters[0].Name = "Shooter 4";
        }

        partial void Shooter3_Changed(UITextField sender)
        {
            if (ViewController.shooters[2] == null)
            {
                ViewController.shooters[2] = new Shooter(ShooterTextBox3.Text);
            }
            else if(ShooterTextBox3.Text != "" && ShooterTextBox3.Text != null)
                ViewController.shooters[2].Name = ShooterTextBox3.Text;
            else
                ViewController.shooters[0].Name = "Shooter 3";
        }

        partial void Shooter2_Changed(UITextField sender)
        {
            if (ViewController.shooters[1] == null)
            {
                ViewController.shooters[1] = new Shooter(ShooterTextBox2.Text);
            }
            else if (ShooterTextBox2.Text != "" && ShooterTextBox2.Text != null)
                ViewController.shooters[1].Name = ShooterTextBox2.Text;
            else
                ViewController.shooters[0].Name = "Shooter 2";
        }

        partial void Shooter1_Changed(UITextField sender)
        {
            if (ViewController.shooters[0] == null)
            {
                ViewController.shooters[0] = new Shooter(ShooterTextBox1.Text);
            }
            else if (ShooterTextBox1.Text != "" && ShooterTextBox1.Text != null)
                ViewController.shooters[0].Name = ShooterTextBox1.Text;
            else
                ViewController.shooters[0].Name = "Shooter 1";

        }

        partial void ContinueButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PopViewController(true);
        }

        partial void AddButton_TouchUpInside(UIButton sender)
        {
            int max = ViewController.max;
            ViewController.max = ViewController.max + 1;
            Shooter[] shot = new Shooter[max+1];
            for(int a = 0; a < max; a++)
            {
                shot[a] = ViewController.shooters[a];
            }
            shot[max] = new Shooter("Shooter " + (max+1));

            ViewController.shooters = shot;
            Update();
        }
    }
}