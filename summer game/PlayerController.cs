using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

// movement controller for the player
public class PlayerController : BehaviorComponent
{
    // variables and properties
    public float JumpPower { get; set; }
    public float MoveSpeed { get; set; }
    private int _collisions = 0;

    private Rigidbody _rb;
    private SpriteRenderer _spriteRenderer;

    // constructor
    //
    // param: speed - movement speed
    public PlayerController(float speed, float jumpPower)
    {
        MoveSpeed = speed;
        JumpPower = jumpPower;
    }


    public override void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // update
    //
    // param: gameTime - get the game time
    public override void Update(GameTime gameTime)
    {
        // left and right movement
        if (InputManager.Keyboard.IsKeyDown(Keys.A))
        {
            _rb.MovePosition(-MoveSpeed, 0);
        }
        if (InputManager.Keyboard.IsKeyDown(Keys.D))
        {
            _rb.MovePosition(MoveSpeed, 0);
        }

        if (InputManager.Keyboard.IsKeyDown(Keys.W) && _rb.TouchingBottom)
        {
            _rb.YVelocity -= JumpPower;
        }
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
