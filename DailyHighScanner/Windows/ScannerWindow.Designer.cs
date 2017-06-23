namespace DailyHighScanner
{
    partial class ScannerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripFilterHighVolume = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFilterHighestLowest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripFilterHideLosers = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(554, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripLabelStatus.Name = "toolStripStatusLabel1";
            this.toolStripLabelStatus.Size = new System.Drawing.Size(101, 17);
            this.toolStripLabelStatus.Text = "Requesting data...";
            // 
            // dataGridView1
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.Name = "dataGridView1";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(554, 315);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFilterHighVolume,
            this.toolStripFilterHighestLowest,
            this.toolStripFilterHideLosers});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripFilterHighVolume.Name = "toolStripMenuItem1";
            this.toolStripFilterHighVolume.Size = new System.Drawing.Size(115, 20);
            this.toolStripFilterHighVolume.Text = "Filter high volume";
            this.toolStripFilterHighVolume.Click += new System.EventHandler(this.toolStripMenuItemFilterHighVolume_Click);
            // 
            // filterHighestlowestToolStripMenuItem
            // 
            this.toolStripFilterHighestLowest.Name = "filterHighestlowestToolStripMenuItem";
            this.toolStripFilterHighestLowest.Size = new System.Drawing.Size(126, 20);
            this.toolStripFilterHighestLowest.Text = "Filter highest/lowest";
            this.toolStripFilterHighestLowest.Click += new System.EventHandler(this.toolStripMenuItemFilterHighestLower_Click);
            // 
            // hideLosersToolStripMenuItem
            // 
            this.toolStripFilterHideLosers.Name = "hideLosersToolStripMenuItem";
            this.toolStripFilterHideLosers.Size = new System.Drawing.Size(77, 20);
            this.toolStripFilterHideLosers.Text = "Hide losers";
            this.toolStripFilterHideLosers.Click += new System.EventHandler(this.toolStripMenuItemFilterHideLosers_Click);
            // 
            // ScannerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 361);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScannerWindow";
            this.ShowIcon = false;
            this.Text = "Daily-High Crypto Scanner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelStatus;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripFilterHighVolume;
        private System.Windows.Forms.ToolStripMenuItem toolStripFilterHighestLowest;
        private System.Windows.Forms.ToolStripMenuItem toolStripFilterHideLosers;
    }
}

