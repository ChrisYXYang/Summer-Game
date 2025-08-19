using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class EnemyProjectile : BehaviorComponent
{
    public int Damage { get; set; }
    private bool _destroyed = false;


    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "player")
        {
            if (other.Layer == "player")
            {
                PlayerHealth playerHealth = ((ColliderComponent)other).GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(Damage);
            }

            if (!_destroyed)
            {
                GetComponent<ParticleSystem>().Rotation = Transform.Rotation + 180f;
                GetComponent<ParticleSystem>().Play();
                SceneTools.Destroy(this.Parent);
                _destroyed = true;
            }
        }
    }
}
