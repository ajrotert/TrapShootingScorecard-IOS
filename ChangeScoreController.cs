using Foundation;
using System;
using UIKit;

namespace AR.TrapScorecard
{
    public partial class ChangeScoreController : UIViewController
    {
        public ChangeScoreController (IntPtr handle) : base (handle)
        {
        }
        public int max;
        public Shooter[] shooters;
        public override void ViewDidLoad()
        {
            max = ViewController.max;
            shooters = ViewController.shooters;
            base.ViewDidLoad();
            if (max < 5)
            {
                Current5Label.Hidden = true;
                S5Label.Hidden = true;
                S5S1.Hidden = true;
                S5S2.Hidden = true;
                S5S3.Hidden = true;
                S5S4.Hidden = true;
                S5S5.Hidden = true;
                if (max < 4)
                {
                    Current4Label.Hidden = true;
                    S4Label.Hidden = true;
                    S4S1.Hidden = true;
                    S4S2.Hidden = true;
                    S4S3.Hidden = true;
                    S4S4.Hidden = true;
                    S4S5.Hidden = true;
                    if (max < 3)
                    {
                        Current3Label.Hidden = true;
                        S3Label.Hidden = true;
                        S3S1.Hidden = true;
                        S3S2.Hidden = true;
                        S3S3.Hidden = true;
                        S3S4.Hidden = true;
                        S3S5.Hidden = true;
                        if (max < 2)
                        {
                            Current2Label.Hidden = true;
                            S2Label.Hidden = true;
                            S2S1.Hidden = true;
                            S2S2.Hidden = true;
                            S2S3.Hidden = true;
                            S2S4.Hidden = true;
                            S2S5.Hidden = true;
                            S1Label.Text = shooters[0].Name;
                        }
                        else
                        {
                            S1Label.Text = shooters[0].Name;
                            S2Label.Text = shooters[1].Name;
                        }
                    }
                    else
                    {
                        S1Label.Text = shooters[0].Name;
                        S2Label.Text = shooters[1].Name;
                        S3Label.Text = shooters[2].Name;
                    }
                }
                else
                {
                    S1Label.Text = shooters[0].Name;
                    S2Label.Text = shooters[1].Name;
                    S3Label.Text = shooters[2].Name;
                    S4Label.Text = shooters[3].Name;
                }
            }
            else
            {
                S1Label.Text = shooters[0].Name;
                S2Label.Text = shooters[1].Name;
                S3Label.Text = shooters[2].Name;
                S4Label.Text = shooters[3].Name;
                S5Label.Text = shooters[4].Name;
            }

            //...
            UpdateScreen();

                //....

        }
        public string[] images = { "MissClay.png", "HitClay.png", "Blank.png" };

