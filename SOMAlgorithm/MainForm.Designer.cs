
namespace SOMAlgorithm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.computeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.alphaLbl = new System.Windows.Forms.Label();
            this.totalEpochNumberLbl = new System.Windows.Forms.Label();
            this.vLbl = new System.Windows.Forms.Label();
            this.epochLbl = new System.Windows.Forms.Label();
            this.AlphaNumberLbl = new System.Windows.Forms.Label();
            this.VNumberLbl = new System.Windows.Forms.Label();
            this.epochNumberLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(14, 39);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(616, 570);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBtn,
            this.computeBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startBtn
            // 
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(43, 20);
            this.startBtn.Text = "Start";
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // computeBtn
            // 
            this.computeBtn.Name = "computeBtn";
            this.computeBtn.Size = new System.Drawing.Size(69, 20);
            this.computeBtn.Text = "Compute";
            this.computeBtn.Click += new System.EventHandler(this.ComputeBtn_Click);
            // 
            // alphaLbl
            // 
            this.alphaLbl.AutoSize = true;
            this.alphaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaLbl.Location = new System.Drawing.Point(654, 71);
            this.alphaLbl.Name = "alphaLbl";
            this.alphaLbl.Size = new System.Drawing.Size(54, 20);
            this.alphaLbl.TabIndex = 2;
            this.alphaLbl.Text = "Alpha:";
            // 
            // totalEpochNumberLbl
            // 
            this.totalEpochNumberLbl.AutoSize = true;
            this.totalEpochNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEpochNumberLbl.Location = new System.Drawing.Point(654, 42);
            this.totalEpochNumberLbl.Name = "totalEpochNumberLbl";
            this.totalEpochNumberLbl.Size = new System.Drawing.Size(144, 20);
            this.totalEpochNumberLbl.TabIndex = 3;
            this.totalEpochNumberLbl.Text = "Number of runs: 10";
            this.totalEpochNumberLbl.Click += new System.EventHandler(this.totalEpochNumberLbl_Click);
            // 
            // vLbl
            // 
            this.vLbl.AutoSize = true;
            this.vLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vLbl.Location = new System.Drawing.Point(654, 103);
            this.vLbl.Name = "vLbl";
            this.vLbl.Size = new System.Drawing.Size(24, 20);
            this.vLbl.TabIndex = 4;
            this.vLbl.Text = "V:";
            // 
            // epochLbl
            // 
            this.epochLbl.AutoSize = true;
            this.epochLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epochLbl.Location = new System.Drawing.Point(654, 136);
            this.epochLbl.Name = "epochLbl";
            this.epochLbl.Size = new System.Drawing.Size(59, 20);
            this.epochLbl.TabIndex = 5;
            this.epochLbl.Text = "Epoch:";
            // 
            // AlphaNumberLbl
            // 
            this.AlphaNumberLbl.AutoSize = true;
            this.AlphaNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlphaNumberLbl.Location = new System.Drawing.Point(719, 71);
            this.AlphaNumberLbl.Name = "AlphaNumberLbl";
            this.AlphaNumberLbl.Size = new System.Drawing.Size(0, 20);
            this.AlphaNumberLbl.TabIndex = 6;
            // 
            // VNumberLbl
            // 
            this.VNumberLbl.AutoSize = true;
            this.VNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VNumberLbl.Location = new System.Drawing.Point(685, 103);
            this.VNumberLbl.Name = "VNumberLbl";
            this.VNumberLbl.Size = new System.Drawing.Size(0, 20);
            this.VNumberLbl.TabIndex = 7;
            // 
            // epochNumberLbl
            // 
            this.epochNumberLbl.AutoSize = true;
            this.epochNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epochNumberLbl.Location = new System.Drawing.Point(719, 136);
            this.epochNumberLbl.Name = "epochNumberLbl";
            this.epochNumberLbl.Size = new System.Drawing.Size(0, 20);
            this.epochNumberLbl.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 621);
            this.Controls.Add(this.epochNumberLbl);
            this.Controls.Add(this.VNumberLbl);
            this.Controls.Add(this.AlphaNumberLbl);
            this.Controls.Add(this.epochLbl);
            this.Controls.Add(this.vLbl);
            this.Controls.Add(this.totalEpochNumberLbl);
            this.Controls.Add(this.alphaLbl);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startBtn;
        private System.Windows.Forms.ToolStripMenuItem computeBtn;
        private System.Windows.Forms.Label alphaLbl;
        private System.Windows.Forms.Label totalEpochNumberLbl;
        private System.Windows.Forms.Label vLbl;
        private System.Windows.Forms.Label epochLbl;
        private System.Windows.Forms.Label AlphaNumberLbl;
        private System.Windows.Forms.Label VNumberLbl;
        private System.Windows.Forms.Label epochNumberLbl;
    }
}

