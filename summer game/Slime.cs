using System;
using System.Collections.Generic;
using MyMonoGameLibrary.Scenes;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;

namespace summer_game;

public class Slime : BehaviorComponent
{
    private string _color;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private CircleCollider _collider;
    private int _collisions = 0;
    private bool _justPointed = true;

    public Slime(string color)
    {
        _color = color;
    }
    public override void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _collider = GetComponent<CircleCollider>();

        TextRenderer tr = Parent.GetChild(0).GetComponent<TextRenderer>();

        if (_color == "green")
            tr.Text = "green";
        if (_color == "blue")
            tr.Text = "blue";

        Transform transform = Parent.GetChild(0).Transform;

        transform.position = new Vector2(Transform.position.X, Transform.position.Y - 0.75f);

    }

    public override void Update(GameTime gameTime)
    {
        if (Collisions.MouseInCollider(_collider))
        {
            if (!_justPointed)
            {
                _justPointed = true;
                if (_color == "green")
                    _anim.Animation = Core.GlobalLibrary.GetAnimation("characters", "green_slime");
                if (_color == "blue")
                    _anim.Animation = Core.GlobalLibrary.GetAnimation("characters", "blue_slime");
            }
        }
        else
        {
            _anim.Animation = null;
            _justPointed = false;
        }
    }

    public override void OnCollisionEnter(ICollider other)
    {
        _spriteRenderer.Color = Color.Red;
        _collisions++;

        if (other.Layer == "spark")
        {
            SceneTools.Destroy(this.Parent);
        }
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
