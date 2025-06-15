using System;
using System.Collections.Generic;
using MyMonoGameLibrary.Scenes;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;

namespace summer_game;

public class Slime : BehaviorComponent
{
    private SpriteRenderer _spriteRenderer;
    private int _collisions = 0;
    public override void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void OnCollisionEnter(ICollider other)
    {
        _spriteRenderer.Color = Color.Red;
        _collisions++;
    }

    public override void OnCollisionExit(ICollider other)
    {
        _collisions--;

        if (_collisions == 0)
        {
            _spriteRenderer.Color = Color.White;
        }
    }
}
