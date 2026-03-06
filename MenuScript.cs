using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool isGameActive;

    public GameObject menuButtons;
    public GameObject difficultyButtons;



    void Start()
    {
        isGameActive = false;
    }

    public void PlayButton()
    {
    
        difficultyButtons.gameObject.SetActive(true);
        menuButtons.gameObject.SetActive(false);
    
        Debug.Log("Button was Clicked");

    }

    public void ExitButton()
    {
        Debug.Log("Button was Clicked");
    }


}
