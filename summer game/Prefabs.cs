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
    // player prefab
    public static (string, Component[]) Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(8, 8),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player_0")),
            new PlayerController(4, 10)
            ];

        return ("player", components);
    }
}
