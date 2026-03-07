using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEditor;

public class UIManager : MonoBehaviour
{


    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject difficultyButtons;
    
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private Button backButton;

    public int difficultyLevel;


    void Start()
    {

        AddListenerToButtons();

    }

    void AddListenerToButtons()
    {
        startButton.onClick.AddListener(PlayButton);
        backButton.onClick.AddListener(BackButton);
        exitButton.onClick.AddListener(ExitButton);
        easyButton.onClick.AddListener(() => DifficultyButtons(3));
        mediumButton.onClick.AddListener(() => DifficultyButtons(2));
        hardButton.onClick.AddListener(() => DifficultyButtons(1));
    }


    void PlayButton()
    {

        difficultyButtons.gameObject.SetActive(true);
        menuButtons.gameObject.SetActive(false);

    }

    void ExitButton()
    {

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

    }

    void BackButton()
    {
        difficultyButtons.gameObject.SetActive(false);
        menuButtons.gameObject.SetActive(true);
    }

    void DifficultyButtons(int difficulty)
    {

        difficultyLevel = difficulty;

        SceneManager.LoadScene("Main Scene");

    }

}
