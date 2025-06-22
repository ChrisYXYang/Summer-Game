using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class CameraBehavior : BehaviorComponent
{
    private Transform _playerTransform;

    public override void Start()
    {
        _playerTransform = SceneTools.GetGameObject("player").GetComponent<Transform>();
    }

    public override void LateUpdate(GameTime gameTime)
    {
        Camera.position = _playerTransform.position;
    }
}
