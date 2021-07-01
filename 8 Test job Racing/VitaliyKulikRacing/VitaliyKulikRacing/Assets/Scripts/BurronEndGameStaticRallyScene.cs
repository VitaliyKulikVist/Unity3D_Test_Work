using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BurronEndGameStaticRallyScene : MonoBehaviour
{
    public Text TextBasicSpeed;
    public Text TextBasicControl;
    public Text TextMaxSpeed;
    public Text TextTimeFinish;

    public Text TextTimeFirst;
    public Text TextTimeSecond;
    public Text TextTimeThird;

    private GameObject FirstPlayer;
    private GameObject SecondPlayer;
    private GameObject ThirdPlayer;
    private GameObject targetPlayer;

    //[SerializeField]
    public Button _buttonExitGame;
    //[SerializeField]
    public Button _buttonRestart;
    //[SerializeField]
    public Button _buttonTop;
    //[SerializeField]
    public Button _buttonBackMainMenu;

    private void Awake()
    {
        FirstPlayer = GameObject.Find(TriggerStaticRally.positionWin[0]);//перше місце
        SecondPlayer = GameObject.Find(TriggerStaticRally.positionWin[1]);//Друге місце
        ThirdPlayer = GameObject.Find(TriggerStaticRally.positionWin[2]);//Третє місце
        FirstPlayer.transform.position = Vector3.zero;
        SecondPlayer.transform.position = Vector3.zero;
        ThirdPlayer.transform.position = Vector3.zero;
        targetPlayer = GameObject.Find("PlayerCar");
    }
    void Start()
    {
        FirstPlayer.transform.position = new Vector3(-0.3f, -0.5f, 2.5f);//Spawn
        SecondPlayer.transform.position = new Vector3(-2.3f, -0.5f, 2.5f);//Spawn
        ThirdPlayer.transform.position = new Vector3(2f, -0.5f, 2.5f);//Spawn

        TextBasicSpeed.text = $"Speed: {ButtonCarsScenes.SaveBasicSpeed:0.00}";
        TextBasicControl.text = $"Control: {ButtonCarsScenes.SaveBasicControl:0.00}";
        TextMaxSpeed.text = $"Max Speed: {MoveCar.SaveFinalSpeed:0.00}";
        TextTimeFinish.text = $"Time Finish: {WindowStaticRallyScene.SaveFinalTime[2]:0.00}";


        TextTimeFirst.text = $"{WindowStaticRallyScene.SaveFinalTime[0]:0.00}";
        TextTimeSecond.text = $"{WindowStaticRallyScene.SaveFinalTime[1]:0.00}";
        TextTimeThird.text = $"{WindowStaticRallyScene.SaveFinalTime[2]:0.00}";

    _buttonExitGame.onClick.AddListener(() => ExitGame());
        _buttonRestart.onClick.AddListener(() => Restart());
        //_buttonTop.onClick.AddListener(() => TOPPlayer());
        _buttonBackMainMenu.onClick.AddListener(() => ReturnTomainMenu());
    }
    private void RemoveListener()
    {
        _buttonExitGame.onClick.RemoveListener(() => ExitGame());
        _buttonRestart.onClick.RemoveListener(() => Restart());
        //_buttonTop.onClick.RemoveListener(() => TOPPlayer());
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
        Destroy(FirstPlayer);
        Destroy(SecondPlayer);
        Destroy(ThirdPlayer);
        IntelectRaccingEnemy.SaveFinalSpeedEnemy1 = 0f;
        IntelectRaccingEnemy.SaveFinalSpeedEnemy2 = 0f;
        WindowStaticRallyScene.SaveFinalTime = null;
        WindowStaticRallyScene.timer = 0f;
        TriggerStaticRally.kilkist = 0;
        MoveCar.SaveFinalSpeed = 0f;
        Destroy(FirstPlayer);
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        
        IntelectRaccingEnemy.SaveFinalSpeedEnemy1 = 0f;
        IntelectRaccingEnemy.SaveFinalSpeedEnemy2 = 0f;
        WindowStaticRallyScene.SaveFinalTime = null;
        WindowStaticRallyScene.timer = 0f;
        TriggerStaticRally.kilkist = 0;
        MoveCar._Speed = 0f;//Anyway
        ButtonCarsScenes.SaveBasicControl /= 25f;//фікс початкового контролю
        ButtonCarsScenes.SaveBasicSpeed /= 25f;//фікс початкової швидкості
        Object.DontDestroyOnLoad(targetPlayer);
        //Object.DontDestroyOnLoad(SecondPlayer);
        //Object.DontDestroyOnLoad(ThirdPlayer);
        SceneManager.LoadScene(6);
    }
    public void ExitGame()
    {
        Destroy(FirstPlayer);
        Destroy(SecondPlayer);
        Destroy(ThirdPlayer);
        SceneManager.LoadScene(1);
    }

    //public void TOPPlayer()
    //{
    //    Destroy(playerTarget);
    //    SceneManager.LoadScene(5);
    //}
}
