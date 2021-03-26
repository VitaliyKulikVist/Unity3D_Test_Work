using UnityEngine.UI;
using UnityEngine;
public class TachControll : MonoBehaviour//, IPointerClickHandler , IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private Text textSpeed;
    private GameObject playerTarget;
    private Rigidbody2D rb;
    void Start()
    {
        textSpeed = GameObject.Find("TextSpeed").GetComponent<Text>();
        playerTarget = GameObject.Find("PlayerCar");
        rb = playerTarget.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (playerTarget.transform.position.y < 0)//chek in down
        {
            TriggersGameScene.namber++;
        }
    }
    private float kilk = 0f;
    private void OnMouseDrag()
    {
        if (WindowStaticRallyScene.timer >= 3)
    {  
        kilk += Time.deltaTime;
        if (gameObject.name == "ButtonControllLeft")
        {
            MoveCar.Move = true;
            rb.AddForce(-transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух назад
            textSpeed.enabled = true;
            MoveCar._Speed = -rb.velocity.magnitude;
            textSpeed.GetComponent<Text>().color = Color.red;
        }
        if (gameObject.name == "ButtonControllRight")
        {
            MoveCar.Move = true;
            rb.AddForce(transform.right * ButtonCarsScenes.SaveBasicSpeed);//Рівно прискорений рух вперед
            textSpeed.enabled = true;
            MoveCar._Speed = rb.velocity.magnitude;
            textSpeed.GetComponent<Text>().color = Color.green;
        }
        if (gameObject.name == "ButtonControllUp")
        {
            MoveCar.Move = true;
            rb.MoveRotation(rb.rotation + ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (gameObject.name == "ButtonControllDown")
        {
            MoveCar.Move = true;
            rb.MoveRotation(rb.rotation - ButtonCarsScenes.SaveBasicControl * 20f * Time.fixedDeltaTime);
        }
        if (gameObject.name == "ButtonControllJump")
        {
            MoveCar.Move = true;
            rb.MovePosition(rb.position + Vector2.down * ButtonCarsScenes.SaveBasicControl * Time.deltaTime);
        }
    }
    }
    private void OnMouseUp()
    {
        if (gameObject.name == "ButtonControllJump")
        {
            MoveCar.Move = true;
            rb.MovePosition(rb.position + Vector2.up * ButtonCarsScenes.SaveBasicControl * Time.deltaTime);
        }
            kilk = 0f;
    }
}
