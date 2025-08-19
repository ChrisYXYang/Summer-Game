using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class ScorePickup : Pickup
{
    public int Amount { get; private set; }

    public ScorePickup(int amount) : base("+" + amount)
    {
        Amount = amount;
    }

    protected override void Use(ICollider other)
    {
        GameManager.Instance.Score++;
        GameManager.Instance.NewFish(Level);
        SceneTools.Destroy(Parent);
    }
}
