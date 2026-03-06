using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{

    private float backGroundSpeed = 10;


    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * backGroundSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.CompareTag("End"))
            backGroundSpeed = 0;
    }
}
