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
