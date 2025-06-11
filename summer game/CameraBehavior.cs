using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class CameraBehavior : IBehavior
{
    Transform _playerTransform;
    
    public CameraBehavior(GameObject player)
    {
        _playerTransform = player.GetComponent<Transform>();
    }

    public void Start()
    {

    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void LateUpdate(GameTime gameTime)
    {
        Camera.position = _playerTransform.position;
    }

}
