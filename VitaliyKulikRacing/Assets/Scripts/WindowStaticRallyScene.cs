using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WindowStaticRallyScene : MonoBehaviour
{
    private GameObject playerTarget;
    private GameObject RaccingEnemy1;
    private GameObject RaccingEnemy2;

    private GameObject _finish;

    public Camera Camera;
    public Text TimeText;
    public Text TimerText;
    public Text Position;
    public Button _buttonBack;

    public static float[] SaveFinalTime = new float[3];
    public static float timer { get; set; }
    void Start()
    {
        //Debug.Log($"Speed= {ButtonCarsScenes.SaveBasicSpeed}\tControll= {ButtonCarsScenes.SaveBasicControl}");
        ButtonCarsScenes.SaveBasicSpeed *= 5;
        ButtonCarsScenes.SaveBasicControl *= 5;
        _finish = GameObject.Find("Finish");

        playerTarget = GameObject.Find("PlayerCar");
        playerTarget.transform.position = Vector3.zero;
        playerTarget.transform.position = new Vector3(0f, 2f, 3f);//Spawn
        playerTarget.layer = 8;
        foreach (Transform child in playerTarget.GetComponentsInChildren<Transform>(true))//Зміна слоя в дочірніх обєктів(в наошому випадку колес)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        RaccingEnemy1 = GameObject.Find("RaccingEnemy1");
        RaccingEnemy1.transform.position = Vector3.zero;
        RaccingEnemy1.transform.position = new Vector3(-2f, 2f, 3f);//Spawn
        RaccingEnemy1.layer = 9;
        foreach (Transform child in RaccingEnemy1.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = LayerMask.NameToLayer("PaccingEnemy1");
        }
        RaccingEnemy2 = GameObject.Find("RaccingEnemy2");
        RaccingEnemy2.transform.position = Vector3.zero;
        RaccingEnemy2.transform.position = new Vector3(-4f, 2f, 3f);//Spawn
        RaccingEnemy2.layer = 10;
        foreach (Transform child in RaccingEnemy2.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = LayerMask.NameToLayer("PaccingEnemy2");
        }
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(8, 5);
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(9, 5);
        Physics2D.IgnoreLayerCollision(10, 5);

        TimeText.enabled = false;
        _buttonBack.onClick.AddListener(() => Back());
        timer = 0;
    }
    private void RemoveListener()
    {
        _buttonBack.onClick.RemoveListener(() => Back());
    }
    float timeRun = 0;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }
        PositionS();
        if (Input.anyKeyDown)//якщо буде нажата будь яка кнопка
        {
            MoveCar.Move = true;
            Position.enabled = true;
        }
        if(MoveCar.Move)
        {
            TimerText.enabled = true;
            timer += Time.deltaTime;
            if (timer <= 1)
            {
                TimerText.color = Color.green;
            }
            if (timer >= 2 && timer < 3)
            {
                TimerText.color = Color.yellow;
            }
            TimerText.text = $"{timer:0}";
            if (timer >= 3)
            {
                TimerText.color = Color.red;
                TimerText.text = "Run!!!";
            }
            if (timer >= 4)
            {
                TimerText.enabled = false;
            }
        }
        Camera.transform.position = new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y + 3f, 0f);//


        /////////////////////////////////////////////////////////
        if (TriggerStaticRally.kilkist>= 1 && TriggerStaticRally.kilkist <= 6)
        {
            TimeText.enabled = true;
            timeRun += Time.deltaTime;
            TimeText.text = $"Time: {timeRun:0.0} s";
        }
        if (TriggerStaticRally.kilkist == 4)
        {
            //first = timeRun;
            SaveFinalTime[0] = timeRun;
        }
        //Debug.Log($"First= {first}\t And {SaveFinalTime[0]}");
        if (TriggerStaticRally.kilkist == 5)
        {
            //second = timeRun;
            SaveFinalTime[1] = timeRun;
        }
        //Debug.Log($"second= {second}\t And {SaveFinalTime[1]}");
        if (TriggerStaticRally.kilkist == 6)
        {
            SaveFinalTime[2] = timeRun;
            MoveCar._Speed = 0f;//Anyway
            TriggerStaticRally.kilkist = 0;
            playerTarget.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            RaccingEnemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            RaccingEnemy2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Object.DontDestroyOnLoad(playerTarget);
            Object.DontDestroyOnLoad(RaccingEnemy1);
            Object.DontDestroyOnLoad(RaccingEnemy2);
            SceneManager.LoadScene(7);//Загрузити сцену закінчення гри для мульти плеєра
        }
        //////////////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Object.DontDestroyOnLoad(playerTarget);
            Destroy(playerTarget);
            Destroy(RaccingEnemy1);
            Destroy(RaccingEnemy2);
            SaveFinalTime = null;
            timer = 0;
            TriggerStaticRally.positionWin = null;
            TriggerStaticRally.kilkist = 0;

            SceneManager.LoadScene(0);
        }
    }
    void PositionS()
    {
        int dista=0;
        float dist1 = Vector2.Distance(playerTarget.gameObject.transform.position, _finish.transform.position);
        float dist2 = Vector2.Distance(RaccingEnemy1.gameObject.transform.position, _finish.transform.position);
        float dist3 = Vector2.Distance(RaccingEnemy2.gameObject.transform.position, _finish.transform.position);
        if (dist1 < dist2&& dist1< dist3)
        {
            dista =1;
        }
        if(dist1< dist2&& dist1 > dist3|| dist1 < dist3 && dist1 > dist2)
        {
            dista = 2;
        }
        if (dist1 >= dist2&& dist1 >= dist3)
        {
            dista = 3;
        }
        //Debug.Log($"headin  {dist1}\theading   {dist2}\theadingFinish  {dist3}");
        Position.text = $"Position: {dista}";
    }

    public void Back()
    {
        Destroy(playerTarget);
        Destroy(RaccingEnemy1);
        Destroy(RaccingEnemy2);

        SaveFinalTime = null;
        timer = 0;
        TriggerStaticRally.positionWin = null;
        TriggerStaticRally.kilkist = 0;

        WindowGameScene.SaveFinalTime = 0f;
        MoveCar.SaveFinalSpeed = 0f;
        ButtonCarsScenes.SaveBasicControl = 0f;
        ButtonCarsScenes.SaveBasicSpeed = 0f;
        MoveCar._Speed = 0f;
        TriggersGameScene.namber = 0;
        SceneManager.LoadScene(2);
    }
}
