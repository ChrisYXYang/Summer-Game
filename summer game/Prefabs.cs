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
    public static PrefabInstance Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(8), "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player"), 0.6f),
            new Animator(),
            new PlayerMovement(5, 13),
            new PlayerShoot(10, 4, 4, 0.5f, 0.5f)
            ];

        return new PrefabInstance("player", components, [SnowballIndicator()]);
    }

    public static PrefabInstance Snowball()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "attack"),
            new Rigidbody(true, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.7f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "snowball")),
            new Snowball(),
            ];

        return new PrefabInstance("snowball", components);
    }

    public static PrefabInstance SnowballIndicator()
    {
        Component[] components =
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.7f)
            ];

        return new PrefabInstance("snowball indicator", components);
    }

    public static PrefabInstance Snowman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(9), Converter.PixelToUnit(0), Converter.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman"), 0.4f),
            new Animator(),
            new EnemyBehavior(7.5f, false, 1, 0.5f, 3, 3, Prefabs.Carrot, Core.GlobalLibrary.GetAnimation("characters", "snowman_run")),
            new EnemyHealth(10)
            ];

        return new PrefabInstance("snowman", components);
    }

    public static PrefabInstance TestDummy()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(9), Converter.PixelToUnit(0), Converter.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman")),
            new Animator(),
            new EnemyBehavior(7.5f, false, 1, 0.5f, 3, 3, Prefabs.Carrot, Core.GlobalLibrary.GetAnimation("characters", "snowman_run")),
            new EnemyHealth(1000)
            ];

        return new PrefabInstance("test dummy", components, [SnowballIndicator()]);
    }

    public static PrefabInstance Carrot()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "hurt"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "carrot"), 0.8f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "carrot")),
            new EnemyProjectile(),
            ];

        return new PrefabInstance("carrot", components);
    }
}
