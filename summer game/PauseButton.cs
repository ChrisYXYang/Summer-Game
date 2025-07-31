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

public class PauseButton : BehaviorComponent
{
    private UISprite _sprite;
    private Sprite _normal;
    private Sprite _hover;

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
        _normal = Core.GlobalLibrary.GetSprite("ui", "pause");
        _hover = Core.GlobalLibrary.GetSprite("ui", "pause_h");
        Parent.IgnorePause = true;
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

            if (Collisions.MouseInUICollider(Parent.Collider))
            {
                _sprite.Sprite = _hover;

                if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left))
                    SceneTools.Paused = true;
            }
            else
            {
                _sprite.Sprite = _normal;
            }
        }
    }
}
