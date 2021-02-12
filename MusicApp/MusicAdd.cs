using MusicApp.Models;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class MusicAdd : UserControl
    {
        public delegate void DelegateClickBtn(string button);
        public event DelegateClickBtn ClickBtn;

        public MusicAdd()
        {
            InitializeComponent();
        }

        private async void add_Click(object sender, EventArgs e)
        {
            MusicDTO music = new MusicDTO();
            string errorMessage = null;

            if (titleBox.Text.Length >= 3 && titleBox.Text.Length <= 60)
            {
                music.Title = titleBox.Text;
            } else
            {
                errorMessage = "Title must have between 3 and 60 characters";
            }

            if (artistBox.Text.Length >= 3 && artistBox.Text.Length <= 60)
            {
                music.Artist = artistBox.Text;
            }
            else
            {
                errorMessage = "Artist must have between 3 and 60 characters";
            }

            music.ReleaseDate = releaseDatePicker.Value;

            if (Regex.IsMatch(genreBox.Text, "^[A-Z]+[a-zA-Z ]{0,29}$"))
            {
                music.Genre = genreBox.Text;
            }
            else
            {
                errorMessage = "Genre must have between 1 and 30 letters and start by a capital letter";
            }
            
            if (decimal.TryParse(priceBox.Text, out decimal result))
            {
                music.Price = result;
            } else
            {
                errorMessage = "Price must be a decimal number";
            }
            
            if (errorMessage == null)
            {
                bool success = await MusicDTO.CreateProductAsync(music);
                if (success)
                {
                    showMessage("Your music is now waiting for validation. You can add another one or come back to the list");
                    titleBox.Text = String.Empty;
                    artistBox.Text = String.Empty;
                    genreBox.Text = String.Empty;
                    priceBox.Text = String.Empty;
                }
                else
                {
                    showMessage("The communication with the database failed.", true);
                }
            } else
            {
                showMessage(errorMessage, true);
            }
            errorMessage = String.Empty;
        }

        private void showMessage(string message, bool error = false)
        {
            if (error)
            {
                messageLabel.ForeColor = Color.FromArgb(255, 0, 0);
            } else
            {
                messageLabel.ForeColor = Color.FromArgb(0, 0, 0);
            }
            messageLabel.Text = message;

        }

        private void back_Click(object sender, EventArgs e)
        {
            if (ClickBtn != null)
            {
                titleBox.Text = String.Empty;
                artistBox.Text = String.Empty;
                genreBox.Text = String.Empty;
                priceBox.Text = String.Empty;
                ClickBtn(((Button)sender).Name);
            }
        }
    }
}
