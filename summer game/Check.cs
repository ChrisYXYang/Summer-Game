using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class Check : BehaviorComponent
{
    private UISprite _sprite;

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
    }

    public void On()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("ui", "on");
    }

    public void Off()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("ui", "off");
    }
}
