/*
At the end, this script will launch a short video.
*/


using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{

    private BackGroundMoving backGroundMoving;
    public VideoPlayer videoPlayer;

    void Start()
    {

        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();
    
        videoPlayer.loopPointReached += EndReached;

    }

    void Update()
    {
        if(backGroundMoving.isGameEnd)
            PlayVideo();

    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
