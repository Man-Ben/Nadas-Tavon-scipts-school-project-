using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitToMenuButton;
    [SerializeField] private Button resumeButton;

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private GameObject escapeMenu;
    [SerializeField] private GameObject gameOverMenu;

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if(playerController.isGameOver == true)
            gameOverMenu.gameObject.SetActive(true);

        AddListenerToButtons();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            escapeMenu.gameObject.SetActive(true);
    }

    void AddListenerToButtons()
    {
        restartButton.onClick.AddListener(RestartButton);
        exitToMenuButton.onClick.AddListener(ExitButton);
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
        escapeMenu.gameObject.SetActive(false);
    }
}
