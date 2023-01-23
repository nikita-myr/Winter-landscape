using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Player physics variables
    private Transform cam;
    private Rigidbody playerRb;
    //private float playerRotationSpeed = 30.0f;
    private float playerSmoothRotationTime = 0.1f;
    private float playerSmoothTurnVelocity;
    private float playerWalkSpeed = 10.0f;
    private float playerSprintSpeed = 20.0f;
    private float playerCrouchSpeed = 7.0f;
    public bool isOnGround;
    
    //player animation variables
    private Animator playerAnimator;
    

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        cam = UnityEngine.Camera.main.transform;
        playerAnimator = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        //PlayerState();
    }
    
    public void PlayerState(string value)
    {
        if (value == "sprint")
        {
            PlayerSprint();
        } else if (value == "crouch")
        {
            PlayerCrouch();
        }else if (value == "knee")
        {
            PlayerKnee();
        } else if (value == "walk")
        {
            PlayerWalk();
        }
        

        playerAnimator.SetBool("isCrouch", value == "crouch");
        playerAnimator.SetBool("isKnee", value == "knee");
    }
    
    private Vector3 PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        
        float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, 
            ref playerSmoothTurnVelocity, playerSmoothRotationTime);
        
        
        if (movement != Vector3.zero)
        {
            Vector3 moveDir = Quaternion.Euler(.0f, targetAngle, .0f) * Vector3.forward;
            playerRb.rotation = Quaternion.Euler(.0f, angel, .0f);

            //playerRb.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),
            //  playerRotationSpeed * Time.deltaTime);
            return moveDir.normalized;
        }

        return Vector3.zero;
    }
    
    private void PlayerWalk()
    {
        var movement = PlayerMovement();
        playerRb.velocity = movement * playerWalkSpeed;

        playerAnimator.SetFloat("moveSpeed", Vector3.ClampMagnitude(movement,1).magnitude / 2);
    }

    private void PlayerSprint()
    {
        var movement = PlayerMovement();
        playerRb.velocity = movement * playerSprintSpeed;
        
        playerAnimator.SetFloat("moveSpeed", Vector3.ClampMagnitude(movement,1).magnitude);
    }
    
    private void PlayerCrouch()
    {
        
        var movement = PlayerMovement();

        playerRb.velocity = movement * playerCrouchSpeed;
        playerAnimator.SetBool("isCrouch", true);
        playerAnimator.SetFloat("crouchSpeed", Vector3.ClampMagnitude(movement,1).magnitude);
    }
    
    private void PlayerKnee()
    {
        playerAnimator.SetBool("isKnee", true);
    }

    private void PlayerCrafting(bool value)
    {
        playerAnimator.SetBool("isCraft", value);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }
    
}
