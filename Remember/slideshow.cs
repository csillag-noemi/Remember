using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Remember
{
    public partial class Slideshow : Form
    {
        private static List<string> ImagesOnSlideShow { get; set; } = new List<string>();
        private static int DisplayedImageIndex { get; set; } = 0;
        private static double OpacityRate { get; set; } = 0.05;
        private static bool IsTransitionPaused { get; set; } = false;
        private static bool Transitioning { get; set; } = false;
        private static bool IsMusicPaused { get; set; } = true;
        public static TransitionSlideshow TransitionSlideshow { get; set; } = new TransitionSlideshow();
        private static Background Background { get; set; }
        private static Direction TransitionDirection { get; set; } = Direction.Right;

        private double valueToIncrease = 0;
        private double currentSlideshowOpacity = 1;
        private double opRateUp = 0;
        private double opRateDown = 1;
        float sliderIni = 0;
        string sliderDirection;
        bool nextUp = false;
        bool nextDown = true;

        public Slideshow()
        {
            InitializeComponent();
            StartSlideshow();
        }

        private void StartSlideshow()
        {
            ImagesOnSlideShow = Dashboard.CurrentImageList;
            DisplayedImageIndex = 0;
            TransitionDirection = Direction.Right;

            Background = new Background();
            Background.Show();
           
            pictureBox1.Image = Image.FromFile(ImagesOnSlideShow[DisplayedImageIndex].ToString());
            BringToFront();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // while transitioning between photos
            if (Opacity != 0 && TransitionSlideshow.Opacity != 1)
            {
                TransitionSlideshow.Opacity = Math.Round(TransitionSlideshow.Opacity + OpacityRate, 4);
                Opacity = Math.Round(Opacity - OpacityRate, 4);
                return;
            }
            else // when transition is complete
            {
                Transitioning = false;
                timer1.Stop();

                if (TransitionDirection == Direction.Right)
                {
                    DisplayedImageIndex++;
                }
                else if(TransitionDirection == Direction.Left)
                {
                    DisplayedImageIndex--;
                }

                pictureBox1.Image = Image.FromFile(ImagesOnSlideShow[DisplayedImageIndex]);
            }
        }

        private void Slideshow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Transitioning)
            {
                if (e.KeyCode == Keys.D1)
                {
                    ChangeOpacityRate(0.1);
                }
                else if (e.KeyCode == Keys.D2)
                {
                    ChangeOpacityRate(0.05);
                }
                else if (e.KeyCode == Keys.D3)
                {
                    ChangeOpacityRate(0.025);
                }
                else if (e.KeyCode == Keys.D4)
                {
                    ChangeOpacityRate(0.0167);
                }
                else if (e.KeyCode == Keys.D5)
                {
                    ChangeOpacityRate(0.0125);
                }
                else if (e.KeyCode == Keys.D6)
                {
                    ChangeOpacityRate(0.01);
                }
                else if (e.KeyCode == Keys.D7)
                {
                    ChangeOpacityRate(0.0083);
                }
                else if (e.KeyCode == Keys.D8)
                {
                    ChangeOpacityRate(0.0071);
                }
                else if (e.KeyCode == Keys.D9)
                {
                    ChangeOpacityRate(0.0063);
                }
                else if (e.KeyCode == Keys.D0)
                {
                    ChangeOpacityRate(1);
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                TransitionSlideshow.Hide();
                Background.Close();

                if (Dashboard.Player != null)
                {
                    Dashboard.Player.Stop();
                }
            }
            else if (e.KeyCode == Keys.A) // Start/stop music
            {
                if (Dashboard.Player != null)
                {
                    if (IsMusicPaused)
                    {
                        Dashboard.Player.Play();
                        IsMusicPaused = false;
                    }
                    else
                    {
                        Dashboard.Player.Stop();
                        IsMusicPaused = true;
                    }
                }
            }
            else if (e.KeyCode == Keys.Space) // pause transition
            {
                if (IsTransitionPaused)
                {
                    timer1.Start();
                    IsTransitionPaused = false;
                }
                else
                {
                    timer1.Stop();
                    IsTransitionPaused = true;

                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                TransitionDirection = Direction.Right;
            }
            else if (e.KeyCode == Keys.Left)
            {
                TransitionDirection = Direction.Left;
            }
        }

        private void ChangeOpacityRate(double opacityRate)
        {
            Opacity = 1;

            if ((TransitionDirection == Direction.Right && DisplayedImageIndex == ImagesOnSlideShow.Count() - 1)
                || (TransitionDirection == Direction.Left && DisplayedImageIndex == 0))
            {
                return;
            }
            else
            {
                Transitioning = true;

                if (TransitionDirection == Direction.Right)
                {
                    TransitionSlideshow.ShowSlideshow(0, DisplayedImageIndex + 1);
                }
                else
                {
                    TransitionSlideshow.ShowSlideshow(0, DisplayedImageIndex - 1);
                }
                BringToFront();
                OpacityRate = opacityRate;
                timer1.Start();
            }
        }
        internal void HandleCommand(string command)
        {
            //for TRANSITION
            if (command.StartsWith("SLIDER_VALUE:"))
            {
                string valueString = command.Substring("SLIDER_VALUE:".Length);
                if (float.TryParse(valueString, out float sliderValue))
                {
                    
                    if (sliderValue > sliderIni) //upwards
                    {
                        sliderDirection = "up";
                    }
                    else //downwards
                    {
                        sliderDirection = "down";
                    }
                    OpacityHandler(sliderValue);
                    sliderIni = sliderValue;
                }
            }

            //for NEXT
            if(command.Equals("NEXT"))
            {
                CompleteTransition();
            }

            //for DIRECTION
            if(command.Equals("RIGHT"))
            {
                TransitionDirection = Direction.Right;
            }
            else if(command.Equals("LEFT"))
            {
                TransitionDirection = Direction.Left;
            }

            //for MUSIC
            if (command == "MUSIC_ON")
            {
                // Code to turn music on
                if (Dashboard.Player != null)
                {
                    Dashboard.Player.Play();
                    IsMusicPaused = false;
                }
            }
            else if (command == "MUSIC_OFF")
            {
                // Code to turn music off
                if (Dashboard.Player != null)
                {
                    Dashboard.Player.Stop();
                    IsMusicPaused = true;
                }
            }
        }

        internal void OpacityHandler(float sliderValue)
        {
            if ((TransitionDirection == Direction.Right && DisplayedImageIndex == ImagesOnSlideShow.Count() - 1) ||
                (TransitionDirection == Direction.Left && DisplayedImageIndex == 0))
            {
                MessageBox.Show("The slideshow has ended!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if((sliderValue == 0.05f && sliderIni == 0f) || (sliderValue == 0.95f && sliderIni == 1f)) //prima data cand se instantiaza transitionSlideshow; trebuie doar la inceputul unei tranzitii
                {
                    if (TransitionDirection == Direction.Right)
                    {
                        TransitionSlideshow.ShowSlideshow(0, DisplayedImageIndex + 1);
                    }
                    else if (TransitionDirection == Direction.Left)
                    {
                        TransitionSlideshow.ShowSlideshow(0, DisplayedImageIndex - 1);
                    }
                }
                BringToFront();
                valueToIncrease = sliderValue;
                timer2.Start();
            }
        }

        private void CompleteTransition()
        {
            if(TransitionDirection == Direction.Left)
            {
                DisplayedImageIndex--;
            }
            else
            {
                DisplayedImageIndex++;
            }
            Background.SetImage(Image.FromFile(ImagesOnSlideShow[DisplayedImageIndex].ToString()));
            pictureBox1.Image = Image.FromFile(ImagesOnSlideShow[DisplayedImageIndex].ToString());
            BringToFront();
            opRateUp = 0;
            opRateDown = 1;
            if (nextDown == true)
            {
                nextDown = false;
                nextUp = true;
            }
            else
            {
                nextDown = true;
                nextUp = false;
            }
            Transitioning = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            valueToIncrease = Math.Round(valueToIncrease, 3); //have only 3 decimals
            opRateUp = Math.Round(opRateUp, 3);
            if(nextDown == true) //slider going upwards for the main transition; normal beh
            {
                if (opRateUp <= valueToIncrease && sliderDirection.Equals("up"))
                {
                    TransitionSlideshow.Opacity = Math.Round(TransitionSlideshow.Opacity + 0.01, 3);
                    Opacity = Math.Round(Opacity - 0.01, 3);
                    currentSlideshowOpacity = Opacity;
                    opRateUp += 0.01;
                    return;
                }
                else if (opRateDown >= valueToIncrease && sliderDirection.Equals("down"))
                {
                    TransitionSlideshow.Opacity = Math.Round(TransitionSlideshow.Opacity - 0.01, 3);
                    Opacity = Math.Round(Opacity + 0.01, 3);
                    currentSlideshowOpacity = Opacity;
                    opRateDown -= 0.01;
                    return;
                }
                else
                {
                    stopTimer();
                }
            }
            else if (nextUp == true) //slider goes downwards for the main transition
            {
                if (opRateUp <= valueToIncrease && sliderDirection.Equals("up"))
                {
                    TransitionSlideshow.Opacity = Math.Round(TransitionSlideshow.Opacity - 0.01, 3);
                    Opacity = Math.Round(Opacity + 0.01, 3);
                    currentSlideshowOpacity = Opacity;
                    opRateUp += 0.01;
                    return;
                }
                else if (opRateDown >= valueToIncrease && sliderDirection.Equals("down"))
                {
                    TransitionSlideshow.Opacity = Math.Round(TransitionSlideshow.Opacity + 0.01, 3);
                    Opacity = Math.Round(Opacity - 0.01, 3);
                    currentSlideshowOpacity = Opacity;
                    opRateDown -= 0.01;
                    return;
                }
                else
                {
                    stopTimer();
                }
            } 
        }
        private void stopTimer()
        {
            opRateUp = valueToIncrease;
            opRateDown = valueToIncrease;
            Opacity = currentSlideshowOpacity;
            timer2.Stop();
        }
    }


    enum Direction { Left, Right }

}