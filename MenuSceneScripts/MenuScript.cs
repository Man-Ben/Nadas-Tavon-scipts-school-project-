/*
This is the main manager script for the main menu.
It handles the UI, loads the main scene, and sets the game's difficulty 
according to the player's preference.
*/


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEditor;

public class MenuScript : MonoBehaviour
{


    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject difficultyButtons;
    
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button easyButton;
    [SerializeField] private Button mediumButton;
    [SerializeField] private Button hardButton;
    [SerializeField] private Button backButton;



    void Start()
    {

        AddListenerToButtons();

    }

    /*
    This method adds a listener to all attached buttons, so they respond to user clicks.
    */

    void AddListenerToButtons()
    {
        startButton.onClick.AddListener(PlayButton);
        backButton.onClick.AddListener(BackButton);
        exitButton.onClick.AddListener(ExitButton);
        easyButton.onClick.AddListener(() => DifficultyButtons(2.2f));
        mediumButton.onClick.AddListener(() => DifficultyButtons(1.5f));
        hardButton.onClick.AddListener(() => DifficultyButtons(1.27f));
    }
    
    /*
    When the player presses the PlayButton, the Play and Exit button disappears,
    and the Difficulty buttons along with the Back button appear.
    */
    
    void PlayButton()
    {

        difficultyButtons.gameObject.SetActive(true);
        menuButtons.gameObject.SetActive(false);

    }

    /*
    Quits the application when the button is pressed.
    */

    void ExitButton()
    {

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif

    }


    /*
    Performs the opposite action of the PlayButton() method.
    */

    void BackButton()
    {
        difficultyButtons.gameObject.SetActive(false);
        menuButtons.gameObject.SetActive(true);
    }

    /*
    Called when the player presses one of the Difficulty buttons.
    Assigns the difficulty variable in the GameData class, then loads the main scene.
    */

    void DifficultyButtons(float difficulty)
    {

        GameData.difficulty = difficulty;

        SceneManager.LoadScene("Main Scene");

    }

}
