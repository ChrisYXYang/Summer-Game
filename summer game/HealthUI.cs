using System;
using System.Collections.Generic;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class HealthUI : BehaviorComponent
{
    public static HealthUI Instance { get; private set; }

    private Func<PrefabInstance> _heart;
    private List<HeartIcon> _hearts = [];
    private int _currentHealth;
    private int _maxHealth;

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

    public void SetHealth(int health, int maxHealth)
    {
        _currentHealth = health;
        _maxHealth = maxHealth;
        
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

    public void AddHealth(int add, int maxHealth)
    {
        if (add < 0)
        {
            throw new Exception("need to add health");
        }
        
        _currentHealth += add;
        
        if (maxHealth != _maxHealth)
        {
            SetHealth(_currentHealth, maxHealth);
        }
    }

    public void RemoveHealth(int remove, int maxHealth)
    {
        if (remove > 0)
        {
            throw new Exception("neeed to remove health");
        }
        
        _currentHealth -= remove;
        
        if (maxHealth != _maxHealth)
        {
            SetHealth(_currentHealth, maxHealth);
        }
    }
}
