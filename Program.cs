using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPyMO_GUITool
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Utils.CPyMOExecutable == null)
                Utils.MsgBox("找不到cpymo.exe，将无法启动游戏。");

            if (Utils.CPyMOToolExecutable == null)
                Utils.MsgBox("找不到cpymo-tool.exe！", MessageBoxIcon.Stop);

            Application.Run(new MainWindow());
        }
    }
}
