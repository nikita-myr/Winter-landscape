using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Player phusics variables
    private Rigidbody playerRb;
    private float playerWalkSpeed = 10.0f;
    private float playerSprintSpeed = 20.0f;
    private float playerCrouchSpeed = 7.0f;
    private float playerRotationSpeed = 15.0f;
    private float playerJumpForce = 1.2f;
    private bool isOnGround;
    private string currentState;
    
    //player animation variables
    private Animator playerAnimator;
    
    

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        PlayerState();
    }

    private void PlayerState()
    {
        if (isOnGround && Input.GetKey(KeyCode.LeftControl))
        {
            PlayerCrouching();
            currentState = "crouching";
        } else if (isOnGround && Input.GetKey(KeyCode.E))
        {
            PlayerKnee();
            currentState = "knee";
            
        } else if (isOnGround && Input.GetAxis("Jump") > 0)
        {
            PlayerJump();
            currentState = "jump";
        }
        else if (isOnGround)
        {
            PlayerStand();
            currentState = "moving";
        }
        
        playerAnimator.SetBool("isCrouch", currentState == "crouching");
        playerAnimator.SetBool("isKnee", currentState == "knee");
    }
    
    private Vector3 PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        playerRb.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),
            playerRotationSpeed * Time.deltaTime);
        
        return movement;
    }

    private void PlayerStand()
    {
        var movement = PlayerMovement();
        playerRb.velocity = movement * playerWalkSpeed;

        playerAnimator.SetFloat("moveSpeed", Vector3.ClampMagnitude(movement,1).magnitude / 2);

        if (Input.GetAxis("Shift") > 0)
        {
            playerRb.velocity = movement * playerSprintSpeed;
            playerAnimator.SetFloat("moveSpeed", Vector3.ClampMagnitude(movement,1).magnitude);
        }
    }

    private void PlayerCrouching()
    {
        var movement = PlayerMovement();

        playerRb.velocity = movement * playerCrouchSpeed;
        playerAnimator.SetFloat("crouchSpeed", Vector3.ClampMagnitude(movement,1).magnitude);
    }

    private void PlayerKnee()
    {
    }

    private void PlayerJump()
    {
        var movement = PlayerMovement();
        playerRb.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
        playerAnimator.SetBool("isJump", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        UpdateIsOnGroud(collision, true);
        playerAnimator.SetBool("isJump", false);
    }

    private void OnCollisionExit(Collision collision)
    {
        UpdateIsOnGroud(collision, false);
    }

    private void UpdateIsOnGroud(Collision collision, bool value)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = value;
        }
    }
    
}
