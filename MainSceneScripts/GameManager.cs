/*
This script spawns the obstacles at a given interval and position.
Stops spawning when the player dies, presses the Esc key or the game ends.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();

    private int index;
    public float difficulty;

    private PlayerController playerController;
    private BackGroundMoving backGroundMoving;
    private ManagerUI managerUI;

    void Start()
    {

        difficulty = GameData.difficulty;

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();
        managerUI = GameObject.Find("UIManager").GetComponent<ManagerUI>();

        if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false && managerUI.isGamePaused == false)
            StartCoroutine(SpawnerCountDown());
    }

    IEnumerator SpawnerCountDown()
    {

        while(playerController.isGameOver == false && backGroundMoving.isGameEnd == false && managerUI.isGamePaused == false)
        {
            Spawner();
            yield return new WaitForSeconds(difficulty);
        }

    }

    void Spawner()
    {
        index = Random.Range(0, obstacles.Count);

        float pozY = 1;

        if(obstacles[index].gameObject.CompareTag("Abyss"))
            pozY = -0.16f;
        if(obstacles[index].gameObject.CompareTag("Log"))
            pozY = 0.7f;
        if(obstacles[index].gameObject.CompareTag("Rock"))
            pozY = 0.42f;
        if(obstacles[index].gameObject.CompareTag("Reeds"))
            pozY = 0.8f;

        
            Vector2 spawnPoz = new Vector2(30, pozY);


        Instantiate(obstacles[index], spawnPoz, Quaternion.identity);

    }

}
