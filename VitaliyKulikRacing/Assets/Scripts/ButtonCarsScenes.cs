using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ButtonCarsScenes : MonoBehaviour
{
    //[SerializeField]
    private GameObject[] _Cars;
    private GameObject _CarsCopy;
    public Text textSpeed;
    public Image imageSpeed;
    public Text textValueSpeed;
    public Text textControl;
    public Image imageControl;
    public Text textValueControl;
    private float basicSpeed;
    private float basicControl;


    //[SerializeField]
    public Button _buttonOk;
    //[SerializeField]
    public Button _buttonLast;
    //[SerializeField]
    public Button _buttonNext;
    //[SerializeField]
    public Button _buttonBack;

    public static float SaveBasicSpeed { get; set; }
    public static float SaveBasicControl { get; set; }
    Vector3 pos = new Vector3(0f, 0f, 2.5f);//Position Spawn
    public void Start()
    {
        //Anyway
        HealthPlayerGameScene.Health = 100f;
        MoveCar._Speed = 0f;

        _Cars = GameObject.FindGameObjectsWithTag("Player");
        _buttonOk.onClick.AddListener(() => OK());
        _buttonLast.onClick.AddListener(() => Left());
        _buttonNext.onClick.AddListener(() => Right());
        _buttonBack.onClick.AddListener(() => Back());

    }
    private void RemoveListener()
    {
        _buttonOk.onClick.RemoveListener(() => OK());
        _buttonLast.onClick.RemoveListener(() => Left());
        _buttonNext.onClick.RemoveListener(() => Right());
        _buttonBack.onClick.RemoveListener(() => Back());
    }
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.End)||Input.GetKey("enter"))
        {
            OK();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _buttonOk.image.enabled = true;
            Right();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _buttonOk.image.enabled = true;
            Left();
        }

    }
    private int left_key_down = 0;
    public void Left()
    {
        _buttonOk.image.enabled = true;
        textSpeed.enabled = true;
        textControl.enabled = true;
        imageSpeed.enabled = true;
        imageControl.enabled = true;
        textValueSpeed.enabled = true;
        textValueControl.enabled = true;
        float[,] parCar = new float[_Cars.Length, 2];//Можна вручну кожен параметр прописати а можна добавити варіативності і елемент удачі
        for (int i = 0; i < _Cars.Length; i++)
            for (int j = 0; j < 2; j++)
            {
                parCar[i, j] = Random.Range(0f, 1f);//рандомізація кожного нового параметра(Але параметрів може не вистачити щоб пройти карту)
            }
        for (int i = 0; i < _Cars.Length; i++)
        {
            imageSpeed.GetComponent<Image>().fillAmount = parCar[i, 0];
            imageControl.GetComponent<Image>().fillAmount = parCar[i, 1];

            basicSpeed = parCar[i, 0];
            textValueSpeed.text = $"{ basicSpeed * 10:0.00} KM/H";
            basicControl = parCar[i, 1];
            textValueControl.text = $"{ basicControl * 10:0.00} N/m^2";
        }
        if (GameObject.FindGameObjectsWithTag("Clone").Length>0)
        {
            Destroy(_CarsCopy);
        }
        //last car (з кінця в початок) 
        if (left_key_down == _Cars.Length)
        {
            left_key_down = 0;
        }
        left_key_down++;
        _CarsCopy =Instantiate(_Cars[_Cars.Length- left_key_down], pos, Quaternion.identity) as GameObject;
        _CarsCopy.tag = "Clone";
        
    }
    private int right_key_down = 0;
    public void Right()
    {
        _buttonOk.image.enabled = true;
        textSpeed.enabled = true;
        textControl.enabled = true;
        imageSpeed.enabled = true;
        imageControl.enabled = true;
        textValueSpeed.enabled = true;
        textValueControl.enabled = true;

        float[,] parCar = new float[_Cars.Length, 2];//Можна вручну кожен параметр прописати а можна добавити варіативності і елемент удачі
        for (int i = 0; i < _Cars.Length; i++)
            for (int j = 0; j < 2; j++)
            {
                parCar[i, j] = Random.Range(0f, 1f);
            }
        for (int i = 0; i < _Cars.Length; i++)
        {
            imageSpeed.fillAmount = parCar[i, 0];
            imageControl.fillAmount = parCar[i, 1];
            basicSpeed = parCar[i, 0];
            textValueSpeed.text = $"{parCar[i, 0] * 10:0.00} KM/H";
            basicControl = parCar[i, 1];
            textValueControl.text = $"{parCar[i, 1] * 10:0.00} N/m^2";
        }
        if (GameObject.FindGameObjectsWithTag("Clone").Length > 0)
        {
            Destroy(_CarsCopy);
        }
        //Next Car(з початку в кінець)  
        if (right_key_down == _Cars.Length)
        {
            right_key_down = 0;
        }
            _CarsCopy = Instantiate(_Cars[right_key_down], pos, Quaternion.identity) as GameObject;
            _CarsCopy.tag = "Clone";
            right_key_down++;
    }
    public void OK()
    {
        if(GameObject.FindGameObjectsWithTag("Clone").Length > 0)
        {
            if(ButtonMenuScenes.SwitchMenu==1)
            {
                TriggersGameScene.namber = 0;
                _CarsCopy.name = "PlayerCar";
                _CarsCopy.tag = "GameController";
                _CarsCopy.layer = 8;
                Object.DontDestroyOnLoad(_CarsCopy);
                SaveBasicSpeed = basicSpeed;
                SaveBasicControl = basicControl;
                SceneManager.LoadScene(3);//Exit[1] menu[0] cars[2] game[3]
            }
                
            if (ButtonMenuScenes.SwitchMenu == 2)
            {
                TriggersGameScene.namber = 0;
                _CarsCopy.name = "PlayerCar";
                _CarsCopy.tag = "GameController";
                _CarsCopy.layer = 8;
                Object.DontDestroyOnLoad(_CarsCopy);
                SaveBasicSpeed = basicSpeed;
                SaveBasicControl = basicControl;
                SceneManager.LoadScene(6);//Exit[1] menu[0] cars[2] game[3]vv
            }
                
        }
    }
        public void Back()
    {
        SceneManager.LoadScene(0);
    }
    }
