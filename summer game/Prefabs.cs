using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary;

namespace summer_game;

// this class contains static methods corresponding to prefabs to use in scenes.
public static class Prefabs
{
    // player
    public static (string, Component[]) Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(8, 8, "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player_0")),
            new PlayerMovement(4, 10),
            new PlayerShoot(10)
            ];

        return ("player", components);
    }

    // spark
    public static (string, Component[]) Spark()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(4, "spark"),
            new Rigidbody(true, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "spark")),
            new Spark()
            ];

        return ("spark", components);
    }
}
