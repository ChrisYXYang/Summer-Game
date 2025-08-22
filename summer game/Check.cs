using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class Check : BehaviorComponent
{
    private Func<bool> _condition;
    private UISprite _sprite;

    public Check(Func<bool> condition)
    {
        _condition = condition;
    }
    
    public override void Awake()
    {
        _sprite = GetComponent<UISprite>();
    }

    public override void Update(GameTime gameTime)
    {
        bool decide = _condition.Invoke();

        if (decide)
        {
            _sprite.Sprite = Core.GlobalLibrary.GetSprite("ui", "on");
        }
        else
        {
            _sprite.Sprite = Core.GlobalLibrary.GetSprite("ui", "off");

        }
    }
}