        public void UpdateScreen()
        {
            Current1Label.Text = "Current Score:" + Environment.NewLine + shooters[0].GetStandingTotal();
            S1S1.SetBackgroundImage(UIImage.FromFile(images[shooters[0].StandingRound[0]]), UIControlState.Normal);
            S1S2.SetBackgroundImage(UIImage.FromFile(images[shooters[0].StandingRound[1]]), UIControlState.Normal);
            S1S3.SetBackgroundImage(UIImage.FromFile(images[shooters[0].StandingRound[2]]), UIControlState.Normal);
            S1S4.SetBackgroundImage(UIImage.FromFile(images[shooters[0].StandingRound[3]]), UIControlState.Normal);
            S1S5.SetBackgroundImage(UIImage.FromFile(images[shooters[0].StandingRound[4]]), UIControlState.Normal);

            if (max > 1)
            {
                Current2Label.Text = "Current Score:" + Environment.NewLine + shooters[1].GetStandingTotal();
                S2S1.SetBackgroundImage(UIImage.FromFile(images[shooters[1].StandingRound[0]]), UIControlState.Normal);
                S2S2.SetBackgroundImage(UIImage.FromFile(images[shooters[1].StandingRound[1]]), UIControlState.Normal);
                S2S3.SetBackgroundImage(UIImage.FromFile(images[shooters[1].StandingRound[2]]), UIControlState.Normal);
                S2S4.SetBackgroundImage(UIImage.FromFile(images[shooters[1].StandingRound[3]]), UIControlState.Normal);
                S2S5.SetBackgroundImage(UIImage.FromFile(images[shooters[1].StandingRound[4]]), UIControlState.Normal);
                if (max > 2)
                {
                    Current3Label.Text = "Current Score:" + Environment.NewLine + shooters[2].GetStandingTotal();
                    S3S1.SetBackgroundImage(UIImage.FromFile(images[shooters[2].StandingRound[0]]), UIControlState.Normal);
                    S3S2.SetBackgroundImage(UIImage.FromFile(images[shooters[2].StandingRound[1]]), UIControlState.Normal);
                    S3S3.SetBackgroundImage(UIImage.FromFile(images[shooters[2].StandingRound[2]]), UIControlState.Normal);
                    S3S4.SetBackgroundImage(UIImage.FromFile(images[shooters[2].StandingRound[3]]), UIControlState.Normal);
                    S3S5.SetBackgroundImage(UIImage.FromFile(images[shooters[2].StandingRound[4]]), UIControlState.Normal);
                    if (max > 3)
                    {
                        Current4Label.Text = "Current Score:" + Environment.NewLine + shooters[3].GetStandingTotal();
                        S4S1.SetBackgroundImage(UIImage.FromFile(images[shooters[3].StandingRound[0]]), UIControlState.Normal);
                        S4S2.SetBackgroundImage(UIImage.FromFile(images[shooters[3].StandingRound[1]]), UIControlState.Normal);
                        S4S3.SetBackgroundImage(UIImage.FromFile(images[shooters[3].StandingRound[2]]), UIControlState.Normal);
                        S4S4.SetBackgroundImage(UIImage.FromFile(images[shooters[3].StandingRound[3]]), UIControlState.Normal);
                        S4S5.SetBackgroundImage(UIImage.FromFile(images[shooters[3].StandingRound[4]]), UIControlState.Normal);
                        if (max > 4)
                        {
                            Current5Label.Text = "Current Score:" + Environment.NewLine + shooters[4].GetStandingTotal();
                            S5S1.SetBackgroundImage(UIImage.FromFile(images[shooters[4].StandingRound[0]]), UIControlState.Normal);
                            S5S2.SetBackgroundImage(UIImage.FromFile(images[shooters[4].StandingRound[1]]), UIControlState.Normal);
                            S5S3.SetBackgroundImage(UIImage.FromFile(images[shooters[4].StandingRound[2]]), UIControlState.Normal);
                            S5S4.SetBackgroundImage(UIImage.FromFile(images[shooters[4].StandingRound[3]]), UIControlState.Normal);
                            S5S5.SetBackgroundImage(UIImage.FromFile(images[shooters[4].StandingRound[4]]), UIControlState.Normal);
                        }
                    }
                }
            }
        }

