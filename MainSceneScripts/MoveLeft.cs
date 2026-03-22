/*
This script defines the behaviour of the obstacles.
*/

using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed;

    private PlayerController playerController;
    private BackGroundMoving backGroundMoving;
    private ManagerUI managerUI;
    private Rigidbody2D obstacleRB;
    

    void Start()
    {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();
        managerUI = GameObject.Find("UIManager").GetComponent<ManagerUI>();

        obstacleRB = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false && managerUI.isGamePaused == false)
            MoveLeftMethod();
        else
        {
            obstacleRB.linearVelocity = Vector2.zero;
            obstacleRB.angularVelocity = 0f;
        }
    }

    void MoveLeftMethod()
    {

        speed = 0.07f;

    if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false && managerUI.isGamePaused == false)
        obstacleRB.AddForce(Vector2.left * speed, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bound"))
            Destroy(gameObject);
    }

}
