﻿using System;
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
        private const int HowManyBalls = 5;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < HowManyBalls; i++)
            {
                var footBall = new Ball(this);
                footBall.Bounce();
            }
        }
    }
}
