using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private bool canUseStamina = true;
    private PlayerControls _playerControls;
    private Coroutine staminaCountdown;

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
                PlayerUseStamina(10.0f);
                _playerControls.PlayerState("sprint");

            } else if (Input.GetKey(KeyCode.LeftControl))
            {
                PlayerRegenStamina();
                _playerControls.PlayerState("crouch");
            } else if (Input.GetKey(KeyCode.E))
            {
                PlayerRegenStamina();
                _playerControls.PlayerState("knee");
            }
            else
            {
                PlayerRegenStamina();
                _playerControls.PlayerState("walk");
            }
        }
    }

    private void PlayerTakeDmg(int takenDmg)
    {
        GameManager.gameManager._playerHealth.DamageUnit(takenDmg);
    }

    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
    } 
    
    private void PlayerUseStamina(float staminaAmount)
    {
        if (GameManager.gameManager._playerStamina.Stamina > 0)
        {
            GameManager.gameManager._playerStamina.UseStamina(staminaAmount);
        } else if (GameManager.gameManager._playerStamina.Stamina < 0)
        {
            canUseStamina = false;
            StartCoroutine(StaminaCoutdown(3)); ;
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
    
}
