using System;
using System.Collections.Generic;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class HealthUI : BehaviorComponent
{
    public static HealthUI Instance { get; private set; }

    private Func<PrefabInstance> _heart;
    private List<HeartIcon> _hearts = [];
    private int _maxHealth;
    private int _currentHealth;

    public HealthUI(Func<PrefabInstance> heart)
    {
        _heart = heart;
    }

    public override void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            SceneTools.Destroy(this.Parent);
        }
    }

    public void Setup(int health, int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = health;
        
        int hearts = (int)MathF.Max(0, (health + 1) / 2);
        int maxHearts = (int)MathF.Max(0, maxHealth / 2);

        for (int i = 0; i < MathF.Max(hearts, maxHearts); i++)
        {
            if (_hearts.Count <= i)
            {
                _hearts.Add(SceneTools.Instantiate(_heart.Invoke()).GetComponent<HeartIcon>());
            }
            else
            {

            }
        }
    }

    public void SetHealth(int health)
    {
        int diff = health - _currentHealth;

        if (diff > 0)
        {
            AddHealth(diff);
        }
        else if (diff < 0)
        {
            RemoveHealth(diff);
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        int diff = maxHealth - _maxHealth;

        if (diff > 0)
        {
            AddMaxHealth(diff);
        }
        else if (diff < 0)
        {
            RemoveMaxHealth(diff);
        }
    }

    public void AddMaxHealth(int add)
    {
        if (add < 0)
        {
            throw new Exception("need to add max health");
        }

        _maxHealth += add;
    }

    public void RemoveMaxHealth(int remove)
    {
        if (remove > 0)
        {
            throw new Exception("neeed to remove max health");
        }

        _maxHealth -= remove;
    }


    public void AddHealth(int add)
    {
        if (add < 0)
        {
            throw new Exception("need to add health");
        }

        _currentHealth += add;
    }

    public void RemoveHealth(int remove)
    {
        if (remove > 0)
        {
            throw new Exception("neeed to remove health");
        }

        _currentHealth -= remove;
    }
}
