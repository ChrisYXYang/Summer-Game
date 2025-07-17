using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class CameraBehavior : BehaviorComponent
{
    private Transform _player;
    private float _speed = 50f; 

    public override void Start()
    {
        _player = SceneTools.GetGameObject("player").Transform;
    }

    public override void LateUpdate(GameTime gameTime)
    {
        Camera.position.X = _player.position.X;

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_player.position.Y <= -6.5)
        {
            Camera.position.Y = MathF.Max(-9, Camera.position.Y - (_speed * deltaTime));
        }
        else if (_player.position.Y > 3.5)
        {
            Camera.position.Y = MathF.Min(9, Camera.position.Y + (_speed * deltaTime));
        }
        else
        {
            if (Camera.position.Y > 0)
            {
                Camera.position.Y = MathF.Max(0, Camera.position.Y - (_speed * deltaTime));
            }
            else if (Camera.position.Y < 0)
            {
                Camera.position.Y = MathF.Min(0, Camera.position.Y + (_speed * deltaTime));
            }

        }
    }
}
