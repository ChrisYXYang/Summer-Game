using System;
using System.Collections.Generic;
using MyMonoGameLibrary.Scenes;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;

namespace summer_game;

public class Slime : Component, IGameBehavior
{
    private SpriteRenderer _spriteRenderer;
    private int _collisions = 0;
    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void OnCollisionEnter(ICollider other)
    {
        _spriteRenderer.Color = Color.Red;
        _collisions++;
    }

    public void OnCollisionExit(ICollider other)
    {
        _collisions--;

        if (_collisions == 0)
        {
            _spriteRenderer.Color = Color.White;
        }
    }

    public void OnCollisionStay(ICollider other)
    {

    }

    public void LateUpdate(GameTime gameTime)
    {
    }
}
