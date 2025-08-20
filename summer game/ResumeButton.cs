using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class ResumeButton : Button
{
    private UISprite _sprite;

    public ResumeButton(Sprite normal, Sprite hover) : base(normal, hover)
    {
    }

    public ResumeButton(Sprite normal, Sprite hover, Sprite press) : base(normal, hover, press)
    {
    }

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();

        base.Start();
    }

    public override void Clicked()
    {
        MenuManager.Instance.Resume();
    }
}
