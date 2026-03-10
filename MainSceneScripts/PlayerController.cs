using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce = 12;
    [SerializeField] private float gravityModifier = 1f;

    [SerializeField] private bool onGround = true;

    [SerializeField] private GameObject ground;
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D playersRB;
    private Animator animator;

    private BackGroundMoving backGroundMoving;
    private ManagerUI managerUI;
    private AudioSource audioClip;

    public bool isGameOver;

    void Start()
    {

        playersRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioClip = GetComponent<AudioSource>();

        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();
        managerUI = GameObject.Find("UIManager").GetComponent<ManagerUI>();

        Physics.gravity *= gravityModifier;

        onGround = true;
        isGameOver = false;
    }

    void Update()
    {

        AnimationPlayer();
        Jump();
        
    }

    void Jump()
    {   

        if(Input.GetKeyDown(KeyCode.Space) && managerUI.isGamePaused == false && onGround && !isGameOver && backGroundMoving.isGameEnd == false)
        {

            playersRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioClip.PlayOneShot(jumpSound, 0.5f);
            onGround = false;
            animator.SetBool("isRunning", false);
        }
        
    }

    void AnimationPlayer()
    {

        if(managerUI.isGamePaused == false && !isGameOver && backGroundMoving.isGameEnd == false)
            animator.SetBool("isRunning", true);

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
        if(isGameOver == false && backGroundMoving.isGameEnd == false && managerUI.isGamePaused == false)
            if(other.gameObject.CompareTag("Abyss"))
            {
                isGameOver = true;
                ground.gameObject.SetActive(false);
                animator.SetBool("isRunning", false);
            }
            else
                isGameOver = true;
    }
}
