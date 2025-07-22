using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;

namespace summer_game;

// movement for the player
public class PlayerMovement : BehaviorComponent
{
    // variables and properties
    public float JumpPower { get; set; }
    public float MoveSpeed { get; set; }
    public float DashVelocity { get; set; }
    public float DashTime { get; set; }
    public bool Dashing { get; private set; } = false;

    private Rigidbody _rb;
    private SpriteRenderer _spriteRenderer;
    private Animation _idle;
    private Animation _run;
    private Animation _jump;
    private Animation _fall;
    private Animation _dash;
    private float _jumpBuffer;
    private float _stopDashTime;
    private bool _canDash = true;
    private bool _running;

    // constructor
    //
    // param: speed - movement speed
    public PlayerMovement(float speed, float jumpPower, float dashVelocity, float dashTime)
    {
        MoveSpeed = speed;
        JumpPower = jumpPower;
        DashVelocity = dashVelocity;
        DashTime = dashTime;
    }


    public override void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _idle = Core.GlobalLibrary.GetAnimation("characters", "player_idle");
        _run = Core.GlobalLibrary.GetAnimation("characters", "player_run");
        _jump = Core.GlobalLibrary.GetAnimation("characters", "player_jump");
        _fall = Core.GlobalLibrary.GetAnimation("characters", "player_fall");
        _dash = Core.GlobalLibrary.GetAnimation("characters", "player_dash");
    }

    // update
    //
    // param: gameTime - get the game time
    public override void Update(GameTime gameTime)
    {
        // get game time
        float time = (float)gameTime.TotalGameTime.TotalSeconds;

        // dash
        if (!Dashing && Parent.Rigidbody.TouchingBottom)
        {
            _canDash = true;
        }

        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Right) &&
            (InputManager.Keyboard.IsKeyDown(Keys.A) || InputManager.Keyboard.IsKeyDown(Keys.D))
            && _canDash && !Dashing)
        {
            Dashing = true;
            _canDash = false;
            _stopDashTime = time + DashTime;
            Parent.Animator.Animation = _dash;

            if (InputManager.Keyboard.IsKeyDown(Keys.A))
            {
                Parent.Rigidbody.XVelocity = -DashVelocity;
                _spriteRenderer.FlipX = true;
            }
            else if (InputManager.Keyboard.IsKeyDown(Keys.D))
            {
                Parent.Rigidbody.XVelocity = DashVelocity;
                _spriteRenderer.FlipX = false;

            }
        }
        
        if (Dashing && time >= _stopDashTime)
        {
            Dashing = false;
            Parent.Rigidbody.XVelocity = 0;
        }

        if (!Dashing && Parent.Rigidbody.TouchingBottom)
        {
            _canDash = true;
        }

        if (_canDash)
        {
            _spriteRenderer.Color = Color.White;

        }
        else
        {
            _spriteRenderer.Color = Color.Blue;

        }

        // jump input handling
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.W))
        {
            _jumpBuffer = 0.1f + time;
        }

        if (!Dashing)
        {
            // left and right movement
            if (InputManager.Keyboard.IsKeyDown(Keys.A) || InputManager.Keyboard.IsKeyDown(Keys.D))
            {
                _running = true;

                if (InputManager.Keyboard.IsKeyDown(Keys.A))
                {
                    _rb.MovePosition(-MoveSpeed, 0);
                }
                if (InputManager.Keyboard.IsKeyDown(Keys.D))
                {
                    _rb.MovePosition(MoveSpeed, 0);
                }
            }
            else
            {
                _running = false;
            }

            if (_jumpBuffer >= time && _rb.TouchingBottom)
            {
                _rb.YVelocity -= JumpPower;
                Core.Audio.PlaySoundEffect(Core.GlobalLibrary.GetSoundEffect("collect"));
            }

            if (_rb.YVelocity < 0 && !InputManager.Keyboard.IsKeyDown(Keys.W))
            {
                _rb.YVelocity += SceneTools.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // descending platform
            if (InputManager.Keyboard.IsKeyDown(Keys.S))
            {
                Parent.Rigidbody.DescendPlatform = true;
            }
            else
            {
                Parent.Rigidbody.DescendPlatform = false;
            }

            // handle animation
            if (_rb.YVelocity < 0)
            {
                Parent.Animator.Animation = _jump;
            }
            else if (_rb.YVelocity > 0)
            {
                Parent.Animator.Animation = _fall;
            }
            else
            {
                if (_running)
                {
                    Parent.Animator.Animation = _run;
                }
                else
                {
                    Parent.Animator.Animation = _idle;
                }
            }
        }
    }
}
