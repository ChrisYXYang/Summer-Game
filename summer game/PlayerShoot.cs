using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public bool DoubleDamage { get; set; }
    public bool TripleShot { get; set; }
    public float Knockback { get; set; }
    public float ThrowRate { get; set; }
    public float HandRange { get; set; }

    private PlayerMovement _movement;
    private SpriteRenderer _sr;
    private GameObject _indicator;
    private float _throwTimer = 0;

    public PlayerShoot(float speed, bool doubleDmg, bool tripleShot, float knockback, float throwRate, float handRange)
    {
        ProjectileSpeed = speed;
        DoubleDamage = doubleDmg;
        TripleShot = tripleShot;
        Knockback = knockback;
        ThrowRate = throwRate;
        HandRange = handRange;
    }

    public override void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _sr = GetComponent<SpriteRenderer>();
        _indicator = Parent.GetChild(0);
    }

    public override void Update(GameTime gameTime)
    {
        // get current game time
        _throwTimer -= SceneTools.DeltaTime;

        // get unit vector from player to mouse
        Vector2 mouseDist = Vector2.Normalize(Camera.PixelToUnit(InputManager.Mouse.Position) - Transform.position);

        // update snowball indicator
        _indicator.Transform.position = mouseDist * HandRange;
        float readyScale = float.Clamp(-((_throwTimer - ThrowRate) / ThrowRate), 0f , 1f);
        _indicator.Transform.Scale = new Vector2(readyScale, readyScale);

        // throw snowball
        if (InputManager.Mouse.IsButtonDown(MouseButton.Left) && _throwTimer <= 0)
        {
            Shoot(mouseDist, 0);

            if (TripleShot)
            {
                Shoot(mouseDist, -30);
                Shoot(mouseDist, 30);
            }

            _throwTimer = ThrowRate;

            // play sound
            int sound = Core.Random.Next(1, 4);

            if (sound == 1)
            {
                Core.Audio.PlaySoundEffect(SceneTools.SceneLibrary.GetSoundEffect("crystal0"));
            }

            if (sound == 2)
            {
                Core.Audio.PlaySoundEffect(SceneTools.SceneLibrary.GetSoundEffect("crystal1"));
            }

            if (sound == 3)
            {
                Core.Audio.PlaySoundEffect(SceneTools.SceneLibrary.GetSoundEffect("crystal2"));
            }
        }

        if (!_movement.Dashing)
        {
            // make player face mouse
            if (Camera.PixelToUnit(InputManager.Mouse.Position).X > Transform.position.X)
            {
                _sr.FlipX = false;
            }
            else
            {
                _sr.FlipX = true;
            }
        }
    }

    private void Shoot(Vector2 mouseDist, float skew)
    {
        float rotation = MathF.Atan2(mouseDist.Y, mouseDist.X) + MathHelper.ToRadians(skew);
        GameObject projectile = SceneTools.Instantiate(Prefabs.Snowball(), Transform.position + (mouseDist * HandRange), 0f);
        projectile.GetComponent<Snowball>().Damage = DoubleDamage ? 2 : 1;
        projectile.GetComponent<Snowball>().Knockback = Knockback;
        Vector2 direction = new((float)MathF.Cos(rotation), (float)MathF.Sin(rotation));
        projectile.Rigidbody.XVelocity = direction.X * ProjectileSpeed;
        projectile.Rigidbody.YVelocity = direction.Y * ProjectileSpeed;
        projectile.Transform.Rotation = MathHelper.ToDegrees(rotation);
    }

    public void ModifySpeed(bool add, bool sum, float amount)
    {
        if (add)
        {
            if (sum)
                ProjectileSpeed += amount;
            else
                ProjectileSpeed *= amount;
        }
        else
        {
            if (sum)
                ProjectileSpeed -= amount;
            else
                ProjectileSpeed /= amount;
        }
    }

    public void ModifyRate(bool add, bool sum, float amount)
    {
        if (add)
        {
            if (sum)
                ThrowRate += amount;
            else
                ThrowRate *= amount;
        }
        else
        {
            if (sum)
                ThrowRate -= amount;
            else
                ThrowRate /= amount;
        }
    }

    public void ModifyKnockback(bool add, bool sum, float amount)
    {
        if (add)
        {
            if (sum)
                Knockback += amount;
            else
                Knockback *= amount;
        }
        else
        {
            if (sum)
                Knockback -= amount;
            else
                Knockback /= amount;
        }
    }
}
