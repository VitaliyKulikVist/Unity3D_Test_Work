using System.Collections;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public int Ennemys = 20;

    private GameObject[] Enemy;
    private GameObject EnemyCopy;
    private GameObject playerTarget;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        playerTarget = GameObject.Find("PlayerCar");
        StartCoroutine(EnimiesSpawn());
    }
    IEnumerator EnimiesSpawn()
    {
        while (true)//inf cycle
        {
            int kilkEnimies = Random.Range(0, Enemy.Length);
            EnemyCopy = Instantiate(Enemy[kilkEnimies], new Vector3(playerTarget.transform.position.x + 20f, playerTarget.transform.position.y + 10f, 3f), Quaternion.identity) as GameObject;
            EnemyCopy.tag = "Clone";
            yield return new WaitForSeconds(1.5f);//затримка в 1.5c
        }
    }
}
