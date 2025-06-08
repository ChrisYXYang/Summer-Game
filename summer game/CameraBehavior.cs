using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scene;


namespace summer_game;

public class CameraBehavior : IBehavior
{
    Transform _playerTransform;
    
    public void Start()
    {
        _playerTransform = Core.Instance.GetGameObject("player").GetComponent<Transform>();
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void LateUpdate(GameTime gameTime)
    {
        Camera.position = _playerTransform.position;
    }

}
