﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPyMO_GUITool
{
    public partial class MainWindow : Form
    {
        GameConfig gameConfig;

        void RefreshUI()
        {
            packFileToUnpakBox.Items.Clear();

            if (gameConfig == null)
            {
                gameIconView.Image = null;
                gameTitleView.Text = "（尚未选择游戏）";
                startGameButton.Enabled = false;

                foreach (Control c in convertTab.Controls)
                    c.Enabled = false;

                foreach (Control c in etcTab.Controls)
                    c.Enabled = false;
            }
            else
            {
                gameIconView.Image = Image.FromFile(gameConfig.IconPath);
                gameTitleView.Text = gameConfig.GameTitle;
                startGameButton.Enabled = true;

                foreach (Control c in convertTab.Controls)
                    c.Enabled = true;

                foreach (Control c in etcTab.Controls)
                    c.Enabled = true;

                void addPackageNameToPackFileToUnpakBox(string assName)
                {
                    var targetPath = Path.Combine(gameConfig.GameDir, assName, assName + ".pak");
                    if (File.Exists(targetPath))
                        packFileToUnpakBox.Items.Add(assName + "\\" + assName + ".pak");
                }

                addPackageNameToPackFileToUnpakBox("bg");
                addPackageNameToPackFileToUnpakBox("chara");
                addPackageNameToPackFileToUnpakBox("se");
                addPackageNameToPackFileToUnpakBox("voice");
            }

            packFileToUnpakBox.Items.Add("浏览...");

            ffmpegNotFoundLabel.Visible =
                Utils.FFmpegExecutable == null;

            if (Utils.CPyMOExecutable == null)
            {
                startGameButton.Enabled = false;
                createDesktopShortcutButton.Enabled = false;
            }

            if (Utils.CPyMOToolExecutable == null)
            {
                foreach (Control c in convertTab.Controls)
                    c.Enabled = false;

                foreach (Control c in packTab.Controls)
                    c.Enabled = false;

                foreach (Control c in unpackTab.Controls)
                    c.Enabled = false;

                genAlbumButton.Enabled = false;
                stripButton.Enabled = false;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            convSpecSelectComboBox.Items.AddRange(
                GameConfig.ConvertSpecs.Select(x => x.Name).ToArray());
            convSpecSelectComboBox.SelectedIndexChanged += (_0, _1) =>
            {
                var spec = GameConfig.ConvertSpecs[convSpecSelectComboBox.SelectedIndex];
                convSpecDescLabel.Text =
                    spec.Description
                    + Environment.NewLine
                    + Environment.NewLine
                    + "目标分辨率：" + spec.Width + "x" + spec.Height;
            };
            convSpecSelectComboBox.SelectedIndex = 0;

            packFileToUnpakBox.SelectionChangeCommitted += (_0, _1) =>
            {
                if (packFileToUnpakBox.SelectedItem == null) return;

                if ((string)packFileToUnpakBox.SelectedItem == "浏览...")
                {
                    if (openPakFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            packFileToUnpakBox.Text = openPakFileDialog.FileName;
                        }));
                    }
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        packFileToUnpakBox.Text =
                            Path.Combine(
                                gameConfig.GameDir,
                                (string)packFileToUnpakBox.SelectedItem);
                    }));
                }
            };

            packFileToUnpakBox.TextChanged += (_0, _1) =>
            {
                var assDir = Path.GetDirectoryName(packFileToUnpakBox.Text);
                GameConfig g = GameConfig.FromGameDir(Path.Combine(assDir, ".."));
                if (g == null) return;

                unpackFileExtTextBox.Text = 
                    g.GetFormat(Path.GetFileNameWithoutExtension(packFileToUnpakBox.Text));
            };

            RefreshUI();
        }

        private void selectGameButton_Clicked(object sender, EventArgs e)
        {
            if (openGameFolderDialog.ShowDialog() == DialogResult.OK)
            {
                var dir = openGameFolderDialog.SelectedPath;
                var gameConfig = GameConfig.FromGameDir(dir);
                if (gameConfig == null) 
                {
                    Utils.MsgBox(dir + " 不是有效的pymo游戏。", MessageBoxIcon.Error);
                    return;
                }

                this.gameConfig = gameConfig;
                RefreshUI();
            }
        }

        private void openGameDirButton_Click(object sender, EventArgs e)
        {
            gameConfig.OpenInFileExplorer();
        }

        private void createDesktopShortcutButton_Click(object sender, EventArgs e)
        {
            gameConfig.CreateShortcutOnDesktop();
            Utils.MsgBox("成功创建桌面快捷方式！", MessageBoxIcon.Information);
        }

        class FilesToPack
        {
            public string Filename;
            public override string ToString() => Path.GetFileName(Filename);
        }

        private void addFilesToPackButton_Click(object sender, EventArgs e)
        {
            if (addFileToPackDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var f in addFileToPackDialog.FileNames)
                    filesToPack.Items.Add(new FilesToPack() { Filename = f });
            }
            
        }

        private void removeFromFilesToPackListButton_Click(object sender, EventArgs e)
        {
            var selected = new List<FilesToPack>();
            foreach (FilesToPack f in filesToPack.SelectedItems)
                selected.Add(f);

            foreach (var s in selected)
                filesToPack.Items.Remove(s);

        }

        private void clearFilesToPackListButton_Click(object sender, EventArgs e)
        {
            filesToPack.Items.Clear();
        }
    }
}
