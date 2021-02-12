using MusicApp.Models;
using System;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class MusicList : UserControl
    {
        public delegate void DelegateClickBtn(string button);
        public event DelegateClickBtn ClickBtn;

        public MusicList()
        {
            InitializeComponent();
            updateList();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            updateList();
        }

        private async void updateList()
        {
            dataGridView1.DataSource = await MusicDTO.GetMusicsAsync();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (ClickBtn != null)
            {
                ClickBtn(((Button)sender).Name);
            }
        }
    }
}
