using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            musicList1.ClickBtn += MusicList1_ClickBtn;
            musicAdd1.ClickBtn += MusicAdd1_ClickBtn;
        }

        private void MusicAdd1_ClickBtn(string button)
        {
            if (button == "back")
            {
                musicAdd1.Visible = false;
                musicList1.Visible = true;
            }
        }

        private void MusicList1_ClickBtn(string button)
        {
            if (button == "add")
            {
                musicList1.Visible = false;
                musicAdd1.Visible = true;
            }
        }
    }
}
