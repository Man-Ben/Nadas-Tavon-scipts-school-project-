/*
This script manages the audio of our game.
Stops the music when the player dies or the game ends.
*/


using UnityEngine;

public class AudioController : MonoBehaviour
{

    private BackGroundMoving backGroundMoving;
    public AudioSource audioSource;

    void Start()
    {
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();
        audioSource = GetComponent<AudioSource>();
    } 

    void Update()
    {
        if(backGroundMoving.isGameEnd == true && audioSource.isPlaying)
            audioSource.Stop();
    }

}
