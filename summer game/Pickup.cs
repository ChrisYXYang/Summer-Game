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
    public int Level { get; set; }

    private float _timer = 0;

    public Pickup(string statement)
    {
        Statement = statement;
    }


    public override void Update(GameTime gameTime)
    {
        _timer += SceneTools.DeltaTime * 5;

        Transform.position.Y += MathF.Sin(_timer) * 0.02f;
    }

    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "player")
            Use(other);
    }

    public override void OnCollisionStay(ICollider other)
    {
        if (other.Layer == "player")
            Use(other);
    }

    protected abstract void Use(ICollider other);
}
