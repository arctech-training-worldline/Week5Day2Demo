using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class Form2 : Form
    {
        private const string FootBallImagePath =
            @"C:\\Users\\avina\\OneDrive - arctechinfo.com\\Documents\\Training\\Sessions\\C#\\25-Jan-2022\\Week5Day2Demo\\BouncyBall\\football.jpg";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            CreateFootBalls(10);
        }

        private void CreateFootBalls(int howManyBalls)
        {
            for (var i = 0; i < howManyBalls; i++)
            {
                var pictureBoxFootball = CreateAFootBallPictureBox();

                var footBall = new Ball(pictureBoxFootball, this);
                footBall.Bounce();
            }
        }

        private PictureBox CreateAFootBallPictureBox()
        {
            var pictureBoxFootBall = new PictureBox();
            pictureBoxFootBall.ImageLocation = FootBallImagePath;
            pictureBoxFootBall.Size = new Size(116, 115);

            Controls.Add(pictureBoxFootBall);

            return pictureBoxFootBall;
        }
    }
}
