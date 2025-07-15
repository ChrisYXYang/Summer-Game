using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

// behavior for shooting projectile
public class PlayerShoot : BehaviorComponent
{
    public float ProjectileSpeed { get; set; }

    public PlayerShoot(float speed)
    {
        ProjectileSpeed = speed;
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left))
        {
            Vector2 mouseDist = Vector2.Normalize(Camera.PixelToUnit(InputManager.Mouse.Position) - Transform.position);
            GameObject projectile = SceneTools.Instantiate(Prefabs.Snowball(), Transform.position, 0f);
            projectile.Rigidbody.XVelocity = mouseDist.X * ProjectileSpeed;
            projectile.Rigidbody.YVelocity = mouseDist.Y * ProjectileSpeed;
            Core.Audio.PlaySoundEffect(Core.GlobalLibrary.GetSoundEffect("bounce"));
        }
    }
}
