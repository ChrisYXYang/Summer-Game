using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class BuffItem : BehaviorComponent
{
    public Buffs Buff { get; private set; }
    public string Statement { get; private set; }
    public float Time { get; private set; }

    public BuffItem(Buffs buff, string statement, int time)
    {
        Buff = buff;
        Statement = statement;
        Time = time;
    }

    public override void OnCollisionEnter(ICollider other)
    {
        Use(other);

    }

    public override void OnCollisionStay(ICollider other)
    {
        Use(other);
    }

    private void Use(ICollider other)
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
