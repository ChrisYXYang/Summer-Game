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
    public float Range { get; set; }

    private int _collisions = 0;
    private Transform _transform;
    private Transform _guideTransform;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _guideRenderer;
    private CircleCollider _collider;
    private bool _canDash = false;


    // constructor
    //
    // param: range - dash range
    public PlayerController(float range)
    {
        Range = range;
    }

    public void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider>();
        GameObject guide = SceneTools.GetGameObject("guide");
        _guideTransform = guide.GetComponent<Transform>();
        _guideRenderer = guide.GetComponent<SpriteRenderer>();
    }

    // update
    //
    // param: gameTime - get the game time
    public void Update(GameTime gameTime)
    {
        Vector2 mousePos = Camera.PixelToUnit(InputManager.Mouse.Position);


        if (Collisions.PointInCollider(_collider, mousePos))
        {
            _spriteRenderer.Color = Color.Red;
        }
        else
        {
            _spriteRenderer.Color = Color.White;
        }



        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left)
            && Collisions.PointInCollider(_collider, mousePos))
        {
            _canDash = true;
        }

        if (_canDash)
        {
            _guideRenderer.IsVisible = true;

            if (Range * Range >= Vector2.DistanceSquared(mousePos, _transform.position))
                    _guideTransform.position = mousePos;
            else
            {
                float xDist = mousePos.X - _transform.position.X;
                float yDist = mousePos.Y - _transform.position.Y;
                float ratio = Vector2.Distance(mousePos, _transform.position) / Range;
                _guideTransform.position = _transform.position + new Vector2(xDist / ratio, yDist / ratio);
            }
        }
        else
        {
            _guideRenderer.IsVisible = false;
        }


        if (InputManager.Mouse.WasButtonJustReleased(MouseButton.Left) && _canDash)
        {
            _transform.position = _guideTransform.position;
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
