using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

// controller for the player
public class PlayerController : Component, IGameBehavior
{
    // variables and properties
    public float MoveSpeed { get; set; }
    private int _collisions = 0;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction = new();

    // constructor
    //
    // param: speed - movement speed
    public PlayerController(float speed)
    {
        MoveSpeed = speed;
    }

    // initialize
    //
    // param: parent - parent game object
    public override void Initialize(GameObject parent)
    {
        base.Initialize(parent);
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {

    }

    // update
    //
    // param: gameTime - get the game time
    public void Update(GameTime gameTime)
    {
        //move the player
        float speed = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // get movement direction
        if (InputManager.Keyboard.IsKeyDown(Keys.W) && InputManager.Keyboard.IsKeyDown(Keys.S))
        {
            _direction.Y = 0;
        }
        else if (InputManager.Keyboard.IsKeyDown(Keys.W))
        {
            _direction.Y = -1;
        }
        else if (InputManager.Keyboard.IsKeyDown(Keys.S))
        {
            _direction.Y = 1;
        }
        else
        {
            _direction.Y = 0;
        }

        if (InputManager.Keyboard.IsKeyDown(Keys.A) && InputManager.Keyboard.IsKeyDown(Keys.D))
        {
            _direction.X = 0;
        }
        else if (InputManager.Keyboard.IsKeyDown(Keys.A))
        {
            _direction.X = -1;
        }
        else if (InputManager.Keyboard.IsKeyDown(Keys.D))
        {
            _direction.X = 1;
        }
        else
        {
            _direction.X = 0;
        }

        // move player
        if (!_direction.Equals(Vector2.Zero))
            _direction = Vector2.Normalize(_direction);

        _transform.position += _direction * speed;
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
