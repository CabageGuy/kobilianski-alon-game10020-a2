using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement settings
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public GameManager gm;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;

        // Keep player grounded
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            gm.CollectCoin();
            Destroy(other.gameObject);
        }
    }
 
}