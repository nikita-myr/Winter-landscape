using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody playerRb;
    private float playerSpeed = 5.0f;
    private float playerSprintSpeed = 10.0f;
    private float playerJumpForce = 100.0f;
    private bool isOnGround;
    
    

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        
    }


    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (isOnGround)
        {
            playerRb.AddForce(movement * playerSpeed);

            if (Input.GetAxis("Shift") > 0)
            {
                playerRb.AddForce(movement * playerSprintSpeed);
            }
        }
        
    }

    private void PlayerJump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * playerJumpForce);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        UpdateIsOnGroud(collision, true);
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
