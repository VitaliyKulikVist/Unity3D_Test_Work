using UnityEngine.UI;
using UnityEngine;

public class BulletMoov : MonoBehaviour
{
    public float FireSpeed_F = 20.0f;//Змінний параметр "...при нажатии пробела со скорострельностью F..."

    public static int val_H=0;//Змінний параметр "...начиная от стартового значения H..."
    private void Start()
    {

    }
    void Update()
    {
        transform.Translate(new Vector3(0f,FireSpeed_F * Time.deltaTime, 0f));//задамо прискорення
        if (transform.position.y > 3.5f)//обмеження вверх
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);//знищуємо пулю
            Destroy(gameObject);//Знищуємо ворога
            val_H+=10;//Підрахунок попадань замість +1 просто +10 очок
        }
        //Debug.Log($"Enemies is Dead{val_H-10}");
    }


}
