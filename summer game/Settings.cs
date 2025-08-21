using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;

namespace summer_game;

public static class Settings
{
    // settings
    public static bool Debug { get; set; } = false;

    private static int _musicSound = 5;
    public static int MusicSound
    {
        get => _musicSound;
        set
        {
            _musicSound = int.Clamp(value, 0, 5);

            Core.Audio.SongVolume = _musicSound * 0.2f;
        }
    }

    private static int _sfxSound = 5;
    public static int SFXSound
    {
        get => _sfxSound;
        set
        {
            _sfxSound = int.Clamp(value, 0, 5);

            Core.Audio.SoundEffectVolume = _sfxSound * 0.2f;

        }
    }
}
