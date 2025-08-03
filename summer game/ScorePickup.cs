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

    private GameManager _gameManager;

    public ScorePickup(int amount) : base("+" + amount)
    {
        Amount = amount;
    }

    public override void Start()
    {
        _gameManager = SceneTools.GetGameObject("game manager").GetComponent<GameManager>();
    }

    protected override void Use(ICollider other)
    {
        if (other.Layer == "player")
        {
            _gameManager.Score++;
            SceneTools.Destroy(Parent);
        }
    }
}
