using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class Spark : BehaviorComponent
{
    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "slime")
        {
            if (other.Layer == "slime")
            {
                GameManager.Instance.SlimesCollected += 1;
            }
            
            SceneTools.Destroy(this.Parent);
        }
    }
}
