using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class SoundButton : Press
{
    public bool Left { get; set; }
    public bool Music { get; set; }
    
    public SoundButton(Sprite normal, Sprite hover) : base(normal, hover)
    {
    }

    public override void Clicked()
    {
        if (Left)
        {
            if (Music)
                Settings.MusicSound--;
            else
                Settings.SFXSound--;
        }
        else
        {
            if (Music)
                Settings.MusicSound++;
            else
                Settings.SFXSound++;
        }
    }
}
