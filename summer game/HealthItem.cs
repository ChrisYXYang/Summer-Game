using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class HealthItem : BehaviorComponent
{
    public int Amount { get; protected set; }

    public HealthItem(int amount)
    {
        Amount = amount;
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
            PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                if (!playerHealth.Full)
                {
                    playerHealth.Heal(Amount);
                    SceneTools.Destroy(Parent);
                    playerHealth.GetComponent<PlayerState>().QueueStatement("healed " + Amount);
                }
            }
        }
    }
}
