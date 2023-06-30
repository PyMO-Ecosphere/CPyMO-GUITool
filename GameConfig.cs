using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;

class GameConfig
{
    public string GameDir { get; }
    public string GameTitle { get; }
    public string GamePlatform { get; }
    public Tuple<int, int> ImageSize { get; }
    public string IconPath
    {
        get
        {
            var path = Path.Combine(GameDir, "./icon.png");
            if (File.Exists(path)) return path;
            else return null;
        }
    }

    public void OpenInFileExplorer()
    {
        System.Diagnostics.Process.Start("explorer.exe", GameDir);
    }

    string EnsureWindowsIcoFile()
    {
        if (IconPath == null) return null;

        var icoPath = Path.Combine(GameDir, "icon.ico");
        if (File.Exists(icoPath)) return icoPath;
        if (!BitConverter.IsLittleEndian) return null;

        using (var iconBitmapOrg = new Bitmap(IconPath))
        {
            using (var iconBitmap = new Bitmap(iconBitmapOrg, 64, 64))
            {
                using (var iconBitmapStream = new MemoryStream())
                {
                    iconBitmap.Save(iconBitmapStream, ImageFormat.Png);
                    iconBitmapStream.Flush();
                    using (var fs = File.Open(icoPath, FileMode.Create))
                    {
                        using (var icoWriter = new BinaryWriter(fs))
                        {

                            icoWriter.Write((byte)0);
                            icoWriter.Write((byte)0);

                            icoWriter.Write((short)1);
                            icoWriter.Write((short)1);
                            icoWriter.Write((byte)iconBitmap.Width);
                            icoWriter.Write((byte)iconBitmap.Height);

                            icoWriter.Write((byte)0);
                            icoWriter.Write((byte)0);
                            icoWriter.Write((short)0);
                            icoWriter.Write((short)32);
                            icoWriter.Write((int)iconBitmapStream.Length);
                            icoWriter.Write(6 + 16);
                            icoWriter.Write(iconBitmapStream.ToArray());
                            icoWriter.Flush();

                            icoWriter.Close();
                            fs.Close();

                            return icoPath;
                        }
                    }
                }
            }
        }
    }

    private readonly IReadOnlyDictionary<string, string[]> gameConfig;

    public string GetValue(string key)
    {
        try { return gameConfig[key][0]; }
        catch { return null; }
    }

    private GameConfig(string dir)
    {
        var gameConfigPath = Path.Combine(dir, "./gameconfig.txt");
        gameConfig = File.ReadAllLines(gameConfigPath)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(','))
            .ToDictionary(x => x[0], x => x.Skip(1).ToArray());
        GameDir = dir;

        try { GameTitle = gameConfig["gametitle"][0].Replace("\\n", "\n"); }
        catch { GameTitle = "Unknown"; }

        try { GamePlatform = gameConfig["platform"][0]; }
        catch { GamePlatform = ""; }

        var imageSize = gameConfig["imagesize"];
        ImageSize = Tuple.Create(
            int.Parse(imageSize[0]), int.Parse(imageSize[1]));
    }

    public static GameConfig FromGameDir(string dir)
    {
        try { return new GameConfig(dir); }
        catch { return null; }
    }

    public void CreateShortcutOnDesktop()
    {
        var desktopDir = Environment.GetFolderPath(
            Environment.SpecialFolder.Desktop);
        var lnkFileName =
            GameTitle
                .Split('\n')
                .Where(x => !string.IsNullOrEmpty(x))
                .FirstOrDefault();

        var lnkPath = Path.Combine(desktopDir, lnkFileName + ".lnk");

        var shellType = Type.GetTypeFromProgID("WScript.Shell");
        dynamic shell = Activator.CreateInstance(shellType);
        var shortcut = shell.CreateShortcut(lnkPath);
        shortcut.TargetPath = Utils.CPyMOExecutable;
        if (IconPath != null) shortcut.IconLocation = EnsureWindowsIcoFile();
        shortcut.WorkingDirectory = GameDir;
        shortcut.Save();
    }

    public struct ConvertSpec
    {
        public string Name;
        public string Description;
        public int Width;
        public int Height;

        public ConvertSpec(
            string name,
            int w,
            int h,
            string desc)
        {
            Name = name;
            Description = desc;
            Width = w;
            Height = h;
        }
    }

    public readonly static ConvertSpec[] ConvertSpecs = new ConvertSpec[]
    {
        new ConvertSpec("s60v3", 320, 240, "适用于塞班S60v3上的PyMO"),
        new ConvertSpec("s60v5", 540, 360, "适用于塞班S60v5上的PyMO"),
        new ConvertSpec("pymo", 800, 600, "适用于安卓/PC上的PyMO"),
        new ConvertSpec("3ds", 400, 300, "适用于任天堂3DS系列上的CPyMO"),
        new ConvertSpec("wii", 640, 480, "适用于任天堂Wii上的CPyMO"),
        new ConvertSpec("psp", 480, 272, "适用于索尼PSP上的CPyMO")
    };

    public string GetFormat(string assType)
    {
        switch (assType)
        {
            case "bg": return GetValue("bgformat");
            case "chara": return GetValue("charaformat");
            case "se": return GetValue("seformat");
            case "voice": return GetValue("voiceformat");
            default: return null;
        }
    }
}