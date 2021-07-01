using UnityEngine.UI;
using UnityEngine;

public class MoveCar : MonoBehaviour//, IPointerClickHandler,IPointerDownHandler,IPointerEnterHandler,IPointerUpHandler
{
    public Text textSpeed;
    public Text textHelp;
    public Image imageHelp;
    private GameObject playerTarget;
    private Rigidbody2D rb;
    public static float _Speed { get; set; }
    private float _FinalSpeed = 0f;
    public static float SaveFinalSpeed { get; set; }
    public static bool Move { get; set; } = false;

    void Start()
    {
        ButtonCarsScenes.SaveBasicSpeed *= 10f;//до стандартних змінних домножимо 10 щоб була більш помітна різниця стат
        ButtonCarsScenes.SaveBasicControl *= 10f;
        playerTarget = GameObject.Find("PlayerCar");
        rb = playerTarget.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (_Speed >= 50)//зповільнення на випадок великої швидкості
        {
            rb.AddForce(-transform.right * ButtonCarsScenes.SaveBasicSpeed);
        }
    }
    private float timerjump = 0f;
    void Update()
    {

            if (Input.anyKeyDown||Input.touchCount>0)//якщо буде нажата будь яка кнопка
        {
            Move = true;
        }
            if (WindowStaticRallyScene.timer >= 3)
        {
            ControllKeyboard();
        }
        if (Move)
        {
            textHelp.enabled = false;
            imageHelp.enabled = false;
        }
        if (_Speed == 0)
        {
            textSpeed.enabled = false;
        }
        textSpeed.text = $"Speed: {_Speed:0.00} KM/H";

        if (_FinalSpeed <= rb.velocity.magnitude)
        {
            _FinalSpeed = rb.velocity.magnitude;
        }
        SaveFinalSpeed = _FinalSpeed;

        if(playerTarget.transform.position.y<0)//chek in down
        {
            TriggersGameScene.namber++;
        }
    }
    private void ControllKeyboard()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))//UP
        {
            rb.AddForce(-transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух назад
            textSpeed.enabled = true;
            _Speed = -rb.velocity.magnitude;
            textSpeed.GetComponent<Text>().color = Color.red;
            //Debug.Log("Left");
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) )//UP
        {
            rb.AddForce(transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух вперед
            textSpeed.enabled = true;
            _Speed = rb.velocity.magnitude;
            textSpeed.GetComponent<Text>().color = Color.green;
            //Debug.Log("Right");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )//back
        {
            rb.MoveRotation(rb.rotation + ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
            //Debug.Log("Up");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) )//go
        {
            rb.MoveRotation(rb.rotation - ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
            //Debug.Log("Down");
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            timerjump += Time.deltaTime * 8f;//чим довше утримувати кнопу, тим вищий буде прижок(але і керованість авто також грає роль)
            rb.MovePosition(rb.position + Vector2.down * ButtonCarsScenes.SaveBasicControl * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            rb.MovePosition(rb.position + Vector2.up * ButtonCarsScenes.SaveBasicControl * timerjump * Time.deltaTime);
            //Debug.Log("Jump");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.MovePosition(rb.position + Vector2.zero * ButtonCarsScenes.SaveBasicControl * Time.deltaTime);
            if (rb.velocity.magnitude < 1)
            {
                _Speed = 0f;
            }
        }
    }
}
