using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartKids
{
    public class Win8Form : Form
    {
        private readonly Timer _closeTimer = new Timer();
        private readonly Timer _openTimer = new Timer();
        private Win8BackButton _win8BackButton1;

        private int step = 40;
        private int width, height;
        
        public Win8Form()
        {
            InitializeComponent();

            _closeTimer.Tick += close_Tick;
            _closeTimer.Interval = 10;

            _openTimer.Tick += open_Tick;
            _openTimer.Interval = 10;

            width = Screen.PrimaryScreen.Bounds.Width;
            height = Screen.PrimaryScreen.Bounds.Height;


        }

        private void open_Tick(object sender, EventArgs e)
        {
            int pos;

            if (Location.X < step)
                pos = 0;
            else
                pos = Location.X - step;


            Location = new Point(pos, Location.Y);


            if (Location.X == 0)
            {
                _openTimer.Enabled = false;
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            Location = new Point(Location.X + step, Location.Y);


            if (Location.X > width)
            {
                _closeTimer.Enabled = false;
                Close();
            }
        }


        private void InitializeComponent()
        {
            this._win8BackButton1 = new SmartKids.Win8BackButton();
            this.SuspendLayout();
            // 
            // _win8BackButton1
            // 
            this._win8BackButton1.AutoSize = true;
            this._win8BackButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._win8BackButton1.BackColor = System.Drawing.Color.Transparent;
            this._win8BackButton1.Location = new System.Drawing.Point(50, 65);
            this._win8BackButton1.Name = "_win8BackButton1";
            this._win8BackButton1.Size = new System.Drawing.Size(47, 47);
            this._win8BackButton1.TabIndex = 0;
            this._win8BackButton1.Click += new System.EventHandler(this._win8BackButton1_Click);
            // 
            // Win8Form
            // 
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this._win8BackButton1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Win8Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Win8Form_FormClosing);
            this.Load += new System.EventHandler(this.MyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void Win8Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Location.X == 0)
            {
                this.Size = new Size(width, height);
                _closeTimer.Enabled = true;
            }


            if (!(Location.X >= width))
            {
                e.Cancel = true;
            }
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            Location = new Point(width,0);
            this.Size = new Size(width, height);
            _openTimer.Enabled = true;
        }

        private void _win8BackButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}