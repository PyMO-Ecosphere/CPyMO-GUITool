using System;
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

        void refreshUI()
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

            gameInfoPanel.DragEnter += (_0, e) =>
            {
                e.Effect = DragDropEffects.Link;
            };

            gameInfoPanel.DragDrop += (_0, e) =>
            {
                string[] dirs = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                var dir = dirs.FirstOrDefault();
                if (dir != null)
                    openPyMOGame(dir);
            };

            filesToPack.DragEnter += (_0, e) =>
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            };

            filesToPack.DragDrop += (_, e) =>
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (var f in files)
                {
                    if (File.Exists(f))
                        filesToPack.Items.Add(new FilesToPack() { Filename = f });
                    else if (Directory.Exists(f))
                    {
                        var fs = Directory.GetFiles(f, "*", SearchOption.AllDirectories);
                        foreach (var ff in fs)
                            filesToPack.Items.Add(new FilesToPack() { Filename = ff });
                    }
                }

                refreshPackFilesCount();
            };

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

            refreshUI();
        }

        void openPyMOGame(string dir)
        {
            var gameConfig = GameConfig.FromGameDir(dir);
            if (gameConfig == null)
            {
                Utils.MsgBox(dir + " 不是有效的pymo游戏。", MessageBoxIcon.Error);
                return;
            }

            this.gameConfig = gameConfig;
            refreshUI();
        }

        private void selectGameButton_Clicked(object sender, EventArgs e)
        {
            if (openGameFolderDialog.ShowDialog() == DialogResult.OK)
                openPyMOGame(openGameFolderDialog.SelectedPath);
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

            refreshPackFilesCount();
        }

        private void removeFromFilesToPackListButton_Click(object sender, EventArgs e)
        {
            var selected = new List<FilesToPack>();
            foreach (FilesToPack f in filesToPack.SelectedItems)
                selected.Add(f);

            foreach (var s in selected)
                filesToPack.Items.Remove(s);

            refreshPackFilesCount();
        }

        private void clearFilesToPackListButton_Click(object sender, EventArgs e)
        {
            filesToPack.Items.Clear();
            refreshPackFilesCount();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            runProcessAndWait(Utils.CPyMOExecutable, "", _ => { }, true, gameConfig.GameDir);
        }

        void refreshPackFilesCount()
        {
            long bytes = 0;
            foreach (var i in filesToPack.Items)
                bytes += new FileInfo(((FilesToPack)i).Filename).Length;

            double mibs = (double)bytes / 1024.0 / 1024.0;
            packFilesCountLabel.Text = filesToPack.Items.Count + "个文件，" + mibs.ToString("0.00") + "MiB";
        }

        void runProcessAndWait(
            string filename, string args, Action<int> onFinished, bool longTime = true, string workDir = "")
        {
            if (longTime) WindowState = FormWindowState.Minimized;

            var startInfo = new System.Diagnostics.ProcessStartInfo()
            {
                FileName = filename,
                Arguments = args,
                WorkingDirectory = workDir
            };

            var prc = new System.Diagnostics.Process()
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };

            prc.Exited += (_0, _1) =>
            {
                Invoke(new Action(() =>
                {
                    onFinished(prc.ExitCode);
                    Enabled = true;
                    if (longTime) WindowState = FormWindowState.Normal;
                }));
            };

            Enabled = false;
            prc.Start();
        }

        private void genAlbumButton_Click(object sender, EventArgs e)
        {
            runProcessAndWait(
                Utils.CPyMOToolExecutable,
                "gen-album-cache \"" + gameConfig.GameDir + "\"",
                exitCode =>
                {
                    if (exitCode == 0) Utils.MsgBox("生成成功！");
                    else Utils.MsgBox("生成失败！错误代码：" + exitCode, MessageBoxIcon.Error);
                },
                false);
        }

        private void stripButton_Click(object sender, EventArgs e)
        {
            if (outToFolderDialog.ShowDialog() == DialogResult.OK)
            {
                runProcessAndWait(
                    Utils.CPyMOToolExecutable,
                    "strip \"" + gameConfig.GameDir + "\" " + "\"" + outToFolderDialog.SelectedPath + "\"",
                    exitCode =>
                    {
                        if (exitCode == 0) Utils.MsgBox("精简成功！");
                        else Utils.MsgBox("精简失败！错误代码：" + exitCode, MessageBoxIcon.Error);
                    });
            }
        }

        private void convertGameButton_Clicked(object sender, EventArgs e)
        {
            if (outToFolderDialog.ShowDialog() == DialogResult.OK)
            {
                runProcessAndWait(
                    Utils.CPyMOToolExecutable,
                    "convert " + convSpecSelectComboBox.Text + " \"" + gameConfig.GameDir + "\" \"" + outToFolderDialog.SelectedPath + "\"",
                    exitCode =>
                    {
                        if (exitCode == 0) Utils.MsgBox("转换完成！");
                        else Utils.MsgBox("转换失败！错误代码：" + exitCode, MessageBoxIcon.Error);
                    });
            }
        }

        private void unpackButton_Clicked(object sender, EventArgs e)
        {
            var ext = unpackFileExtTextBox.Text;
            var pakPath = packFileToUnpakBox.Text;

            if (!File.Exists(pakPath))
            {
                Utils.MsgBox(pakPath + " 不存在！", MessageBoxIcon.Error);
                return;
            }

            if (!ext.StartsWith(".") || ext.Length < 2)
            {
                Utils.MsgBox("扩展名必须以.开头，并且至少有两个字符长。", MessageBoxIcon.Error);
                return;
            }

            if (outToFolderDialog.ShowDialog() == DialogResult.OK)
            {
                runProcessAndWait(
                    Utils.CPyMOToolExecutable,
                    "unpack \"" + pakPath + "\" " + ext + " \"" + outToFolderDialog.SelectedPath + "\"",
                    exitCode =>
                    {
                        if (exitCode == 0) Utils.MsgBox("解包成功！");
                        else Utils.MsgBox("解包失败！错误代码：" + exitCode, MessageBoxIcon.Error);
                    });
            }
        }

        private void packButton_Clicked(object sender, EventArgs e)
        {
            if (gameConfig != null) savePakFileDialog.InitialDirectory = gameConfig.GameDir;

            var filesToPack = new List<string>();
            foreach (FilesToPack f in this.filesToPack.Items)
                filesToPack.Add(f.Filename.Replace('\\', '/'));

            if (filesToPack.Count <= 0)
            {
                Utils.MsgBox("没有文件需要被打包。");
                return;
            }

            if (savePakFileDialog.ShowDialog() == DialogResult.OK)
            {
                var listFile = Path.GetTempFileName();
                File.WriteAllLines(listFile, filesToPack.Distinct(), Encoding.Default);

                runProcessAndWait(
                    Utils.CPyMOToolExecutable,
                    "pack \"" + savePakFileDialog.FileName + "\" --file-list \"" + listFile + "\"",
                    exitCode =>
                    {
                        File.Delete(listFile);
                        if (exitCode == 0) Utils.MsgBox("打包成功！");
                        else Utils.MsgBox("打包失败！错误代码：" + exitCode, MessageBoxIcon.Error);
                    });
            }
        }
    }
}
