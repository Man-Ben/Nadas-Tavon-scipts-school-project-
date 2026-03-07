using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{

    private float backGroundSpeed = 7;
    private PlayerController playerController;

    public bool isGameEnd = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if(playerController.isGameOver == false && !isGameEnd)
            transform.Translate(Vector3.right * Time.deltaTime * backGroundSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("End"))
            isGameEnd = true;
    }
}
