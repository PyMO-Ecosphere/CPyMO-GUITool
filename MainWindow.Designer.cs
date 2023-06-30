namespace CPyMO_GUITool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.gameInfoPanel = new System.Windows.Forms.Panel();
            this.startGameButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gameTitleView = new System.Windows.Forms.Label();
            this.gameIconView = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.convertTab = new System.Windows.Forms.TabPage();
            this.ffmpegNotFoundLabel = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.convSpecDescLabel = new System.Windows.Forms.Label();
            this.convSpecSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.packTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.filesToPack = new System.Windows.Forms.ListBox();
            this.unpackTab = new System.Windows.Forms.TabPage();
            this.unpackFileExtTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.packFileToUnpakBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.etcTab = new System.Windows.Forms.TabPage();
            this.stripButton = new System.Windows.Forms.Button();
            this.genAlbumButton = new System.Windows.Forms.Button();
            this.createDesktopShortcutButton = new System.Windows.Forms.Button();
            this.openGameDirButton = new System.Windows.Forms.Button();
            this.openGameFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.addFileToPackDialog = new System.Windows.Forms.OpenFileDialog();
            this.openPakFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outToFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.savePakFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gameInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameIconView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.convertTab.SuspendLayout();
            this.packTab.SuspendLayout();
            this.unpackTab.SuspendLayout();
            this.etcTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameInfoPanel
            // 
            this.gameInfoPanel.AllowDrop = true;
            this.gameInfoPanel.Controls.Add(this.startGameButton);
            this.gameInfoPanel.Controls.Add(this.button1);
            this.gameInfoPanel.Controls.Add(this.gameTitleView);
            this.gameInfoPanel.Controls.Add(this.gameIconView);
            this.gameInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gameInfoPanel.Location = new System.Drawing.Point(31, 32);
            this.gameInfoPanel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gameInfoPanel.Name = "gameInfoPanel";
            this.gameInfoPanel.Size = new System.Drawing.Size(666, 100);
            this.gameInfoPanel.TabIndex = 0;
            // 
            // startGameButton
            // 
            this.startGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startGameButton.Location = new System.Drawing.Point(478, 49);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(187, 38);
            this.startGameButton.TabIndex = 3;
            this.startGameButton.Text = "启动游戏";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(478, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "选择游戏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectGameButton_Clicked);
            // 
            // gameTitleView
            // 
            this.gameTitleView.AutoSize = true;
            this.gameTitleView.Dock = System.Windows.Forms.DockStyle.Left;
            this.gameTitleView.Location = new System.Drawing.Point(103, 0);
            this.gameTitleView.Margin = new System.Windows.Forms.Padding(0);
            this.gameTitleView.Name = "gameTitleView";
            this.gameTitleView.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.gameTitleView.Size = new System.Drawing.Size(173, 28);
            this.gameTitleView.TabIndex = 1;
            this.gameTitleView.Text = "(尚未选择游戏)";
            // 
            // gameIconView
            // 
            this.gameIconView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameIconView.Dock = System.Windows.Forms.DockStyle.Left;
            this.gameIconView.Location = new System.Drawing.Point(0, 0);
            this.gameIconView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gameIconView.Name = "gameIconView";
            this.gameIconView.Size = new System.Drawing.Size(103, 100);
            this.gameIconView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gameIconView.TabIndex = 0;
            this.gameIconView.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.convertTab);
            this.tabControl1.Controls.Add(this.packTab);
            this.tabControl1.Controls.Add(this.unpackTab);
            this.tabControl1.Controls.Add(this.etcTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(31, 143);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(666, 320);
            this.tabControl1.TabIndex = 4;
            // 
            // convertTab
            // 
            this.convertTab.Controls.Add(this.ffmpegNotFoundLabel);
            this.convertTab.Controls.Add(this.button8);
            this.convertTab.Controls.Add(this.convSpecDescLabel);
            this.convertTab.Controls.Add(this.convSpecSelectComboBox);
            this.convertTab.Controls.Add(this.label3);
            this.convertTab.Location = new System.Drawing.Point(4, 31);
            this.convertTab.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.convertTab.Name = "convertTab";
            this.convertTab.Padding = new System.Windows.Forms.Padding(29, 28, 29, 28);
            this.convertTab.Size = new System.Drawing.Size(658, 285);
            this.convertTab.TabIndex = 1;
            this.convertTab.Text = "转换";
            this.convertTab.UseVisualStyleBackColor = true;
            // 
            // ffmpegNotFoundLabel
            // 
            this.ffmpegNotFoundLabel.AutoSize = true;
            this.ffmpegNotFoundLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.ffmpegNotFoundLabel.Location = new System.Drawing.Point(6, 228);
            this.ffmpegNotFoundLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ffmpegNotFoundLabel.Name = "ffmpegNotFoundLabel";
            this.ffmpegNotFoundLabel.Size = new System.Drawing.Size(325, 42);
            this.ffmpegNotFoundLabel.TabIndex = 7;
            this.ffmpegNotFoundLabel.Text = "找不到FFmpeg\r\n目标平台可能无法播放音频和视频";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(468, 214);
            this.button8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(178, 56);
            this.button8.TabIndex = 6;
            this.button8.Text = "转换";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.convertGameButton_Clicked);
            // 
            // convSpecDescLabel
            // 
            this.convSpecDescLabel.AutoSize = true;
            this.convSpecDescLabel.Location = new System.Drawing.Point(196, 72);
            this.convSpecDescLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.convSpecDescLabel.Name = "convSpecDescLabel";
            this.convSpecDescLabel.Size = new System.Drawing.Size(94, 21);
            this.convSpecDescLabel.TabIndex = 5;
            this.convSpecDescLabel.Text = "平台说明";
            // 
            // convSpecSelectComboBox
            // 
            this.convSpecSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.convSpecSelectComboBox.FormattingEnabled = true;
            this.convSpecSelectComboBox.Location = new System.Drawing.Point(200, 32);
            this.convSpecSelectComboBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.convSpecSelectComboBox.Name = "convSpecSelectComboBox";
            this.convSpecSelectComboBox.Size = new System.Drawing.Size(250, 29);
            this.convSpecSelectComboBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "目标平台：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // packTab
            // 
            this.packTab.Controls.Add(this.button2);
            this.packTab.Controls.Add(this.button11);
            this.packTab.Controls.Add(this.button10);
            this.packTab.Controls.Add(this.button9);
            this.packTab.Controls.Add(this.filesToPack);
            this.packTab.Location = new System.Drawing.Point(4, 31);
            this.packTab.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.packTab.Name = "packTab";
            this.packTab.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.packTab.Size = new System.Drawing.Size(658, 285);
            this.packTab.TabIndex = 3;
            this.packTab.Text = "打包";
            this.packTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 229);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 40);
            this.button2.TabIndex = 4;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clearFilesToPackListButton_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(101, 229);
            this.button11.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(79, 40);
            this.button11.TabIndex = 3;
            this.button11.Text = "移除";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.removeFromFilesToPackListButton_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(11, 229);
            this.button10.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(79, 40);
            this.button10.TabIndex = 2;
            this.button10.Text = "添加";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.addFilesToPackButton_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(471, 229);
            this.button9.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(169, 40);
            this.button9.TabIndex = 1;
            this.button9.Text = "打包";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.packButton_Clicked);
            // 
            // filesToPack
            // 
            this.filesToPack.AllowDrop = true;
            this.filesToPack.Dock = System.Windows.Forms.DockStyle.Top;
            this.filesToPack.FormattingEnabled = true;
            this.filesToPack.ItemHeight = 21;
            this.filesToPack.Location = new System.Drawing.Point(6, 5);
            this.filesToPack.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.filesToPack.Name = "filesToPack";
            this.filesToPack.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filesToPack.Size = new System.Drawing.Size(646, 214);
            this.filesToPack.TabIndex = 0;
            // 
            // unpackTab
            // 
            this.unpackTab.Controls.Add(this.unpackFileExtTextBox);
            this.unpackTab.Controls.Add(this.label1);
            this.unpackTab.Controls.Add(this.button13);
            this.unpackTab.Controls.Add(this.packFileToUnpakBox);
            this.unpackTab.Controls.Add(this.label6);
            this.unpackTab.Location = new System.Drawing.Point(4, 31);
            this.unpackTab.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.unpackTab.Name = "unpackTab";
            this.unpackTab.Padding = new System.Windows.Forms.Padding(29, 28, 29, 28);
            this.unpackTab.Size = new System.Drawing.Size(658, 285);
            this.unpackTab.TabIndex = 4;
            this.unpackTab.Text = "解包";
            this.unpackTab.UseVisualStyleBackColor = true;
            // 
            // unpackFileExtTextBox
            // 
            this.unpackFileExtTextBox.Location = new System.Drawing.Point(248, 80);
            this.unpackFileExtTextBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.unpackFileExtTextBox.Name = "unpackFileExtTextBox";
            this.unpackFileExtTextBox.Size = new System.Drawing.Size(180, 31);
            this.unpackFileExtTextBox.TabIndex = 9;
            this.unpackFileExtTextBox.Text = ".png";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "解包后的扩展名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(468, 214);
            this.button13.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(178, 56);
            this.button13.TabIndex = 7;
            this.button13.Text = "解包";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.unpackButton_Clicked);
            // 
            // packFileToUnpakBox
            // 
            this.packFileToUnpakBox.FormattingEnabled = true;
            this.packFileToUnpakBox.Location = new System.Drawing.Point(248, 23);
            this.packFileToUnpakBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.packFileToUnpakBox.Name = "packFileToUnpakBox";
            this.packFileToUnpakBox.Size = new System.Drawing.Size(371, 29);
            this.packFileToUnpakBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(35, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "要解包的pak文件：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // etcTab
            // 
            this.etcTab.Controls.Add(this.stripButton);
            this.etcTab.Controls.Add(this.genAlbumButton);
            this.etcTab.Controls.Add(this.createDesktopShortcutButton);
            this.etcTab.Controls.Add(this.openGameDirButton);
            this.etcTab.Location = new System.Drawing.Point(4, 31);
            this.etcTab.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.etcTab.Name = "etcTab";
            this.etcTab.Padding = new System.Windows.Forms.Padding(29, 28, 29, 28);
            this.etcTab.Size = new System.Drawing.Size(658, 285);
            this.etcTab.TabIndex = 5;
            this.etcTab.Text = "杂项";
            this.etcTab.UseVisualStyleBackColor = true;
            // 
            // stripButton
            // 
            this.stripButton.Location = new System.Drawing.Point(35, 186);
            this.stripButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.stripButton.Name = "stripButton";
            this.stripButton.Size = new System.Drawing.Size(227, 40);
            this.stripButton.TabIndex = 3;
            this.stripButton.Text = "生成精简版本";
            this.stripButton.UseVisualStyleBackColor = true;
            this.stripButton.Click += new System.EventHandler(this.stripButton_Click);
            // 
            // genAlbumButton
            // 
            this.genAlbumButton.Location = new System.Drawing.Point(35, 135);
            this.genAlbumButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.genAlbumButton.Name = "genAlbumButton";
            this.genAlbumButton.Size = new System.Drawing.Size(227, 40);
            this.genAlbumButton.TabIndex = 2;
            this.genAlbumButton.Text = "生成相册界面缓存";
            this.genAlbumButton.UseVisualStyleBackColor = true;
            this.genAlbumButton.Click += new System.EventHandler(this.genAlbumButton_Click);
            // 
            // createDesktopShortcutButton
            // 
            this.createDesktopShortcutButton.Location = new System.Drawing.Point(35, 84);
            this.createDesktopShortcutButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.createDesktopShortcutButton.Name = "createDesktopShortcutButton";
            this.createDesktopShortcutButton.Size = new System.Drawing.Size(227, 40);
            this.createDesktopShortcutButton.TabIndex = 1;
            this.createDesktopShortcutButton.Text = "创建桌面快捷方式";
            this.createDesktopShortcutButton.UseVisualStyleBackColor = true;
            this.createDesktopShortcutButton.Click += new System.EventHandler(this.createDesktopShortcutButton_Click);
            // 
            // openGameDirButton
            // 
            this.openGameDirButton.Location = new System.Drawing.Point(35, 33);
            this.openGameDirButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.openGameDirButton.Name = "openGameDirButton";
            this.openGameDirButton.Size = new System.Drawing.Size(227, 40);
            this.openGameDirButton.TabIndex = 0;
            this.openGameDirButton.Text = "打开游戏文件夹";
            this.openGameDirButton.UseVisualStyleBackColor = true;
            this.openGameDirButton.Click += new System.EventHandler(this.openGameDirButton_Click);
            // 
            // openGameFolderDialog
            // 
            this.openGameFolderDialog.ShowNewFolderButton = false;
            // 
            // addFileToPackDialog
            // 
            this.addFileToPackDialog.Multiselect = true;
            this.addFileToPackDialog.SupportMultiDottedExtensions = true;
            this.addFileToPackDialog.Title = "添加文件到包";
            // 
            // openPakFileDialog
            // 
            this.openPakFileDialog.DefaultExt = "pak";
            this.openPakFileDialog.Filter = "PyMO PAK包|*.pak";
            this.openPakFileDialog.Title = "选择要解包的包文件";
            // 
            // outToFolderDialog
            // 
            this.outToFolderDialog.Description = "输出到";
            // 
            // savePakFileDialog
            // 
            this.savePakFileDialog.DefaultExt = "pak";
            this.savePakFileDialog.Filter = "PyMO PAK包|*.pak";
            this.savePakFileDialog.Title = "保存pak包到";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 495);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gameInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(31, 32, 31, 32);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPyMO GUI Tool";
            this.gameInfoPanel.ResumeLayout(false);
            this.gameInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameIconView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.convertTab.ResumeLayout(false);
            this.convertTab.PerformLayout();
            this.packTab.ResumeLayout(false);
            this.unpackTab.ResumeLayout(false);
            this.unpackTab.PerformLayout();
            this.etcTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gameInfoPanel;
        private System.Windows.Forms.PictureBox gameIconView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label gameTitleView;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage convertTab;
        private System.Windows.Forms.TabPage packTab;
        private System.Windows.Forms.TabPage unpackTab;
        private System.Windows.Forms.TabPage etcTab;
        private System.Windows.Forms.Button openGameDirButton;
        private System.Windows.Forms.Button stripButton;
        private System.Windows.Forms.Button genAlbumButton;
        private System.Windows.Forms.Button createDesktopShortcutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label convSpecDescLabel;
        private System.Windows.Forms.ComboBox convSpecSelectComboBox;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListBox filesToPack;
        private System.Windows.Forms.Label ffmpegNotFoundLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox packFileToUnpakBox;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.FolderBrowserDialog openGameFolderDialog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog addFileToPackDialog;
        private System.Windows.Forms.OpenFileDialog openPakFileDialog;
        private System.Windows.Forms.TextBox unpackFileExtTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog outToFolderDialog;
        private System.Windows.Forms.SaveFileDialog savePakFileDialog;
    }
}