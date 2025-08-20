using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class FullscreenButton : Button
{
    private UISprite _sprite;
    private Check _check;

    public FullscreenButton(Sprite normal, Sprite hover) : base(normal, hover) { }


    public FullscreenButton(Sprite normal, Sprite hover, Sprite press) : base(normal, hover, press)
    {
    }

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
        _check = Parent.GetChild(0).GetComponent<Check>();

        base.Start();
    }


    public override void Clicked()
    {
        if (Core.Graphics.IsFullScreen)
        {
            Core.Graphics.IsFullScreen = false;
            Core.Graphics.ApplyChanges();

            _check.Off();
        }
        else
        {
            Core.Graphics.IsFullScreen = true;
            Core.Graphics.ApplyChanges();

            _check.On();
        }
    }
}
