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
    // Separation of concerns
    public partial class Form1 : Form
    {
        private Point _position = new Point(50, 50);
        private int _xFactor = 15;
        private int _yFactor = 15;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBounce()
        {
            do
            {
                _position.X += _xFactor;
                _position.Y += _yFactor;

                if (_position.X < 0 || _position.X > Width - PictureBoxFootball.Width)
                    _xFactor = -_xFactor;

                if (_position.Y < 0 || _position.Y > Height - PictureBoxFootball.Height)
                    _yFactor = -_yFactor;

                PictureBoxFootball.Left = _position.X;
                PictureBoxFootball.Top = _position.Y;

                Thread.Sleep(10);
            } while (true);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //StartBounce();
            var t = new Thread(StartBounce)
            {
                IsBackground = true
            };

            t.Start();
        }
    }
}
