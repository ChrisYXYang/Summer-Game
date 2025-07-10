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
            new PlayerShoot(25)
            ];

        return ("player", components);
    }

    // orange portal
    // orange projectile
    public static (string, Component[]) OrangePortal()
    {
        Component[] components =
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "orange portal")),
            new Portal(),
            ];

        return ("orange portal", components);
    }

    // orange projectile
    public static (string, Component[]) OrangeProjectile()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(4, "player projectile"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "orange")),
            new PlayerProjectile()
            ];

        return ("orange projectile", components);
    }

    // blue projectile
    public static (string, Component[]) BlueProjectile()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(4, "player projectile"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue")),
            new PlayerProjectile()
            ];

        return ("blue projectile", components);
    }
}
