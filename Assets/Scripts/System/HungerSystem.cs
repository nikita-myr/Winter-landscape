using UnityEngine;

public class HungerSystem
{
    // Fields
    // Hunger
    float _currentHunger;
    float _currentMaxHunger;
    bool _pauseHungerRegen;
    
    // Thirst
    float _currentThirst;
    float _currentMaxThirst;
    bool _pauseThirstRegen;

    public float Hunger
    {
        get
        {
            return _currentHunger;
        }
        set
        {
            _currentHunger = value;
        }
    }

    public float MaxHunger
    {
        get
        {
            return _currentMaxHunger;
        }
        set
        {
            _currentMaxHunger = value;
        }
    }
    
    public bool PauseRegenHunger
    {
        get
        {
            return _pauseHungerRegen;
        }
        set
        {
            _pauseHungerRegen = value;
        }
    }

    public float Thirst
    {
        get
        {
            return _currentThirst;
        }
        set
        {
            _currentThirst = value;
        }
    }

    public float MaxThirst
    {
        get
        {
            return _currentMaxThirst;
        }
        set
        {
            _currentMaxThirst = value;
        }
    }

    public bool PauseRegenThirst
    {
        get
        {
            return _pauseThirstRegen;
        }
        set
        {
            _pauseThirstRegen = value;
        }
    }
    
    
    // Constructor
    public HungerSystem(float hunger, float maxHunger, bool pauseHungerRegen,
                        float thirst, float maxThirst, bool pauseThirstRegen)
    {
        _currentHunger = hunger;
        _currentMaxHunger = maxHunger;
        _pauseHungerRegen = pauseHungerRegen;
        
        _currentThirst = thirst;
        _currentMaxThirst = maxThirst;
        _pauseThirstRegen = pauseThirstRegen;
    }

    public void UseHunger(float hungerAmount)
    {
        if (_currentHunger > 0)
        {
            _currentHunger -= hungerAmount * Time.deltaTime;
        }
    }

    public void RegenHunger(float amount)
    {
        if (_currentHunger < _currentMaxHunger && !_pauseHungerRegen)
        {
            _currentHunger += amount * Time.deltaTime;
        }
    }

    public void UseThirst(float thirstAmount)
    {
        if (_currentThirst > 0)
        {
            _currentThirst -= thirstAmount * Time.deltaTime;
        }
    }

    public void RegenThirst(float amount)
    {
        if (_currentThirst < _currentMaxThirst && !_pauseThirstRegen)
        {
            _currentHunger += amount * Time.deltaTime;
        }
    }
}
