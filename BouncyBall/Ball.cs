using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BouncyBall
{
    internal class Ball
    {
        private readonly Form _form;
        private readonly PictureBox _pictureBox;

        private Point _position;
        private int _xFactor;
        private int _yFactor;

        private const string FootBallImagePath =
            @"C:\\Users\\avina\\OneDrive - arctechinfo.com\\Documents\\Training\\Sessions\\C#\\25-Jan-2022\\Week5Day2Demo\\BouncyBall\\football.jpg";

        static readonly Random Random = new();

        public Ball(Form form)
        {
            _form = form;
            _pictureBox = CreateAFootBallPictureBox();

            var x = Random.Next(0, _form.Width - _pictureBox.Width);
            var y = Random.Next(0, _form.Height - _pictureBox.Height);

            _xFactor = Random.Next(5, 20);
            _yFactor = Random.Next(5, 20);

            _position = new Point(x, y);
        }

        private PictureBox CreateAFootBallPictureBox()
        {
            var pictureBoxFootBall = new PictureBox();
            pictureBoxFootBall.ImageLocation = FootBallImagePath;
            pictureBoxFootBall.Size = new Size(116, 115);

            _form.Controls.Add(pictureBoxFootBall);

            return pictureBoxFootBall;
        }

        public void Bounce()
        {
            var t = new Thread(BounceBall)
            {
                IsBackground = true
            };

            t.Start();
        }

        private void BounceBall()
        {
            do
            {
                _position.X += _xFactor;
                _position.Y += _yFactor;

                if (_position.X < 0 || _position.X > _form.Width - _pictureBox.Width)
                    _xFactor = -_xFactor;

                if (_position.Y < 0 || _position.Y > _form.Height - _pictureBox.Height)
                    _yFactor = -_yFactor;

                _pictureBox.Invoke((MethodInvoker) delegate
                {
                    _pictureBox.Left = _position.X;
                    _pictureBox.Top = _position.Y;
                });

                Thread.Sleep(10);
            } while (true);
        }
    }
}