        partial void S5S5_TouchUpInside(UIButton sender)
        {
            if (shooters[4].StandingRound[4] != 2)
            {
                if (shooters[4].StandingRound[4] == 0)
                {
                    shooters[4].StandingRound[4] = 1;
                    shooters[4].UpdateScoresFromRound();
                }
                else if (shooters[4].StandingRound[4] == 1)
                {
                    shooters[4].StandingRound[4] = 0;
                    shooters[4].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S5S4_TouchUpInside(UIButton sender)
        {
            if (shooters[4].StandingRound[3] != 2)
            {
                if (shooters[4].StandingRound[3] == 0)
                {
                    shooters[4].StandingRound[3] = 1;
                    shooters[4].UpdateScoresFromRound();
                }
                else if (shooters[4].StandingRound[3] == 1)
                {
                    shooters[4].StandingRound[3] = 0;
                    shooters[4].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S5S3_TouchUpInside(UIButton sender)
        {
            if (shooters[4].StandingRound[2] != 2)
            {
                if (shooters[4].StandingRound[2] == 0)
                {
                    shooters[4].StandingRound[2] = 1;
                    shooters[4].UpdateScoresFromRound();
                }
                else if (shooters[4].StandingRound[2] == 1)
                {
                    shooters[4].StandingRound[2] = 0;
                    shooters[4].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S5S2_TouchUpInside(UIButton sender)
        {
            if (shooters[4].StandingRound[1] != 2)
            {
                if (shooters[4].StandingRound[1] == 0)
                {
                    shooters[4].StandingRound[1] = 1;
                    shooters[4].UpdateScoresFromRound();
                }
                else if (shooters[4].StandingRound[1] == 1)
                {
                    shooters[4].StandingRound[1] = 0;
                    shooters[4].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S5S1_TouchUpInside(UIButton sender)
        {
            if (shooters[4].StandingRound[0] != 2)
            {
                if (shooters[4].StandingRound[0] == 0)
                {
                    shooters[4].StandingRound[0] = 1;
                    shooters[4].UpdateScoresFromRound();
                }
                else if (shooters[4].StandingRound[0] == 1)
                {
                    shooters[4].StandingRound[0] = 0;
                    shooters[4].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S4S5_TouchUpInside(UIButton sender)
        {
            if (shooters[3].StandingRound[4] != 2)
            {
                if (shooters[3].StandingRound[4] == 0)
                {
                    shooters[3].StandingRound[4] = 1;
                    shooters[3].UpdateScoresFromRound();
                }
                else if (shooters[3].StandingRound[4] == 1)
                {
                    shooters[3].StandingRound[4] = 0;
                    shooters[3].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S4S4_TouchUpInside(UIButton sender)
        {
            if (shooters[3].StandingRound[3] != 2)
            {
                if (shooters[3].StandingRound[3] == 0)
                {
                    shooters[3].StandingRound[3] = 1;
                    shooters[3].UpdateScoresFromRound();
                }
                else if (shooters[3].StandingRound[3] == 1)
                {
                    shooters[3].StandingRound[3] = 0;
                    shooters[3].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S4S3_TouchUpInside(UIButton sender)
        {
            if (shooters[3].StandingRound[2] != 2)
            {
                if (shooters[3].StandingRound[2] == 0)
                {
                    shooters[3].StandingRound[2] = 1;
                    shooters[3].UpdateScoresFromRound();
                }
                else if (shooters[3].StandingRound[2] == 1)
                {
                    shooters[3].StandingRound[2] = 0;
                    shooters[3].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S4S2_TouchUpInside(UIButton sender)
        {
            if (shooters[3].StandingRound[1] != 2)
            {
                if (shooters[3].StandingRound[1] == 0)
                {
                    shooters[3].StandingRound[1] = 1;
                    shooters[3].UpdateScoresFromRound();
                }
                else if (shooters[3].StandingRound[1] == 1)
                {
                    shooters[3].StandingRound[1] = 0;
                    shooters[3].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S4S1_TouchUpInside(UIButton sender)
        {
            if (shooters[3].StandingRound[0] != 2)
            {
                if (shooters[3].StandingRound[0] == 0)
                {
                    shooters[3].StandingRound[0] = 1;
                    shooters[3].UpdateScoresFromRound();
                }
                else if (shooters[3].StandingRound[0] == 1)
                {
                    shooters[3].StandingRound[0] = 0;
                    shooters[3].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S3S5_TouchUpInside(UIButton sender)
        {
            if (shooters[2].StandingRound[4] != 2)
            {
                if (shooters[2].StandingRound[4] == 0)
                {
                    shooters[2].StandingRound[4] = 1;
                    shooters[2].UpdateScoresFromRound();
                }
                else if (shooters[2].StandingRound[4] == 1)
                {
                    shooters[2].StandingRound[4] = 0;
                    shooters[2].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S3S4_TouchUpInside(UIButton sender)
        {
            if (shooters[2].StandingRound[3] != 2)
            {
                if (shooters[2].StandingRound[3] == 0)
                {
                    shooters[2].StandingRound[3] = 1;
                    shooters[2].UpdateScoresFromRound();
                }
                else if (shooters[2].StandingRound[3] == 1)
                {
                    shooters[2].StandingRound[3] = 0;
                    shooters[2].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S3S3_TouchUpInside(UIButton sender)
        {
            if (shooters[2].StandingRound[2] != 2)
            {
                if (shooters[2].StandingRound[2] == 0)
                {
                    shooters[2].StandingRound[2] = 1;
                    shooters[2].UpdateScoresFromRound();
                }
                else if (shooters[2].StandingRound[2] == 1)
                {
                    shooters[2].StandingRound[2] = 0;
                    shooters[2].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S3S2_TouchUpInside(UIButton sender)
        {
            if (shooters[2].StandingRound[1] != 2)
            {
                if (shooters[2].StandingRound[1] == 0)
                {
                    shooters[2].StandingRound[1] = 1;
                    shooters[2].UpdateScoresFromRound();
                }
                else if (shooters[2].StandingRound[1] == 1)
                {
                    shooters[2].StandingRound[1] = 0;
                    shooters[2].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S3S1_TouchUpInside(UIButton sender)
        {
            if (shooters[2].StandingRound[0] != 2)
            {
                if (shooters[2].StandingRound[0] == 0)
                {
                    shooters[2].StandingRound[0] = 1;
                    shooters[2].UpdateScoresFromRound();
                }
                else if (shooters[2].StandingRound[0] == 1)
                {
                    shooters[2].StandingRound[0] = 0;
                    shooters[2].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S2S5_TouchUpInside(UIButton sender)
        {
            if (shooters[1].StandingRound[4] != 2)
            {
                if (shooters[1].StandingRound[4] == 0)
                {
                    shooters[1].StandingRound[4] = 1;
                    shooters[1].UpdateScoresFromRound();
                }
                else if (shooters[1].StandingRound[4] == 1)
                {
                    shooters[1].StandingRound[4] = 0;
                    shooters[1].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S2S4_TouchUpInside(UIButton sender)
        {
            if (shooters[1].StandingRound[3] != 2)
            {
                if (shooters[1].StandingRound[3] == 0)
                {
                    shooters[1].StandingRound[3] = 1;
                    shooters[1].UpdateScoresFromRound();
                }
                else if (shooters[1].StandingRound[3] == 1)
                {
                    shooters[1].StandingRound[3] = 0;
                    shooters[1].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S2S3_TouchUpInside(UIButton sender)
        {
            if (shooters[1].StandingRound[2] != 2)
            {
                if (shooters[1].StandingRound[2] == 0)
                {
                    shooters[1].StandingRound[2] = 1;
                    shooters[1].UpdateScoresFromRound();
                }
                else if (shooters[1].StandingRound[2] == 1)
                {
                    shooters[1].StandingRound[2] = 0;
                    shooters[1].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S2S2_TouchUpInside(UIButton sender)
        {
            if (shooters[1].StandingRound[1] != 2)
            {
                if (shooters[1].StandingRound[1] == 0)
                {
                    shooters[1].StandingRound[1] = 1;
                    shooters[1].UpdateScoresFromRound();
                }
                else if (shooters[1].StandingRound[1] == 1)
                {
                    shooters[1].StandingRound[1] = 0;
                    shooters[1].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S2S1_TouchUpInside(UIButton sender)
        {
            if (shooters[1].StandingRound[0] != 2)
            {
                if (shooters[1].StandingRound[0] == 0)
                {
                    shooters[1].StandingRound[0] = 1;
                    shooters[1].UpdateScoresFromRound();
                }
                else if (shooters[1].StandingRound[0] == 1)
                {
                    shooters[1].StandingRound[0] = 0;
                    shooters[1].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S1S5_TouchUpInside(UIButton sender)
        {
            if (shooters[0].StandingRound[4] != 2)
            {
                if (shooters[0].StandingRound[4] == 0)
                {
                    shooters[0].StandingRound[4] = 1;
                    shooters[0].UpdateScoresFromRound();
                }
                else if (shooters[0].StandingRound[4] == 1)
                {
                    shooters[0].StandingRound[4] = 0;
                    shooters[0].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S1S4_TouchUpInside(UIButton sender)
        {
            if (shooters[0].StandingRound[3] != 2)
            {
                if (shooters[0].StandingRound[3] == 0)
                {
                    shooters[0].StandingRound[3] = 1;
                    shooters[0].UpdateScoresFromRound();
                }
                else if (shooters[0].StandingRound[3] == 1)
                {
                    shooters[0].StandingRound[3] = 0;
                    shooters[0].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S1S3_TouchUpInside(UIButton sender)
        {
            if (shooters[0].StandingRound[2] != 2)
            {
                if (shooters[0].StandingRound[2] == 0)
                {
                    shooters[0].StandingRound[2] = 1;
                    shooters[0].UpdateScoresFromRound();
                }
                else if (shooters[0].StandingRound[2] == 1)
                {
                    shooters[0].StandingRound[2] = 0;
                    shooters[0].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S1S2_TouchUpInside(UIButton sender)
        {
            if (shooters[0].StandingRound[1] != 2)
            {
                if (shooters[0].StandingRound[1] == 0)
                {
                    shooters[0].StandingRound[1] = 1;
                    shooters[0].UpdateScoresFromRound();
                }
                else if (shooters[0].StandingRound[1] == 1)
                {
                    shooters[0].StandingRound[1] = 0;
                    shooters[0].UpdateScoresFromRound();
                }
                UpdateScreen();
            }
        }

        partial void S1S1_TouchUpInside(UIButton sender)
        {
            if (shooters[0].StandingRound[0] != 2)
            {
                if (shooters[0].StandingRound[0] == 0)
                {
                    shooters[0].StandingRound[0] = 1;
                    shooters[0].UpdateScoresFromRound();
                }
                else if(shooters[0].StandingRound[0] == 1)
                {
                    shooters[0].StandingRound[0] = 0;
                    shooters[0].UpdateScoresFromRound();
                }
                UpdateScreen();
            }

        }

        partial void BackButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PopViewController(true);
        }
    }
}