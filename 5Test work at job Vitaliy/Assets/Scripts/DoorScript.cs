using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject bullet;
    public GameObject player;
    public GameObject lightning;

    private RayCast rayCast;

    void Update()
    {
        GameObject[] copyBullets;//Масив гейм обжектів
        copyBullets = GameObject.FindGameObjectsWithTag("Bullets");//занесення в масив всіх з тегом Bullets
        foreach (GameObject bu in copyBullets)//Цикл перебору всіх з тегом Bullets
        {
            float dist = Vector3.Distance(bu.transform.position, leftDoor.transform.position);//обрахунок відстані між копією пулі і лівою дверрю
                if (dist <= 5f)//відстань для відкриття дверей
                {
                    leftDoor.transform.position = new Vector3(leftDoor.transform.position.x + 0.015f, 0.555f, 1.85f);//відкрити ліву дверь
                    rightDoor.transform.position = new Vector3(rightDoor.transform.position.x - 0.015f, 0.555f, 1.85f);//Відкрити праву дверь
                    //player.gameObject.GetComponent<CameraControl>().enabled = false;
                    //player.gameObject.transform.SetParent(null);
                    lightning.gameObject.GetComponent<Light>().enabled = true;//Увімкнути світло
                player.gameObject.GetComponent<Animator>().enabled = true;//Увімкнення анімації(навіть .Play() не знадобилось)
                //player.gameObject.transform.Translate(Vector3.forward * Time.deltaTime*5);//уїзджає вперед


                float distPlayer = Vector3.Distance(player.transform.position, leftDoor.transform.position);//перевірка відстані гравця і лівої двері
                if (distPlayer <= 10f)//якщо ігрок на відстані 5 від дверей
                {
                    print("The end");//Вивестии це кінець
                    Application.Quit();//Закрити гру
                }
            }
        }
        
        

        
            



    }
}
