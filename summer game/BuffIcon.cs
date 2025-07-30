using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class BuffIcon : BehaviorComponent
{
    private UISprite _sprite;
    private UIText _text;

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
        _text = Parent.GetChild(0).GetComponent<UIText>();
    }

    public void UpdateText(string time)
    {
        _text.Text = time;
    }

    public void TripleShot()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "triple shot ui");
    }

    public void EnhancedThrowing()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "enhanced throwing ui");
    }

    public void DoubleDamage()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "double damage ui");
    }

    public void SpeedUp()
    {
        _sprite.Sprite = Core.GlobalLibrary.GetSprite("characters", "speed up ui");
    }
}
