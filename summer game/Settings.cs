using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summer_game;

public static class Settings
{
    // settings
    public static bool Debug { get; set; } = false;

    private static int _musicSound;
    public static int MusicSound
    {
        get => _musicSound;
        set => _musicSound = int.Clamp(value, 0, 5);
    }

    private static int _sfxSound;
    public static int SFXSound
    {
        get => _sfxSound;
        set => _sfxSound = int.Clamp(value, 0, 5);
    }
}
