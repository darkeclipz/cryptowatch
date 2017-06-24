namespace Cryptowatch.App.Windows
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.chartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelSymbol = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBtc = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.symbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart5minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart15minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart30minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2hrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyHighScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hTTPRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tradeToolStripMenuItem,
            this.chartsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.symbolToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradingToolStripMenuItem,
            this.toolStripSeparator3,
            this.buyToolStripMenuItem});
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tradeToolStripMenuItem.Text = "Trade";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // chartsToolStripMenuItem
            // 
            this.chartsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chart5minToolStripMenuItem,
            this.chart15minToolStripMenuItem,
            this.chart30minToolStripMenuItem,
            this.chart2hrToolStripMenuItem,
            this.chartDayToolStripMenuItem});
            this.chartsToolStripMenuItem.Name = "chartsToolStripMenuItem";
            this.chartsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.chartsToolStripMenuItem.Text = "Charts";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyHighScannerToolStripMenuItem,
            this.orderBookToolStripMenuItem,
            this.hTTPRequestsToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.windowToolStripMenuItem.Text = "View";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSymbol,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelBtc});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(785, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelSymbol
            // 
            this.toolStripLabelSymbol.Name = "toolStripLabelSymbol";
            this.toolStripLabelSymbol.Size = new System.Drawing.Size(50, 17);
            this.toolStripLabelSymbol.Text = "<none>";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(566, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelBtc
            // 
            this.toolStripStatusLabelBtc.Name = "toolStripStatusLabelBtc";
            this.toolStripStatusLabelBtc.Size = new System.Drawing.Size(154, 17);
            this.toolStripStatusLabelBtc.Text = "Requesting BTC/USD price...";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // symbolToolStripMenuItem
            // 
            this.symbolToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.magnifier;
            this.symbolToolStripMenuItem.Name = "symbolToolStripMenuItem";
            this.symbolToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.symbolToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.symbolToolStripMenuItem.Text = "Find symbol...";
            this.symbolToolStripMenuItem.Click += new System.EventHandler(this.symbolToolStripMenuItem_Click);
            // 
            // tradingToolStripMenuItem
            // 
            this.tradingToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.report;
            this.tradingToolStripMenuItem.Name = "tradingToolStripMenuItem";
            this.tradingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tradingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.tradingToolStripMenuItem.Text = "Trading";
            this.tradingToolStripMenuItem.Click += new System.EventHandler(this.tradingToolStripMenuItem_Click);
            // 
            // buyToolStripMenuItem
            // 
            this.buyToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.basket_add;
            this.buyToolStripMenuItem.Name = "buyToolStripMenuItem";
            this.buyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.buyToolStripMenuItem.Text = "Open position";
            this.buyToolStripMenuItem.Click += new System.EventHandler(this.buyToolStripMenuItem_Click);
            // 
            // chart5minToolStripMenuItem
            // 
            this.chart5minToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chart5minToolStripMenuItem.Image")));
            this.chart5minToolStripMenuItem.Name = "chart5minToolStripMenuItem";
            this.chart5minToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.chart5minToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.chart5minToolStripMenuItem.Text = "Chart (5-min)";
            this.chart5minToolStripMenuItem.Click += new System.EventHandler(this.chart5minToolStripMenuItem_Click);
            // 
            // chart15minToolStripMenuItem
            // 
            this.chart15minToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chart15minToolStripMenuItem.Image")));
            this.chart15minToolStripMenuItem.Name = "chart15minToolStripMenuItem";
            this.chart15minToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.chart15minToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.chart15minToolStripMenuItem.Text = "Chart (15-min)";
            this.chart15minToolStripMenuItem.Click += new System.EventHandler(this.chart15minToolStripMenuItem_Click);
            // 
            // chart30minToolStripMenuItem
            // 
            this.chart30minToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chart30minToolStripMenuItem.Image")));
            this.chart30minToolStripMenuItem.Name = "chart30minToolStripMenuItem";
            this.chart30minToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.chart30minToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.chart30minToolStripMenuItem.Text = "Chart (30-min)";
            this.chart30minToolStripMenuItem.Click += new System.EventHandler(this.chart30minToolStripMenuItem_Click);
            // 
            // chart2hrToolStripMenuItem
            // 
            this.chart2hrToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chart2hrToolStripMenuItem.Image")));
            this.chart2hrToolStripMenuItem.Name = "chart2hrToolStripMenuItem";
            this.chart2hrToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.chart2hrToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.chart2hrToolStripMenuItem.Text = "Chart (2-hr)";
            this.chart2hrToolStripMenuItem.Click += new System.EventHandler(this.chart2hrToolStripMenuItem_Click);
            // 
            // chartDayToolStripMenuItem
            // 
            this.chartDayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chartDayToolStripMenuItem.Image")));
            this.chartDayToolStripMenuItem.Name = "chartDayToolStripMenuItem";
            this.chartDayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.chartDayToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.chartDayToolStripMenuItem.Text = "Chart (day)";
            this.chartDayToolStripMenuItem.Click += new System.EventHandler(this.chartDayToolStripMenuItem_Click);
            // 
            // dailyHighScannerToolStripMenuItem
            // 
            this.dailyHighScannerToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.chart_line;
            this.dailyHighScannerToolStripMenuItem.Name = "dailyHighScannerToolStripMenuItem";
            this.dailyHighScannerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dailyHighScannerToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.dailyHighScannerToolStripMenuItem.Text = "Daily-High Scanner";
            this.dailyHighScannerToolStripMenuItem.Click += new System.EventHandler(this.dailyHighScannerToolStripMenuItem_Click);
            // 
            // orderBookToolStripMenuItem
            // 
            this.orderBookToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.book;
            this.orderBookToolStripMenuItem.Name = "orderBookToolStripMenuItem";
            this.orderBookToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.orderBookToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.orderBookToolStripMenuItem.Text = "Order book";
            this.orderBookToolStripMenuItem.Click += new System.EventHandler(this.orderBookToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.cog;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.application_tile_horizontal;
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.application_tile_vertical;
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verticalToolStripMenuItem.Text = "Tile vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Image = global::Cryptowatch.App.Properties.Resources.application_cascade;
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::Cryptowatch.App.Properties.Resources.information;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // hTTPRequestsToolStripMenuItem
            // 
            this.hTTPRequestsToolStripMenuItem.Name = "hTTPRequestsToolStripMenuItem";
            this.hTTPRequestsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.hTTPRequestsToolStripMenuItem.Text = "HTTP requests";
            this.hTTPRequestsToolStripMenuItem.Click += new System.EventHandler(this.hTTPRequestsToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Cryptowatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem symbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelSymbol;
        private System.Windows.Forms.ToolStripMenuItem dailyHighScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBtc;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart5minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart15minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart30minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart2hrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem orderBookToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem hTTPRequestsToolStripMenuItem;
    }
}