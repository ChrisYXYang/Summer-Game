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

public class ResumeButton : BehaviorComponent
{
    private UISprite _sprite;
    private Sprite _normal;
    private Sprite _hover;

    public override void Start()
    {
        _sprite = GetComponent<UISprite>();
        _normal = Core.GlobalLibrary.GetSprite("ui", "resume");
        _hover = Core.GlobalLibrary.GetSprite("ui", "resume_h");
        Parent.IgnorePause = true;
    }

    public override void Update(GameTime gameTime)
    {
        if (SceneTools.Paused)
        {
            _sprite.IsVisible = true;

            if (Collisions.MouseInUICollider(Parent.Collider))
            {
                _sprite.Sprite = _hover;

                if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left))
                    SceneTools.Paused = false;
            }
            else
            {
                _sprite.Sprite = _normal;
            }
        }
        else
        {
            _sprite.IsVisible = false;
        }
    }
}
