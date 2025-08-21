using System;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class DebugButton : Button
{
    private Check _check;

    public DebugButton(Sprite normal, Sprite hover) : base(normal, hover)
    {
    }

    public DebugButton(Sprite normal, Sprite hover, Sprite press) : base(normal, hover, press)
    {
    }

    public override void Start()
    {
        _check = Parent.GetChild(0).GetComponent<Check>();
        _check.Off();

        base.Start();
    }

    public override void Clicked()
    {
        if (Settings.Debug)
        {
            Settings.Debug = false;
            _check.Off();
        }
        else
        {
            Settings.Debug = true;
            _check.On();
        }
    }
}
