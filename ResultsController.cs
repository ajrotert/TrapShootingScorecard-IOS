using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace AR.TrapScorecard
{
    public partial class ResultsController : UIViewController
    {
        public ResultsController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //ResultsLabel.Transform = CGAffineTransform.MakeRotation((float)(Math.PI/180 * 90));
            ShooterScoresLabel.Text = "";
            max = ViewController.max;
            shooters = ViewController.shooters;
            //Eventually this will need to store the total score in a database
            for (int a = 0; a<max;a++)
            {
                ShooterScoresLabel.Text += shooters[a].Name + "\t" + shooters[a].GetTotal().ToString()+Environment.NewLine;
                DatabaseManagement.Add(shooters[a].Name, shooters[a].GetTotal(), DateTime.Now);
            }
            FillLabel();
        }
        public int max;
        public Shooter[] shooters;
        /*public void FillLabel()
        {
            ResultsLabel.Text = "";
            for(int a = 0; a < ViewController.max; a++)
            {
                ResultsLabel.Text += ViewController.shooters[a].Name + ":\t|";
                for(int b = 0; b<ViewController.shooters[a].score.Length; b++)
                {
                    if (ViewController.shooters[a].score[b] == 0)
                        ResultsLabel.Text += " O |";
                    else if (ViewController.shooters[a].score[b] == 1)
                        ResultsLabel.Text += " X |";
                }
                ResultsLabel.Text += Environment.NewLine;
            }
        }
        */
        public void FillLabel()
        {
            Shooter1Label.Hidden = true;
            Shooter2Label.Hidden = true;
            Shooter3Label.Hidden = true;
            Shooter4Label.Hidden = true;
            Shooter5Label.Hidden = true;

            if(max >= 1) // ************************************************* Shooter 1
            {
                Shooter1Label.Hidden = false;
                Shooter1Label.Text = shooters[0].Name;
                //Row 1
                if (shooters[0].score[0] == 1)
                    x1y1.Image = UIImage.FromFile("HitClay.png");
                else
                    x1y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[1] == 1)
                    x2y1.Image = UIImage.FromFile("HitClay.png");
                else
                    x2y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[2] == 1)
                    x3y1.Image = UIImage.FromFile("HitClay.png");
                else
                    x3y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[3] == 1)
                    x4y1.Image = UIImage.FromFile("HitClay.png");
                else
                    x4y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[4] == 1)
                    x5y1.Image = UIImage.FromFile("HitClay.png");
                else
                    x5y1.Image = UIImage.FromFile("MissClay.png");
               
                //Row 2
                 if (shooters[0].score[5] == 1)
                    x1y2.Image = UIImage.FromFile("HitClay.png");
                else
                    x1y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[6] == 1)
                    x2y2.Image = UIImage.FromFile("HitClay.png");
                else
                    x2y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[7] == 1)
                    x3y2.Image = UIImage.FromFile("HitClay.png");
                else
                    x3y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[8] == 1)
                    x4y2.Image = UIImage.FromFile("HitClay.png");
                else
                    x4y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[9] == 1)
                    x5y2.Image = UIImage.FromFile("HitClay.png");
                else
                    x5y2.Image = UIImage.FromFile("MissClay.png");

                //Row 3
                if (shooters[0].score[10] == 1)
                    x1y3.Image = UIImage.FromFile("HitClay.png");
                else
                    x1y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[11] == 1)
                    x2y3.Image = UIImage.FromFile("HitClay.png");
                else
                    x2y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[12] == 1)
                    x3y3.Image = UIImage.FromFile("HitClay.png");
                else
                    x3y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[13] == 1)
                    x4y3.Image = UIImage.FromFile("HitClay.png");
                else
                    x4y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[14] == 1)
                    x5y3.Image = UIImage.FromFile("HitClay.png");
                else
                    x5y3.Image = UIImage.FromFile("MissClay.png");

                //Row 4
                if (shooters[0].score[15] == 1)
                    x1y4.Image = UIImage.FromFile("HitClay.png");
                else
                    x1y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[16] == 1)
                    x2y4.Image = UIImage.FromFile("HitClay.png");
                else
                    x2y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[17] == 1)
                    x3y4.Image = UIImage.FromFile("HitClay.png");
                else
                    x3y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[18] == 1)
                    x4y4.Image = UIImage.FromFile("HitClay.png");
                else
                    x4y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[19] == 1)
                    x5y4.Image = UIImage.FromFile("HitClay.png");
                else
                    x5y4.Image = UIImage.FromFile("MissClay.png");

                //Row 5
                if (shooters[0].score[20] == 1)
                    x1y5.Image = UIImage.FromFile("HitClay.png");
                else
                    x1y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[21] == 1)
                    x2y5.Image = UIImage.FromFile("HitClay.png");
                else
                    x2y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[22] == 1)
                    x3y5.Image = UIImage.FromFile("HitClay.png");
                else
                    x3y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[23] == 1)
                    x4y5.Image = UIImage.FromFile("HitClay.png");
                else
                    x4y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[0].score[24] == 1)
                    x5y5.Image = UIImage.FromFile("HitClay.png");
                else
                    x5y5.Image = UIImage.FromFile("MissClay.png");


            }
            if (max >= 2) // ************************************************* Shooter 2
            {
                Shooter2Label.Hidden = false;
                Shooter2Label.Text = shooters[1].Name;

                //Row 1
                if (shooters[1].score[0] == 1)
                    ax1y1.Image = UIImage.FromFile("HitClay.png");
                else
                    ax1y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[1] == 1)
                    ax2y1.Image = UIImage.FromFile("HitClay.png");
                else
                    ax2y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[2] == 1)
                    ax3y1.Image = UIImage.FromFile("HitClay.png");
                else
                    ax3y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[3] == 1)
                    ax4y1.Image = UIImage.FromFile("HitClay.png");
                else
                    ax4y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[4] == 1)
                    ax5y1.Image = UIImage.FromFile("HitClay.png");
                else
                    ax5y1.Image = UIImage.FromFile("MissClay.png");

                //Row 2
                if (shooters[1].score[5] == 1)
                    ax1y2.Image = UIImage.FromFile("HitClay.png");
                else
                    ax1y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[6] == 1)
                    ax2y2.Image = UIImage.FromFile("HitClay.png");
                else
                    ax2y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[7] == 1)
                    ax3y2.Image = UIImage.FromFile("HitClay.png");
                else
                    ax3y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[8] == 1)
                    ax4y2.Image = UIImage.FromFile("HitClay.png");
                else
                    ax4y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[9] == 1)
                    ax5y2.Image = UIImage.FromFile("HitClay.png");
                else
                    ax5y2.Image = UIImage.FromFile("MissClay.png");

                //Row 3
                if (shooters[1].score[10] == 1)
                    ax1y3.Image = UIImage.FromFile("HitClay.png");
                else
                    ax1y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[11] == 1)
                    ax2y3.Image = UIImage.FromFile("HitClay.png");
                else
                    ax2y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[12] == 1)
                    ax3y3.Image = UIImage.FromFile("HitClay.png");
                else
                    ax3y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[13] == 1)
                    ax4y3.Image = UIImage.FromFile("HitClay.png");
                else
                    ax4y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[14] == 1)
                    ax5y3.Image = UIImage.FromFile("HitClay.png");
                else
                    ax5y3.Image = UIImage.FromFile("MissClay.png");

                //Row 4
                if (shooters[1].score[15] == 1)
                    ax1y4.Image = UIImage.FromFile("HitClay.png");
                else
                    ax1y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[16] == 1)
                    ax2y4.Image = UIImage.FromFile("HitClay.png");
                else
                    ax2y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[17] == 1)
                    ax3y4.Image = UIImage.FromFile("HitClay.png");
                else
                    ax3y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[18] == 1)
                    ax4y4.Image = UIImage.FromFile("HitClay.png");
                else
                    ax4y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[19] == 1)
                    ax5y4.Image = UIImage.FromFile("HitClay.png");
                else
                    ax5y4.Image = UIImage.FromFile("MissClay.png");

                //Row 5
                if (shooters[1].score[20] == 1)
                    ax1y5.Image = UIImage.FromFile("HitClay.png");
                else
                    ax1y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[21] == 1)
                    ax2y5.Image = UIImage.FromFile("HitClay.png");
                else
                    ax2y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[22] == 1)
                    ax3y5.Image = UIImage.FromFile("HitClay.png");
                else
                    ax3y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[23] == 1)
                    ax4y5.Image = UIImage.FromFile("HitClay.png");
                else
                    ax4y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[1].score[24] == 1)
                    ax5y5.Image = UIImage.FromFile("HitClay.png");
                else
                    ax5y5.Image = UIImage.FromFile("MissClay.png");
            }
            if (max >= 3) // ************************************************* Shooter 3
            {
                Shooter3Label.Hidden = false;
                Shooter3Label.Text = shooters[2].Name;
                //Row 1
                if (shooters[2].score[0] == 1)
                    bx1y1.Image = UIImage.FromFile("HitClay.png");
                else
                    bx1y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[1] == 1)
                    bx2y1.Image = UIImage.FromFile("HitClay.png");
                else
                    bx2y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[2] == 1)
                    bx3y1.Image = UIImage.FromFile("HitClay.png");
                else
                    bx3y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[3] == 1)
                    bx4y1.Image = UIImage.FromFile("HitClay.png");
                else
                    bx4y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[4] == 1)
                    bx5y1.Image = UIImage.FromFile("HitClay.png");
                else
                    bx5y1.Image = UIImage.FromFile("MissClay.png");

                //Row 2
                if (shooters[2].score[5] == 1)
                    bx1y2.Image = UIImage.FromFile("HitClay.png");
                else
                    bx1y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[6] == 1)
                    bx2y2.Image = UIImage.FromFile("HitClay.png");
                else
                    bx2y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[7] == 1)
                    bx3y2.Image = UIImage.FromFile("HitClay.png");
                else
                    bx3y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[8] == 1)
                    bx4y2.Image = UIImage.FromFile("HitClay.png");
                else
                    bx4y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[9] == 1)
                    bx5y2.Image = UIImage.FromFile("HitClay.png");
                else
                    bx5y2.Image = UIImage.FromFile("MissClay.png");

                //Row 3
                if (shooters[2].score[10] == 1)
                    bx1y3.Image = UIImage.FromFile("HitClay.png");
                else
                    bx1y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[11] == 1)
                    bx2y3.Image = UIImage.FromFile("HitClay.png");
                else
                    bx2y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[12] == 1)
                    bx3y3.Image = UIImage.FromFile("HitClay.png");
                else
                    bx3y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[13] == 1)
                    bx4y3.Image = UIImage.FromFile("HitClay.png");
                else
                    bx4y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[14] == 1)
                    bx5y3.Image = UIImage.FromFile("HitClay.png");
                else
                    bx5y3.Image = UIImage.FromFile("MissClay.png");

                //Row 4
                if (shooters[2].score[15] == 1)
                    bx1y4.Image = UIImage.FromFile("HitClay.png");
                else
                    bx1y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[16] == 1)
                    bx2y4.Image = UIImage.FromFile("HitClay.png");
                else
                    bx2y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[17] == 1)
                    bx3y4.Image = UIImage.FromFile("HitClay.png");
                else
                    bx3y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[18] == 1)
                    bx4y4.Image = UIImage.FromFile("HitClay.png");
                else
                    bx4y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[19] == 1)
                    bx5y4.Image = UIImage.FromFile("HitClay.png");
                else
                    bx5y4.Image = UIImage.FromFile("MissClay.png");

                //Row 5
                if (shooters[2].score[20] == 1)
                    bx1y5.Image = UIImage.FromFile("HitClay.png");
                else
                    bx1y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[21] == 1)
                    bx2y5.Image = UIImage.FromFile("HitClay.png");
                else
                    bx2y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[22] == 1)
                    bx3y5.Image = UIImage.FromFile("HitClay.png");
                else
                    bx3y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[23] == 1)
                    bx4y5.Image = UIImage.FromFile("HitClay.png");
                else
                    bx4y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[2].score[24] == 1)
                    bx5y5.Image = UIImage.FromFile("HitClay.png");
                else
                    bx5y5.Image = UIImage.FromFile("MissClay.png");


            }
            if (max >=4) // ************************************************* Shooter 4
            {
                Shooter4Label.Hidden = false;
                Shooter4Label.Text = shooters[3].Name;
                //Row 1
                if (shooters[3].score[0] == 1)
                    cx1y1.Image = UIImage.FromFile("HitClay.png");
                else
                    cx1y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[1] == 1)
                    cx2y1.Image = UIImage.FromFile("HitClay.png");
                else
                    cx2y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[2] == 1)
                    cx3y1.Image = UIImage.FromFile("HitClay.png");
                else
                    cx3y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[3] == 1)
                    cx4y1.Image = UIImage.FromFile("HitClay.png");
                else
                    cx4y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[4] == 1)
                    cx5y1.Image = UIImage.FromFile("HitClay.png");
                else
                    cx5y1.Image = UIImage.FromFile("MissClay.png");

                //Row 2
                if (shooters[3].score[5] == 1)
                    cx1y2.Image = UIImage.FromFile("HitClay.png");
                else
                    cx1y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[6] == 1)
                    cx2y2.Image = UIImage.FromFile("HitClay.png");
                else
                    cx2y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[7] == 1)
                    cx3y2.Image = UIImage.FromFile("HitClay.png");
                else
                    cx3y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[8] == 1)
                    cx4y2.Image = UIImage.FromFile("HitClay.png");
                else
                    cx4y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[9] == 1)
                    cx5y2.Image = UIImage.FromFile("HitClay.png");
                else
                    cx5y2.Image = UIImage.FromFile("MissClay.png");

                //Row 3
                if (shooters[3].score[10] == 1)
                    cx1y3.Image = UIImage.FromFile("HitClay.png");
                else
                    cx1y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[11] == 1)
                    cx2y3.Image = UIImage.FromFile("HitClay.png");
                else
                    cx2y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[12] == 1)
                    cx3y3.Image = UIImage.FromFile("HitClay.png");
                else
                    cx3y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[13] == 1)
                    cx4y3.Image = UIImage.FromFile("HitClay.png");
                else
                    cx4y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[14] == 1)
                    cx5y3.Image = UIImage.FromFile("HitClay.png");
                else
                    cx5y3.Image = UIImage.FromFile("MissClay.png");

                //Row 4
                if (shooters[3].score[15] == 1)
                    cx1y4.Image = UIImage.FromFile("HitClay.png");
                else
                    cx1y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[16] == 1)
                    cx2y4.Image = UIImage.FromFile("HitClay.png");
                else
                    cx2y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[17] == 1)
                    cx3y4.Image = UIImage.FromFile("HitClay.png");
                else
                    cx3y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[18] == 1)
                    cx4y4.Image = UIImage.FromFile("HitClay.png");
                else
                    cx4y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[19] == 1)
                    cx5y4.Image = UIImage.FromFile("HitClay.png");
                else
                    cx5y4.Image = UIImage.FromFile("MissClay.png");

                //Row 5
                if (shooters[3].score[20] == 1)
                    cx1y5.Image = UIImage.FromFile("HitClay.png");
                else
                    cx1y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[21] == 1)
                    cx2y5.Image = UIImage.FromFile("HitClay.png");
                else
                    cx2y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[22] == 1)
                    cx3y5.Image = UIImage.FromFile("HitClay.png");
                else
                    cx3y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[23] == 1)
                    cx4y5.Image = UIImage.FromFile("HitClay.png");
                else
                    cx4y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[3].score[24] == 1)
                    cx5y5.Image = UIImage.FromFile("HitClay.png");
                else
                    cx5y5.Image = UIImage.FromFile("MissClay.png");
            }
            if (max >= 5) // ************************************************* Shooter 5
            {
                Shooter5Label.Hidden = false;
                Shooter5Label.Text = shooters[4].Name;
                //Row 1
                if (shooters[4].score[0] == 1)
                    dx1y1.Image = UIImage.FromFile("HitClay.png");
                else
                    dx1y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[1] == 1)
                    dx2y1.Image = UIImage.FromFile("HitClay.png");
                else
                    dx2y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[2] == 1)
                    dx3y1.Image = UIImage.FromFile("HitClay.png");
                else
                    dx3y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[3] == 1)
                    dx4y1.Image = UIImage.FromFile("HitClay.png");
                else
                    dx4y1.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[4] == 1)
                    dx5y1.Image = UIImage.FromFile("HitClay.png");
                else
                    dx5y1.Image = UIImage.FromFile("MissClay.png");

                //Row 2
                if (shooters[4].score[5] == 1)
                    dx1y2.Image = UIImage.FromFile("HitClay.png");
                else
                    dx1y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[6] == 1)
                    dx2y2.Image = UIImage.FromFile("HitClay.png");
                else
                    dx2y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[7] == 1)
                    dx3y2.Image = UIImage.FromFile("HitClay.png");
                else
                    dx3y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[8] == 1)
                    dx4y2.Image = UIImage.FromFile("HitClay.png");
                else
                    dx4y2.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[9] == 1)
                    dx5y2.Image = UIImage.FromFile("HitClay.png");
                else
                    dx5y2.Image = UIImage.FromFile("MissClay.png");

                //Row 3
                if (shooters[4].score[10] == 1)
                    dx1y3.Image = UIImage.FromFile("HitClay.png");
                else
                    dx1y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[11] == 1)
                    dx2y3.Image = UIImage.FromFile("HitClay.png");
                else
                    dx2y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[12] == 1)
                    dx3y3.Image = UIImage.FromFile("HitClay.png");
                else
                    dx3y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[13] == 1)
                    dx4y3.Image = UIImage.FromFile("HitClay.png");
                else
                    dx4y3.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[14] == 1)
                    dx5y3.Image = UIImage.FromFile("HitClay.png");
                else
                    dx5y3.Image = UIImage.FromFile("MissClay.png");

                //Row 4
                if (shooters[4].score[15] == 1)
                    dx1y4.Image = UIImage.FromFile("HitClay.png");
                else
                    dx1y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[16] == 1)
                    dx2y4.Image = UIImage.FromFile("HitClay.png");
                else
                    dx2y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[17] == 1)
                    dx3y4.Image = UIImage.FromFile("HitClay.png");
                else
                    dx3y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[18] == 1)
                    dx4y4.Image = UIImage.FromFile("HitClay.png");
                else
                    dx4y4.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[19] == 1)
                    dx5y4.Image = UIImage.FromFile("HitClay.png");
                else
                    dx5y4.Image = UIImage.FromFile("MissClay.png");

                //Row 5
                if (shooters[4].score[20] == 1)
                    dx1y5.Image = UIImage.FromFile("HitClay.png");
                else
                    dx1y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[21] == 1)
                    dx2y5.Image = UIImage.FromFile("HitClay.png");
                else
                    dx2y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[22] == 1)
                    dx3y5.Image = UIImage.FromFile("HitClay.png");
                else
                    dx3y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[23] == 1)
                    dx4y5.Image = UIImage.FromFile("HitClay.png");
                else
                    dx4y5.Image = UIImage.FromFile("MissClay.png");
                if (shooters[4].score[24] == 1)
                    dx5y5.Image = UIImage.FromFile("HitClay.png");
                else
                    dx5y5.Image = UIImage.FromFile("MissClay.png");

            }
        }

        partial void RestartButton_TouchUpInside(UIButton sender)
        {
            NavigationController.PopViewController(true);
        }

        private void DoCSV()
        {
            CSVFile csv = new CSVFile(shooters);
            csv.getCSV();
        }

        partial void SendResultsButton_TouchUpInside(UIButton sender)
        {
            DoCSV();
        }
    }
}

