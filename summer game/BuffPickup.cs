using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class BuffPickup : Pickup
{
    public Buffs Buff { get; private set; }
    public float Time { get; private set; }

    public BuffPickup(Buffs buff, string statement, int time) : base(statement)
    {
        Buff = buff;
        Time = time;
    }

    protected override void Use(ICollider other)
    {
        if (other is ColliderComponent col)
        {
            PlayerState playerState = col.GetComponent<PlayerState>();
            if (playerState != null)
            {
                playerState.AddBuff(Buff, Statement, Time);
                SceneTools.Destroy(Parent);
            }
        }
    }
}
