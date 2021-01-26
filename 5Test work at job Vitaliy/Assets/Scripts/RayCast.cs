using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    public GameObject boolet;
    [SerializeField]
    public GameObject traser;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject door;
    private float speedTraser=10f;
    //private float speedBoolet=15f;
    //Rigidbody bullet;

    void Start()
    {
        
    }
    void LateUpdate()
    {
        traser.gameObject.SetActive(false);//Трасіровка першочергово не видна 
        //boolet.gameObject.SetActive(false);//Пуля першочергово не видна
        if (Input.GetMouseButton(0))//якщо кнопка мишкі ЗАЖАТА
        {
            //timeClick += Time.deltaTime / 2;//Для відносного підрахунку часу утримання ЛКМ
            traser.gameObject.SetActive(true);//зробити видимим трейсер
            //boolet.gameObject.SetActive(true);
            traser.gameObject.transform.Translate(Vector3.forward * speedTraser * Time.deltaTime);//уїзджає вперед

            boolet.transform.localScale += Vector3.one * Time.deltaTime / 10;
            traser.transform.localScale = new Vector3(traser.transform.localScale.x-Time.deltaTime/100, traser.transform.localScale.y, traser.transform.localScale.z);
            player.transform.localScale-= Vector3.one * Time.deltaTime / 10;
            if(player.transform.localScale.x<=0.2f)//перевірка розмірів головного користувача, якщо менші ніж 0.2
            {
                print("The end");
                Application.Quit();//закриит гру
            }
        }
        else
        {
            //повернемо трейсер і пулю на початкове місце( да костиль но поки не знаю як по іншому)
            traser.gameObject.transform.position = new Vector3(6.74f, 0.557f, -18.19f);
            boolet.gameObject.transform.position = new Vector3(6.8f, 1f, -16.5f);
        }
        if (Input.GetMouseButtonUp(0))//Якщо ВІДЖАТА ліва кнопка мишкі
        {
            GameObject newBullet = Instantiate(boolet, boolet.transform.position, Quaternion.identity) as GameObject;//створюємо новий обєкт(його копію) в прщиціх boolet з булет поворотом
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * 15f;//Задаємо прискорення Rigidbody

            //1 із методів прописання пулі через Rigidbody
            //bullet = Instantiate(boolet, boolet.transform.position, Quaternion.identity).GetComponent<Rigidbody>();//Створюємо копію обєкту яким стрелятимемо
            //bullet.velocity = transform.TransformDirection(Vector3.forward * 15);//Задаємо прискорення цій копії

            Ray ray = new Ray(transform.position, door.gameObject.transform.position);//дуч в двері
            Debug.DrawRay(transform.position, transform.forward * 2000, Color.yellow);
            RaycastHit _hit;// точка зіткнення луча і сам обєкт з яким зіткнувся луч

            //Чи попав луч(рейкаст) в щось, і занести інформацію о попаданні в _hit
            if (Physics.Raycast(ray, out _hit, Mathf.Infinity)) //Raycast вдарить в 1 обєкт і перестане далі бити RaycastAll пробиває наскрізь і повертає масив обєктів
            {
                    _hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;//в червоний ті обєкти які будуть заважати просуватись

                float dist = Vector3.Distance(_hit.transform.position, player.transform.position);//підрахунок дистанції між оємком який заважає і плеєром
                    if (dist > 10f)//якщо цей оєкт> 10
                {
                    player.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);//рухатись прямо
                }
                
                //Для знищення всіх обєктів які будуть один за одним але в полі луча
                //RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);//Створюємо масив в який будуть записуватись обєкти якіх ми лучом пробил инасркізь(може бути декільк аобєктів один за одним)
                //foreach(var hit in hits)
                //{
                //    print(_hit.transform.name);//вивід імен обєктів в які попали
                //    if(_hit.transform.tag == "ShootObject")
                //    {
                //        Destroy(_hit.transform.gameObject);
                //    }
                //}

                //Для знищення обєктів по слоях необхідно:
                //if (Physics.Raycast(ray, out _hit, Mathf.Infinity, LayerMask.GetMask("Default"))) //Raycast буде знищувати обєкти на слої Default
                //    //if (Physics.Raycast(ray, out _hit, Mathf.Infinity, 1<<8))//Raycast буде знищувати обєкти на 8-му слої
                //{
                //    if (_hit.transform.tag == "ShootObject")//якщо ми попали, і оєкт має такий тег тоді
                //    {
                //        Destroy(_hit.transform.gameObject);//знищити обєкт
                //    }
                //}
                }
            }
    }
    
    void Update()
    {
        
    }
    
    


}
