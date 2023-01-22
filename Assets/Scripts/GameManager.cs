using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set;}

    public HealthSystem _playerHealth = new HealthSystem(100, 100);
    public StaminaSystem _playerStamina = new StaminaSystem(100.0f, 100.0f, 5.0f, false);

    private void Awake()
    {
        // Duplicates gameManager check
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
}
