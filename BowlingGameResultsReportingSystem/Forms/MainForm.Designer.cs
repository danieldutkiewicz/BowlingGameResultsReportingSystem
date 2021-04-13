
namespace BowlingGameResultsReportingSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DropLanding = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DropLanding)).BeginInit();
            this.SuspendLayout();
            // 
            // DropLanding
            // 
            this.DropLanding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DropLanding.Image = global::BowlingGameResultsReportingSystem.Properties.Resources.drag_and_drop_icon;
            this.DropLanding.Location = new System.Drawing.Point(12, 12);
            this.DropLanding.Name = "DropLanding";
            this.DropLanding.Size = new System.Drawing.Size(480, 457);
            this.DropLanding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DropLanding.TabIndex = 0;
            this.DropLanding.TabStop = false;
            this.DropLanding.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropLanding_DragDrop);
            this.DropLanding.DragOver += new System.Windows.Forms.DragEventHandler(this.DropLanding_DragOver);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(504, 481);
            this.Controls.Add(this.DropLanding);
            this.Name = "MainForm";
            this.Text = "Drag&Drop Game Record Here";
            ((System.ComponentModel.ISupportInitialize)(this.DropLanding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DropLanding;
    }
}

