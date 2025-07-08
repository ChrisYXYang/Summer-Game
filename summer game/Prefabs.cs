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
            new PlayerShoot(15)
            ];

        return ("player", components);
    }

    // orange
    public static (string, Component[]) Orange()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(4, "player proj"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "orange")),
            new PortalProj()
            ];

        return ("orange", components);
    }

    // blue
    public static (string, Component[]) Blue()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(4, "player proj"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "blue")),
            new PortalProj()
            ];

        return ("blue", components);
    }
}
