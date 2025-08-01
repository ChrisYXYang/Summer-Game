﻿using System;
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

    public override void OnCollisionEnter(ICollider other)
    {
        if (other.Layer == "wall" || other.Layer == "player")
        {
            if (other.Layer == "player")
            {
            }

            SceneTools.Destroy(this.Parent);
        }
    }
}
