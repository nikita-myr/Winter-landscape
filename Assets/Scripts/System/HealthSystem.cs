public class HealthSystem
{
    // Fields
     int _currentHealth;
     int _currentMaxHealth;
     
     // Properties
     public int Health
     {
         get
         {
             return _currentHealth;
         }
         set
         {
             _currentHealth = value;
         }
     }

     public int MaxHealth
     {
         get
         {
             return _currentMaxHealth;
         }
         set
         {
            _currentMaxHealth = value;
         }
     }

    // Constructor
    public HealthSystem(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }
    
    // Methods
    public void DamageUnit(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }
    
    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
