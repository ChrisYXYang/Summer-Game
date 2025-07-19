using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary;
using MyMonoGameLibrary.UI;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Tools;

namespace summer_game;

// this class contains static methods corresponding to prefabs to use in scenes.
public static class Prefabs
{
    public static Prefab Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(8), "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player")),
            new PlayerMovement(5, 13),
            new PlayerShoot(10, 4, 4, 0.5f, 0.5f)
            ];

        return new Prefab("player", components, [SnowballIndicator()]);
    }

    public static Prefab Snowball()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "snowball"),
            new Rigidbody(true, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball")),
            new Snowball()
            ];

        return new Prefab("snowball", components, []);
    }

    public static Prefab Snowman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(9), Converter.PixelToUnit(0), Converter.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman")),
            new EnemyBehavior("snowman", 3, 3),
            new EnemyHealth(10)
            ];

        return new Prefab("snowman", components, []);
    }

    public static Prefab SnowballIndicator()
    {
        Component[] components =
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball icon"), 0.6f)
            ];

        return new Prefab("snowball indicator", components, []);
    }
}
