using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBulletMoov : MonoBehaviour
{

    public float EnemiesFireSpeed_F = 20.0f;

    private GameObject[] Health;

    private void Start()
    {
        
    }

    void Update()
    {
        Health = GameObject.FindGameObjectsWithTag("Health");
        transform.Translate(new Vector3(0f,-EnemiesFireSpeed_F * Time.deltaTime, 0f));//задамо прискорення
        if (transform.position.y <-4f)//Обмеження вниз
        {
                Destroy(gameObject);//Знищуэмо пулю об яку вдарились
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int kilk3 = 0;
        if (collision.gameObject.tag == "Player")
        {
            kilk3++;
            for(int i=0;i< kilk3;i++)
            {
                Destroy(Health[i].gameObject);//знищуємо серце якщо ворог попав по користувачу
                collision.gameObject.transform.position = new Vector3(-0.55f, -4f, 9f);//Переміщаємо гг на початкову позицію
            }
                Destroy(gameObject);//Знищуэмо пулю об яку вдарились
            }
    }
}
