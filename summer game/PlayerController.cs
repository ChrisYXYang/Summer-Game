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
    private int _collisions = 0;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider _collider;
    private bool _canDash = false;

    // initialize
    //
    // param: parent - parent game object
    public override void Initialize(GameObject parent)
    {
        base.Initialize(parent);
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider>();
    }

    public void Start()
    {

    }

    // update
    //
    // param: gameTime - get the game time
    public void Update(GameTime gameTime)
    {
        if (Collisions.PointInCollider(_collider, Camera.PixelToUnit(InputManager.Mouse.Position)))
        {
            _spriteRenderer.Color = Color.Red;
        }
        else
        {
            _spriteRenderer.Color = Color.White;
        }

        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left)
            && Collisions.PointInCollider(_collider, Camera.PixelToUnit(InputManager.Mouse.Position)))
        {
            _canDash = true;
        }


        if (InputManager.Mouse.WasButtonJustReleased(MouseButton.Left) && _canDash)
        {
            _transform.position = Camera.PixelToUnit(InputManager.Mouse.Position);
            _canDash = false;
        }
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
