
namespace KMeansAlgorithm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeZonesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.epociLbl = new System.Windows.Forms.Label();
            this.costLbl = new System.Windows.Forms.Label();
            this.kLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.computeZonesMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // computeZonesMenuItem
            // 
            this.computeZonesMenuItem.Name = "computeZonesMenuItem";
            this.computeZonesMenuItem.Size = new System.Drawing.Size(102, 20);
            this.computeZonesMenuItem.Text = "Compute zones";
            this.computeZonesMenuItem.Click += new System.EventHandler(this.ComputeZonesBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(22, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(656, 616);
            this.mainPanel.TabIndex = 1;
            // 
            // epociLbl
            // 
            this.epociLbl.AutoSize = true;
            this.epociLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epociLbl.Location = new System.Drawing.Point(693, 54);
            this.epociLbl.Name = "epociLbl";
            this.epociLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.epociLbl.Size = new System.Drawing.Size(54, 18);
            this.epociLbl.TabIndex = 2;
            this.epociLbl.Text = "Epoci: ";
            // 
            // costLbl
            // 
            this.costLbl.AutoSize = true;
            this.costLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLbl.Location = new System.Drawing.Point(693, 87);
            this.costLbl.Name = "costLbl";
            this.costLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.costLbl.Size = new System.Drawing.Size(48, 18);
            this.costLbl.TabIndex = 3;
            this.costLbl.Text = "Cost: ";
            // 
            // kLbl
            // 
            this.kLbl.AutoSize = true;
            this.kLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kLbl.Location = new System.Drawing.Point(693, 27);
            this.kLbl.Name = "kLbl";
            this.kLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kLbl.Size = new System.Drawing.Size(26, 18);
            this.kLbl.TabIndex = 4;
            this.kLbl.Text = "K: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 694);
            this.Controls.Add(this.kLbl);
            this.Controls.Add(this.costLbl);
            this.Controls.Add(this.epociLbl);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeZonesMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label epociLbl;
        private System.Windows.Forms.Label costLbl;
        private System.Windows.Forms.Label kLbl;
    }
}

