
namespace GeneratePoints
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
            this.drawGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.labelZero = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawGraphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1072, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // drawGraphToolStripMenuItem
            // 
            this.drawGraphToolStripMenuItem.Name = "drawGraphToolStripMenuItem";
            this.drawGraphToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.drawGraphToolStripMenuItem.Text = "Draw Graph";
            this.drawGraphToolStripMenuItem.Click += new System.EventHandler(this.drawGraphMenuItem_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Location = new System.Drawing.Point(41, 46);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(858, 536);
            this.graphPanel.TabIndex = 2;
            // 
            // labelZero
            // 
            this.labelZero.AutoSize = true;
            this.labelZero.Location = new System.Drawing.Point(41, 597);
            this.labelZero.Name = "labelZero";
            this.labelZero.Size = new System.Drawing.Size(0, 13);
            this.labelZero.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 677);
            this.Controls.Add(this.labelZero);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MyForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem drawGraphToolStripMenuItem;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label labelZero;
    }
}

