using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;


namespace summer_game;

public class Snowball : BehaviorComponent
{
    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "enemy")
        {
            SceneTools.Destroy(this.Parent);
        }
    }
}
