using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WindowGameScene : MonoBehaviour
{
    private GameObject playerTarget;
    public Camera Camera;
    public Text TimeText;
    public Text TimerText;
    public Button _buttonBack;
    public static float SaveFinalTime { get; set; }
    void Start()
    {
        //Debug.Log($"Speed= {ButtonCarsScenes.SaveBasicSpeed}\tControll= {ButtonCarsScenes.SaveBasicControl}");
        ButtonCarsScenes.SaveBasicSpeed *= 5;
        ButtonCarsScenes.SaveBasicControl *= 5;
        playerTarget = GameObject.Find("PlayerCar");
        playerTarget.transform.position = Vector3.zero;
        playerTarget.transform.position = new Vector3(0f, 2f, 3f);//Spawn
        TimeText.enabled = false;
        _buttonBack.onClick.AddListener(() => Back());
        WindowStaticRallyScene.timer = 0;
    }
    private void RemoveListener()
    {
        _buttonBack.onClick.RemoveListener(() => Back());
    }
    float timeRun = 0;
    float finalTime = 0;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
        Camera.transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y+3f, 0f);//

        if (Input.anyKeyDown)//якщо буде нажата будь яка кнопка
        {
            MoveCar.Move = true;
        }
        if (MoveCar.Move)
        {
            TimerText.enabled = true;
            WindowStaticRallyScene.timer += Time.deltaTime;
            if (WindowStaticRallyScene.timer <= 1)
            {
                TimerText.color = Color.green;
            }
            if (WindowStaticRallyScene.timer >= 2 && WindowStaticRallyScene.timer < 3)
            {
                TimerText.color = Color.yellow;
            }
            TimerText.text = $"{WindowStaticRallyScene.timer:0}";
            if (WindowStaticRallyScene.timer >= 3)
            {
                TimerText.color = Color.red;
                TimerText.text = "Run!!!";
            }
            if (WindowStaticRallyScene.timer >= 4)
            {
                TimerText.enabled = false;
            }
        }

            if (TriggersGameScene.namber == 1&& TriggersGameScene.namber !=2)
        {
            TimeText.enabled = true;
            timeRun += Time.deltaTime;
            TimeText.text = $"Time: {timeRun:0.0} s";
        }
        if (TriggersGameScene.namber ==2)
        {
            finalTime = timeRun;
            TimeText.text = $"Final Time: {finalTime:0.0} s";
            MoveCar._Speed = 0f;//Anyway
            TriggersGameScene.namber = 0;
            Debug.Log($"Dead Helth= {HealthPlayerGameScene.Health}");
            SceneManager.LoadScene(4);//Загрузити сцену закінчення гри для сінгл плеєра
        }
        SaveFinalTime = finalTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Object.DontDestroyOnLoad(playerTarget);
            Destroy(playerTarget);
            SceneManager.LoadScene(2);
        }
    }
    public void Back()
    {
        Destroy(playerTarget);
        WindowGameScene.SaveFinalTime = 0f;
        MoveCar.SaveFinalSpeed = 0f;
        ButtonCarsScenes.SaveBasicControl = 0f;
        ButtonCarsScenes.SaveBasicSpeed = 0f;
        MoveCar._Speed = 0f;
        TriggersGameScene.namber = 0;
        SceneManager.LoadScene(2);
    }
}
