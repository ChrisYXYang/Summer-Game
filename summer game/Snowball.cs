using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class Snowball : BehaviorComponent
{
    public int Damage { get; set; }
    private bool _used = false;
    
    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "enemy")
        {
            if (other.Layer == "enemy")
            {
                if (!_used)
                {
                    ((ColliderComponent)other).Parent.GetComponent<EnemyHealth>().TakeDamage(Damage);
                    _used = true;
                }
            }
            
            SceneTools.Destroy(this.Parent);
        }
    }
}
