using UnityEngine;
using UnityEngine.UI;

public class IntelectRaccingEnemy : MonoBehaviour
{
    public Text textSpeedEnemy1;
    public Text textSpeedEnemy2;

    private GameObject Finish;

    private GameObject playerTarget;
    private GameObject RaccingEnemy1;
    private GameObject RaccingEnemy2;

    private Rigidbody2D rb_enemy1;
    private Rigidbody2D rb_enemy2;

    public static float _SpeedEnemy1 { get; set; }
    public static float _SpeedEnemy2 { get; set; }

    private float _FinalSpeedEnemy1 = 0f;
    private float _FinalSpeedEnemy2 = 0f;
    public static float SaveFinalSpeedEnemy1 { get; set; }
    public static float SaveFinalSpeedEnemy2 { get; set; }
    void Start()
    {
        playerTarget = GameObject.Find("PlayerCar");
        RaccingEnemy1 = GameObject.Find("RaccingEnemy1");
        RaccingEnemy2 = GameObject.Find("RaccingEnemy2");
        Finish = GameObject.Find("Finish");
        //Debug.Log($"Finish {Finish.transform.position}");
        rb_enemy1 = RaccingEnemy1.GetComponent<Rigidbody2D>();
        rb_enemy2 = RaccingEnemy2.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        textSpeedEnemy1.transform.position = new Vector3(RaccingEnemy1.transform.position.x, RaccingEnemy1.transform.position.y+1f, RaccingEnemy1.transform.position.z);
        textSpeedEnemy2.transform.position = new Vector3(RaccingEnemy2.transform.position.x, RaccingEnemy2.transform.position.y + 1f, RaccingEnemy2.transform.position.z);

        if (WindowStaticRallyScene.timer>=3)//не будуть рухатись доти доки секундомір не буде 3+
        {
            ControlEnemy1();
            ControlEnemy2();
        }
        if (_SpeedEnemy1 == 0)
        {
            textSpeedEnemy1.enabled = false;
        }
        textSpeedEnemy1.text = $"{_SpeedEnemy1:0.00} KM/H";

        if (_FinalSpeedEnemy1 <= rb_enemy1.velocity.magnitude)
        {
            _FinalSpeedEnemy1 = rb_enemy1.velocity.magnitude;
        }
        SaveFinalSpeedEnemy1 = _FinalSpeedEnemy1;

        if (RaccingEnemy1.transform.position.y < 0)//chek in down
        {
            TriggersGameScene.namber++;
        }
        if (_SpeedEnemy2 == 0)
        {
            textSpeedEnemy2.enabled = false;
        }
        textSpeedEnemy2.text = $"{_SpeedEnemy2:0.00} KM/H";

        if (_FinalSpeedEnemy2 <= rb_enemy2.velocity.magnitude)
        {
            _FinalSpeedEnemy2 = rb_enemy2.velocity.magnitude;
        }
        SaveFinalSpeedEnemy2 = _FinalSpeedEnemy2;

        if (RaccingEnemy2.transform.position.y < 0)//chek in down
        {
            TriggersGameScene.namber++;
        }

    }
    private float timeStop1 = 0;
    private float timeStop2 = 0;
    private void ControlEnemy1()
    {
        rb_enemy1.AddForce(transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух вперед такий же як і в ігрока
        textSpeedEnemy1.enabled = true;
        _SpeedEnemy1 = rb_enemy1.velocity.magnitude;
        textSpeedEnemy1.GetComponent<Text>().color = Color.green;
        if (rb_enemy1.rotation >= 50f)
        {
            rb_enemy1.MoveRotation(rb_enemy1.rotation - ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (rb_enemy1.rotation <= -50f)
        {
            rb_enemy1.MoveRotation(rb_enemy1.rotation + ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (_SpeedEnemy1 <= 1)
        {
            timeStop1 +=Time.deltaTime;
            if(timeStop1>=4f)//якщо більше 4 секунд не буде швидкість рости тоді пригне
            {
                rb_enemy1.MovePosition(rb_enemy1.position + Vector2.up * ButtonCarsScenes.SaveBasicControl * 2f * Time.deltaTime);
            }
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void ControlEnemy2()
    {
        rb_enemy2.AddForce(transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух вперед такий же як і в ігрока
        textSpeedEnemy2.enabled = true;
        _SpeedEnemy2 = rb_enemy2.velocity.magnitude;
        textSpeedEnemy2.GetComponent<Text>().color = Color.green;
        if (rb_enemy2.rotation >= 50f)
        {
            rb_enemy2.MoveRotation(rb_enemy2.rotation - ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (rb_enemy2.rotation <= -50f)
        {
            rb_enemy2.MoveRotation(rb_enemy2.rotation + ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (_SpeedEnemy2 <= 1)
        {
            timeStop2 += Time.deltaTime;
            if (timeStop2 >= 4f)//якщо більше 4 секунд не буде швидкість рости тоді пригне
            {
                rb_enemy2.MovePosition(rb_enemy2.position + Vector2.up * ButtonCarsScenes.SaveBasicControl * 2f * Time.deltaTime);
            }
        }
    }


}
