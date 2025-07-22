using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class HeartIcon : BehaviorComponent
{
    private UISprite _sprite;

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
        Debug.WriteLine("gub");
    }
    
    public void Full()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "heart ui");
    }

    public void Half()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "half heart ui");
    }

    public void Empty()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "empty heart ui");
    }

    public void IceFull()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "ice heart ui");
    }

    public void IceHalf()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "half ice heart ui");
    }
}
