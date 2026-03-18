/*
This script manages the background's movement.
Stops when the player dies, presses the Esc key or the game ends.
*/

using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{

    private float backGroundSpeed = 7;
    private PlayerController playerController;
    private ManagerUI managerUI;

    public bool isGameEnd = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        managerUI = GameObject.Find("UIManager").GetComponent<ManagerUI>();
    }

    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if(playerController.isGameOver == false && !isGameEnd && managerUI.isGamePaused == false)
            transform.Translate(Vector3.right * Time.deltaTime * backGroundSpeed);
    }

    /*
    Checks if the moving background collides with the "End" point.
    If so, the game ends.
    */

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("End"))
            isGameEnd = true;
    }
}
