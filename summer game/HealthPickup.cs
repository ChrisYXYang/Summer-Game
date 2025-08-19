using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class HealthPickup : Pickup
{
    public int Amount { get; private set; }

    public HealthPickup(int amount) : base("healed " + amount)
    {
        Amount = amount;
    }

    protected override void Use(ICollider other)
    {
        PlayerHealth playerHealth = ((ColliderComponent)other).GetComponent<PlayerHealth>();

        if (!playerHealth.Full)
        {
            playerHealth.Heal(Amount);
            GameManager.Instance.MinusItem(Level);
            SceneTools.Destroy(Parent);
            playerHealth.GetComponent<PlayerState>().QueueStatement(Statement);
        }
    }
}
