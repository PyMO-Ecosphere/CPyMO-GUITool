using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Utils
{
    public static readonly string CPyMOToolExecutable;
    public static readonly string CPyMOExecutable;
    public static readonly string FFmpegExecutable;

    static IEnumerable<string> path =>
        Environment.GetEnvironmentVariable("PATH").Split(';');
    
    static string FindExecutable(string exeName)
    {
        var exeSuffix = ".exe";
        var filename = exeName + exeSuffix;

        var cwdFile = Path.Combine(Path.GetFullPath(filename));
        if (File.Exists(cwdFile)) return cwdFile;

        foreach (var dir in path)
        {
            var tryFile = Path.Combine(dir, filename);
            if (File.Exists(tryFile)) return tryFile;
        }

        return null;
    }

    static Utils()
    {
        CPyMOExecutable = FindExecutable("cpymo");
        CPyMOToolExecutable = FindExecutable("cpymo-tool");
        FFmpegExecutable = FindExecutable("ffmpeg");
    }

    public static void MsgBox(string msg, MessageBoxIcon icon = MessageBoxIcon.Information)
    {
        MessageBox.Show(msg, "CPyMO GUI Tool", MessageBoxButtons.OK, icon);
    }
}