using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

// movement for the player
public class PlayerMovement : BehaviorComponent
{
    // variables and properties
    public float JumpPower { get; set; }
    public float MoveSpeed { get; set; }

    private Rigidbody _rb;

    // constructor
    //
    // param: speed - movement speed
    public PlayerMovement(float speed, float jumpPower)
    {
        MoveSpeed = speed;
        JumpPower = jumpPower;
    }


    public override void Start()
    {
        _rb = GetComponent<Rigidbody>();
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

    }

    public override void OnCollisionExit(ICollider other)
    {
    }
}
