using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public int MaxShootObject;
    public GameObject shootObject;
    public GameObject door;
    void Start()
    {
        StartCoroutine(Spawn());
        Instantiate(door, new Vector3(Random.Range(-1.6f, 14.95f), 0.555f, 1.85f), Quaternion.identity);
    }
    IEnumerator Spawn()
    {
        for(int i=0;i< MaxShootObject;i++)
        {//Створити обєкт в просторі х у з який не буде повертатись Quaternion.identity
            Instantiate(shootObject,new Vector3(Random.Range(-2f, 16f), 1.056f, Random.Range(-2f, -15f)),Quaternion.identity);//функція для створення обєктів
            yield return new WaitForSeconds(0.001f);
        }
    }

}
