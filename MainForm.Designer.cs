
namespace Home0409_11_7_Watch
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
            this.components = new System.ComponentModel.Container();
            this.watchPanel = new System.Windows.Forms.Panel();
            this.signPanel = new System.Windows.Forms.Panel();
            this.secTimer = new System.Windows.Forms.Timer(this.components);
            this.watchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // watchPanel
            // 
            this.watchPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(136)))));
            this.watchPanel.Controls.Add(this.signPanel);
            this.watchPanel.Location = new System.Drawing.Point(10, 10);
            this.watchPanel.Name = "watchPanel";
            this.watchPanel.Size = new System.Drawing.Size(500, 500);
            this.watchPanel.TabIndex = 0;
            this.watchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.watchPanel_Paint);
            // 
            // signPanel
            // 
            this.signPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(136)))));
            this.signPanel.Location = new System.Drawing.Point(210, 210);
            this.signPanel.Name = "signPanel";
            this.signPanel.Size = new System.Drawing.Size(80, 80);
            this.signPanel.TabIndex = 0;
            // 
            // secTimer
            // 
            this.secTimer.Tick += new System.EventHandler(this.secTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(136)))));
            this.ClientSize = new System.Drawing.Size(524, 524);
            this.Controls.Add(this.watchPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.watchPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel watchPanel;
        private System.Windows.Forms.Timer secTimer;
        private System.Windows.Forms.Panel signPanel;
    }
}

