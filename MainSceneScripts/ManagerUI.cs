using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitToMenuButton;
    [SerializeField] private Button exitToMenuButtonResume;
    [SerializeField] private Button resumeButton;

    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private GameObject gameOverMenu;


    public bool isGamePaused = false;

    private PlayerController playerController;
    private BackGroundMoving backGroundMoving;

    void Start()
    {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        backGroundMoving = GameObject.Find("BackGround").GetComponent<BackGroundMoving>();

        AddListenerToButtons();
        
    }

    void Update()
    {
        if(!isGamePaused && backGroundMoving.isGameEnd == false && Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.gameObject.SetActive(true);
            isGamePaused = true;
        }
            
        
        if(playerController.isGameOver == true && !isGamePaused && backGroundMoving.isGameEnd == false)
            gameOverMenu.gameObject.SetActive(true);

    }

    void AddListenerToButtons()
    {
        restartButton.onClick.AddListener(RestartButton);
        exitToMenuButton.onClick.AddListener(ExitButton);
        exitToMenuButtonResume.onClick.AddListener(ExitButton);
        resumeButton.onClick.AddListener(ResumeButton);
    }



    void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    void ResumeButton()
    {
        if(playerController.isGameOver == false && backGroundMoving.isGameEnd == false)
        {
        escapeMenu.gameObject.SetActive(false);
        isGamePaused = false;
        }
    }
}
