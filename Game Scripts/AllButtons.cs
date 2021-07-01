using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button _buttonStartGame, _buttonHelpGame, _buttonExitGame;//Menu
    private Button __buttonYes, _buttonNo;//Exit
    private Button _buttonBack;//Help
    //private Button _buttonleft,_buttonRight,_buttonUp,_buttonDown;//Game
    void Start()
    {
        //menu
        if(SceneManager.GetActiveScene().name=="Menu")
        {
            _buttonStartGame = GameObject.Find("ButtonStartGame").GetComponent<Button>();
            _buttonHelpGame = GameObject.Find("ButtonHelpGame").GetComponent<Button>();
            _buttonExitGame = GameObject.Find("ButtonExitGame").GetComponent<Button>();

            _buttonStartGame.onClick.AddListener(() => WindowGame());
            _buttonHelpGame.onClick.AddListener(() => WindowHelp());
            _buttonExitGame.onClick.AddListener(() => WindowExit());
        }
        //Exit
        if (SceneManager.GetActiveScene().name == "Exit")
        {
            __buttonYes = GameObject.Find("ButtonYes").GetComponent<Button>();
            _buttonNo = GameObject.Find("ButtonNo").GetComponent<Button>();

            __buttonYes.onClick.AddListener(() => Quit());
            _buttonNo.onClick.AddListener(() => WindowMenu());
        }
        //help
        if (SceneManager.GetActiveScene().name == "Help")
        {
            _buttonBack = GameObject.Find("ButtonBack").GetComponent<Button>();
            _buttonBack.onClick.AddListener(() => WindowMenu());
        }
        //Game/////////////////////////////////////////////////////////////////////////////////////////////
        if(SceneManager.GetActiveScene().name == "Game")
        {
            _buttonBack = GameObject.Find("ButtonBack").GetComponent<Button>();
            _buttonBack.onClick.AddListener(() => WindowMenu());


            //_buttonleft = GameObject.Find("ButtonLeft").GetComponent<Button>();
            //_buttonRight = GameObject.Find("ButtonRight").GetComponent<Button>();
            //_buttonUp = GameObject.Find("ButtonUp").GetComponent<Button>();
            //_buttonDown = GameObject.Find("ButtonDown").GetComponent<Button>();

            //_buttonleft.onClick.AddListener(() => Left());
            //_buttonRight.onClick.AddListener(() => Right());
            //_buttonUp.onClick.AddListener(() => Up());
            //_buttonDown.onClick.AddListener(() => Down());
        }
    }
    void RemoveListener()
    {
        //menu
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            _buttonStartGame.onClick.RemoveListener(() => WindowGame());
            _buttonHelpGame.onClick.RemoveListener(() => WindowHelp());
            _buttonExitGame.onClick.RemoveListener(() => WindowExit());
        }
        //Exit
        if (SceneManager.GetActiveScene().name == "Exit")
        {
            __buttonYes.onClick.RemoveListener(() => Quit());
            _buttonNo.onClick.RemoveListener(() => WindowMenu());
        }
        //help
        if (SceneManager.GetActiveScene().name == "Help")
        {
            _buttonBack.onClick.RemoveListener(() => WindowMenu());
        }
        //Game////////////////////////////////////////////////////////////////////////////////////////
        if (SceneManager.GetActiveScene().name == "Game")
        {
            _buttonBack.onClick.RemoveListener(() => WindowMenu());
        }
    }
    private void WindowMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void WindowExit()
    {
        SceneManager.LoadScene(1);
    }
    private void WindowHelp()
    {
        SceneManager.LoadScene(2);
    }
    private void WindowGame()
    {
        SceneManager.LoadScene(3);
    }
    private void Quit()
    {
        if (Input.GetKeyDown(KeyCode.End) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Application.Quit();
        }
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WindowMenu();
        }
    }
}
