using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public abstract class Pickup : BehaviorComponent
{
    public string Statement { get; protected set; }

    private float _timer = 0;
    private float _originalY;

    public Pickup(string statement)
    {
        Statement = statement;
    }

    public override void Start()
    {
        _originalY = Transform.position.Y;
    }

    public override void Update(GameTime gameTime)
    {
        _timer += SceneTools.DeltaTime * 5;

        Transform.position.Y = _originalY + (MathF.Sin(_timer) * 0.25f);
    }

    public override void OnCollisionEnter(ICollider other)
    {
        Use(other);
    }

    public override void OnCollisionStay(ICollider other)
    {
        Use(other);
    }

    protected abstract void Use(ICollider other);
}
