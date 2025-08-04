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
        Parent.IgnorePause = true;

        base.Start();
    }

    public override void Update(GameTime gameTime)
    {
        if (SceneTools.Paused)
        {
            _sprite.IsVisible = false;
        }
        else
        {
            _sprite.IsVisible = true;
        }

        base.Update(gameTime);
    }

    public override void Clicked()
    {
        SceneTools.Paused = true;
    }
}
