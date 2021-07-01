using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEndGameScene : MonoBehaviour
{
    public Text TextBasicSpeed;
    public Text TextBasicControl;
    public Text TextMaxSpeed;
    public Text TextTimeFinish;
    private GameObject playerTarget;


    //[SerializeField]
    public Button _buttonExitGame;
    //[SerializeField]
    public Button _buttonRestart;
    //[SerializeField]
    public Button _buttonTop;
    //[SerializeField]
    public Button _buttonBackMainMenu;

    void Start()
    {
        playerTarget = GameObject.Find("PlayerCar");
        playerTarget.transform.position = Vector3.zero;
        playerTarget.transform.position = new Vector3(0f, 1.5f, 2.5f);//Spawn

        TextBasicSpeed.text = $"Speed: {ButtonCarsScenes.SaveBasicSpeed:0.00}";
        TextBasicControl.text = $"Control: {ButtonCarsScenes.SaveBasicControl:0.00}";
        TextMaxSpeed.text = $"Max Speed: {MoveCar.SaveFinalSpeed:0.00}";
        TextTimeFinish.text = $"Time Finish: {WindowGameScene.SaveFinalTime:0.000}";

        _buttonExitGame.onClick.AddListener(() => ExitGame());
        _buttonRestart.onClick.AddListener(() => Restart());
        _buttonTop.onClick.AddListener(() => TOPPlayer());
        _buttonBackMainMenu.onClick.AddListener(() => ReturnTomainMenu());
    }
    private void RemoveListener()
    {
        _buttonExitGame.onClick.RemoveListener(() => ExitGame());
        _buttonRestart.onClick.RemoveListener(() => Restart());
        _buttonTop.onClick.RemoveListener(() => TOPPlayer());
        _buttonBackMainMenu.onClick.RemoveListener(() => ReturnTomainMenu());
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void ReturnTomainMenu()
    {
        ButtonCarsScenes.SaveBasicSpeed = 0f;
        ButtonCarsScenes.SaveBasicControl = 0f;
        WindowGameScene.SaveFinalTime = 0f;
        HealthPlayerGameScene.Health = 100f;
        MoveCar.SaveFinalSpeed = 0f;
        Destroy(playerTarget);
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        WindowGameScene.SaveFinalTime = 0f;
        MoveCar.SaveFinalSpeed = 0f;
        MoveCar._Speed = 0f;//Anyway
        TriggersGameScene.namber = 0;
        ButtonCarsScenes.SaveBasicControl /= 25f;//фікс початкового контролю
        ButtonCarsScenes.SaveBasicSpeed /= 25f;//фікс початкової швидкості
        HealthPlayerGameScene.Health = 100f;

        Object.DontDestroyOnLoad(playerTarget);
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Destroy(playerTarget);
        SceneManager.LoadScene(1);
    }

    public void TOPPlayer()
    {
        Destroy(playerTarget);
        SceneManager.LoadScene(5);
    }

}
