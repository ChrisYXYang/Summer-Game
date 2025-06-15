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
    // range of teleport
    public float Range { get; set; }

    // player components
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    private CircleCollider _collider;

    // guide components
    private Transform _guideTransform;
    private SpriteRenderer _guideRenderer;

    // can move or no
    private bool _canMove = false;


    // constructor
    //
    // param: range - teleport range
    public PlayerController(float range)
    {
        Range = range;
    }

    public override void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider>();

        GameObject guide = SceneTools.GetGameObject("guide");
        _guideTransform = guide.GetComponent<Transform>();
        _guideRenderer = guide.GetComponent<SpriteRenderer>();
    }

    public override void Update(GameTime gameTime)
    {
        // get mouse position in game units
        Vector2 mousePos = Camera.PixelToUnit(InputManager.Mouse.Position);

        // indicate if mouse is over player
        if (Collisions.PointInCollider(_collider, mousePos))
        {
            _spriteRenderer.Color = Color.Blue;
        }
        else
        {
            _spriteRenderer.Color = Color.White;
        }

        // move the player
        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left)
            && Collisions.PointInCollider(_collider, mousePos))
        {
            _canMove = true;
        }

        if (_canMove)
        {
            // move the guide
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


        if (InputManager.Mouse.WasButtonJustReleased(MouseButton.Left) && _canMove)
        {
            _transform.position = _guideTransform.position;
            _canMove = false;
        }


    }
}
