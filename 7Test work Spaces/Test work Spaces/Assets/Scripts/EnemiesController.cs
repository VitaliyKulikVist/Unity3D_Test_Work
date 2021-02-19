using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public GameObject Player;
    private GameObject[] Health;
    public GameObject[] _Enemies;
    public GameObject Bullet;
    public GameObject BulletCopy;

    [SerializeField]
    private float vidstanMoovDown = 4.0f;
    [SerializeField]
    private float intervalShoot_T = 1f;//Змінний параметр "...С настраиваемой периодичностью (T) ..."
    [SerializeField]
    private int kilkistShoot_N = 1;//Змінний параметр "... от 1 до N случайно выбранных врагов стреляют вниз..."
    private Vector3 moveEnemies = Vector3.zero;
    private CapsuleCollider2D colliderEnemies;
    

    void Start()
    {
        colliderEnemies = GetComponent<CapsuleCollider2D>();
        _Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Health = GameObject.FindGameObjectsWithTag("Health");

        StartCoroutine(Moov());
        StartCoroutine(EnimiesFire());

    }


    int kilk1 = 0;
    void Update()
    {
        _Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Health = GameObject.FindGameObjectsWithTag("Health");


        if (transform.position.y < -1.5f)//обмеження на спуск вниз
        {
            kilk1++;
            for (int i = 0; i < kilk1; i++)
            {
                Debug.Log($"Destriy at Down:{i}");
                Destroy(Health[i].gameObject);//знищити стількі сердець скільки пропущено ворогів
            }
            Destroy(gameObject);//Знищити самих ворогів
        }
    }
    IEnumerator Moov()
    {
            for( float i=-0.6f; i < 0.6f; i +=0.1f)//Рух з лівої частини в праву, 5 разів і в право 5 разів
            {
            //Debug.Log("Do " + transform.position);
            transform.position -= new Vector3(i, vidstanMoovDown * Time.deltaTime, 0f);
            yield return new WaitForSeconds(1f);//затримка в 1с
            if (i >= 0.59f)
            {
                i = -0.6f;
                Debug.Log("If Sucsful ");
            }

        }
    }
    IEnumerator EnimiesFire()
    {
        int kilkEnimies = Random.Range(0, _Enemies.Length);

            BulletCopy = Instantiate(Bullet, new Vector3(_Enemies[kilkEnimies].transform.position.x, _Enemies[kilkEnimies].transform.position.y - 0.25f, _Enemies[kilkEnimies].transform.position.z), Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(1f / intervalShoot_T);//затримка в 1/T
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int kilk2 = 0;
        if (Player.transform.position==collision.transform.position)
        {
            kilk2++;
                for (int i = 0; i < kilk2; i++)
                {
                    Debug.Log($"Shoot at a Player{i}");
                Destroy(Health[i].gameObject);//Знищення серця якщо користувач зіткнувся кораблем з противником
                }
            collision.gameObject.transform.position = new Vector3(-0.55f, -4f, 9f);//якщо наткнемось на ворога, літаючи, перенесе на початкові координати
        }
            //Destroy(gameObject,3f);
        }
    }

