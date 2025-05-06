namespace KursavayaWork
{
    partial class NoteTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteTip));
            this.KursovayLabel = new System.Windows.Forms.Label();
            this.Pnl9_Label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KursovayLabel
            // 
            this.KursovayLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.KursovayLabel.AutoSize = true;
            this.KursovayLabel.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KursovayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(123)))), ((int)(((byte)(37)))));
            this.KursovayLabel.Location = new System.Drawing.Point(8, 9);
            this.KursovayLabel.Name = "KursovayLabel";
            this.KursovayLabel.Size = new System.Drawing.Size(220, 45);
            this.KursovayLabel.TabIndex = 1;
            this.KursovayLabel.Text = "СПРАВКА";
            // 
            // Pnl9_Label2
            // 
            this.Pnl9_Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Pnl9_Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(226)))));
            this.Pnl9_Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pnl9_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Pnl9_Label2.Location = new System.Drawing.Point(9, 6);
            this.Pnl9_Label2.MinimumSize = new System.Drawing.Size(149, 35);
            this.Pnl9_Label2.Name = "Pnl9_Label2";
            this.Pnl9_Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Pnl9_Label2.Size = new System.Drawing.Size(482, 1663);
            this.Pnl9_Label2.TabIndex = 41;
            this.Pnl9_Label2.Text = resources.GetString("Pnl9_Label2.Text");
            this.Pnl9_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(226)))));
            this.panel1.Controls.Add(this.Pnl9_Label2);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 561);
            this.panel1.TabIndex = 42;
            // 
            // NoteTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(541, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.KursovayLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NoteTip";
            this.Text = "NoteTip";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KursovayLabel;
        private System.Windows.Forms.Label Pnl9_Label2;
        private System.Windows.Forms.Panel panel1;
    }
}