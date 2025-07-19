using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class Snowball : BehaviorComponent
{
    public int Damage { get; set; }
    public float Knockback { get; set; }
    private bool _used = false;

    public override void Update(GameTime gameTime)
    {
        Transform.Rotation = MathHelper.ToDegrees(MathF.Atan2(Parent.Rigidbody.YVelocity, Parent.Rigidbody.XVelocity));
    }

    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "enemy")
        {
            if (other.Layer == "enemy")
            {
                if (!_used)
                {
                    if (Parent.Rigidbody.XVelocity > 0)
                    {
                        ((ColliderComponent)other).Parent.GetComponent<EnemyHealth>().TakeDamage(Damage, Knockback, true);
                    }
                    else
                    {
                        ((ColliderComponent)other).Parent.GetComponent<EnemyHealth>().TakeDamage(Damage, Knockback, false);
                    }

                    _used = true;
                }
            }
            
            SceneTools.Destroy(this.Parent);
        }
    }
}
