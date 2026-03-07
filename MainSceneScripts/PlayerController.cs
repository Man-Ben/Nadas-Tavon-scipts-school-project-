using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float gravityModifier = 1;

    [SerializeField] private bool onGround = true;

    [SerializeField] private GameObject ground;

    private Rigidbody2D playersRB;

    private BackGroundMoving backGroundMoving;

    public bool isGameOver;

    void Start()
    {

        playersRB = GetComponent<Rigidbody2D>();
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();

        Physics.gravity *= gravityModifier;

        onGround = true;
        isGameOver = false;
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {   

        if(Input.GetKeyDown(KeyCode.Space) && onGround && !isGameOver && backGroundMoving.isGameEnd == false)
        {

            playersRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;

        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Abyss"))
        {
            isGameOver = true;
            ground.gameObject.SetActive(false);
        }
        else
            isGameOver = true;
    }
}
