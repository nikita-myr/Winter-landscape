using System.Collections;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool canUseStamina = true;
    private PlayerControls _playerControls;
    private PlayerControls.State _currentState;
    public GameObject inventoryCanvas;

    void Start()
    {
        _playerControls = GameObject.FindWithTag("Player").GetComponent<PlayerControls>();
    }
    void Update()
    {
        PlayerController();
        Debug.Log(GameManager.gameManager._playerStamina.Stamina);
    }

    private void PlayerController()
    {
        if (_playerControls.isOnGround)
        {
            if (Input.GetKey(KeyCode.LeftShift) && canUseStamina)
            {
                _currentState = PlayerControls.State.Sprint;
                _playerControls.PlayerState(_currentState);
                PlayerUseStamina(10.0f);
            } else if (Input.GetKey(KeyCode.LeftControl))
            {
                _currentState = PlayerControls.State.Crouch;
                _playerControls.PlayerState(_currentState);
                PlayerRegenStamina();
            } else if (Input.GetKey(KeyCode.E))
            {
                _currentState = PlayerControls.State.Knee;
                _playerControls.PlayerState(_currentState);
                inventoryCanvas.SetActive(_currentState == PlayerControls.State.Knee);
                PlayerRegenStamina();
            } 
            else
            {
                _currentState = PlayerControls.State.Walk;
                _playerControls.PlayerState(_currentState);
                PlayerRegenStamina();
            }
        }
    }

    // Health system
    private void PlayerTakeDmg(int takenDmg)
    {
        GameManager.gameManager._playerHealth.DamageUnit(takenDmg);
    }

    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
    } 
    
    // Stamina system
    private void PlayerUseStamina(float staminaAmount)
    {
        if (GameManager.gameManager._playerStamina.Stamina > 0)
        {
            GameManager.gameManager._playerStamina.UseStamina(staminaAmount);
        } else if (GameManager.gameManager._playerStamina.Stamina < 0)
        {
            canUseStamina = false;
            StartCoroutine(StaminaCoutdown(3));
        }
    }

    private void PlayerRegenStamina()
    {
        GameManager.gameManager._playerStamina.RegenStamina();
    }

    private IEnumerator StaminaCoutdown(int value)
    {
        yield return new WaitForSeconds(value);
        canUseStamina = true;
    }
    
    // Hunger system
    private void PlayerHunger(float hunger, float thirst)
    {
        GameManager.gameManager._playerHunger.UseHunger(hunger);
        GameManager.gameManager._playerHunger.UseThirst(thirst);
    }

    private void PlayerRegenHunger(float amount)
    {
        GameManager.gameManager._playerHunger.RegenHunger(amount);
    }

    private void PlayerRegenThirst(float amount)
    {
        GameManager.gameManager._playerHunger.RegenThirst(amount);
    }
    
}
