using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    private GameObject playerTarget;
    //private Rigidbody2D _enRb;
    public static bool HIT { get; set; } = false;
    void Start()
    {
        playerTarget = GameObject.Find("PlayerCar");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PlayerCar"|| collision.gameObject.tag== "GameController")
        {
            Destroy(gameObject, 3f);//Destroy Enemy after 3s
            HealthPlayerGameScene.Health -= MoveCar._Speed*1.5f;//Здоров'я буде відніматись в залежності від швидкості
            HIT = true;
        }
        else
            HIT = false;
        if (collision.gameObject.tag == "Ground")
        {
            //Debug.Log($"Colisi \t{collision.gameObject.name}");
            if (gameObject.tag == "Clone")
            {
                gameObject.transform.parent = collision.transform;
                foreach (Rigidbody2D child in collision.gameObject.GetComponentsInChildren<Rigidbody2D>(true))//Зміна слоя в дочірніх обєктів(в наошому випадку колес)
                {
                    child.bodyType = RigidbodyType2D.Static;
                }
            }
               // Debug.Log($"Name {gameObject.name}");
        }

    }

}
