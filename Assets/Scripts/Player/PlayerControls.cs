using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Player phusics variables
    public Rigidbody playerRb;
    public float playerSpeed = 10.0f;
    public float playerRotationSpeed = 5.0f;
    public float playerSprintSpeed = 10.0f;
    public float playerJumpForce = 100.0f;
    public bool isOnGround;
    
    //player animation variables
    public Animator playerAnimator;
    
    

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerAnimator = gameObject.GetComponent<Animator>();
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
            playerRb.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), playerRotationSpeed * Time.deltaTime);
            playerRb.velocity = movement * playerSpeed;
            playerAnimator.SetFloat("speed", Vector3.ClampMagnitude(movement,1).magnitude);

            if (Input.GetAxis("Shift") > 0)
            {
                playerRb.velocity = movement * playerSprintSpeed;
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
