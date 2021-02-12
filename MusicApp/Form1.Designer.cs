
namespace MusicApp
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.musicAdd1 = new MusicApp.MusicAdd();
            this.musicList1 = new MusicApp.MusicList();
            this.musicDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.musicDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // musicAdd1
            // 
            this.musicAdd1.Location = new System.Drawing.Point(3, 8);
            this.musicAdd1.Name = "musicAdd1";
            this.musicAdd1.Size = new System.Drawing.Size(785, 430);
            this.musicAdd1.TabIndex = 1;
            this.musicAdd1.Visible = false;
            // 
            // musicList1
            // 
            this.musicList1.Location = new System.Drawing.Point(3, 11);
            this.musicList1.Name = "musicList1";
            this.musicList1.Size = new System.Drawing.Size(785, 427);
            this.musicList1.TabIndex = 0;
            // 
            // musicDTOBindingSource
            // 
            this.musicDTOBindingSource.DataSource = typeof(MusicApp.Models.MusicDTO);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.musicAdd1);
            this.Controls.Add(this.musicList1);
            this.Name = "Form1";
            this.Text = "Music App";
            ((System.ComponentModel.ISupportInitialize)(this.musicDTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource musicDTOBindingSource;
        private MusicList musicList1;
        private MusicAdd musicAdd1;
    }
}

