using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float gravityModifier = 1;

    [SerializeField] private bool onGround;

    private Rigidbody2D playersRB;

    void Start()
    {

        playersRB = GetComponent<Rigidbody2D>();

        Physics.gravity *= gravityModifier;

        onGround = true;
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {   

        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {

            playersRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;

        }
        
    }

    void OnCollisonEnter2D(Collider2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
