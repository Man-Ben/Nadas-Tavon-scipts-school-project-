using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed;

    private PlayerController playerController;
    private BackGroundMoving backGroundMoving;

    private Rigidbody2D obstacleRB;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();

        obstacleRB = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false)
            MoveLeftMethod();
    }

    void MoveLeftMethod()
    {

        speed = 0.07f;

    if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false)
        obstacleRB.AddForce(Vector2.left * speed, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bound"))
            Destroy(gameObject);
    }

}
