using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.UI;
using MyMonoGameLibrary;
using System.Diagnostics;

namespace summer_game;

public class PauseButton : Button
{
    private UISprite _sprite;

    public PauseButton(Sprite normal, Sprite hover) : base(normal, hover) { }
    

    public PauseButton(Sprite normal, Sprite hover, Sprite press) : base(normal, hover, press)
    {
    }

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();

        base.Start();
    }


    public override void Clicked()
    {
        MenuUI.Instance.Pause();
    }
}
