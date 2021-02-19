using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Швидкість ігрока Player
    [SerializeField]
    private float speedPlayer = 4.0f;

    //Швидкість спринту
    [SerializeField]
    private float sprintSpeed = 8.0f;

    public GameObject Bullet;
    public GameObject BulletCopy;

    //Змінна яка відповідає за гравітацію(силу тяжіння)
    [SerializeField]
    private float gravity = 0.0f;

    //Змінна яка відповідає за рух в 3 плоскостях(хоча використовувати будемо лише 2) Р.С. знаю про Vector 2
    private Vector3 moveDir = Vector3.zero;//При старті програми, персонаж нікуди не рухається

    //щоб кожного разу не писати CharacterController ми дамо йому іншу назву яку потім будемо використовувати(змінна яка містить компонент CharacterController)
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        moveDir = new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0f);//Управління з ПК на Мишці або на телефоні на дисплеї
      //moveDir = new Vector3(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0f);//Управління з ПК на клавіатурі
        moveDir = transform.TransformDirection(moveDir);//Обумовлюємо що рух персонажа буде міняти параметри transform згідно ж цього руху
            moveDir *= speedPlayer;//рух дорівнює швидкості
        //Ускорєніє
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDir = new Vector3(-Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0f);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= sprintSpeed;
        }
        moveDir.y -= gravity * Time.deltaTime;//від швидкості прижка віднімаємо гравітацію і робимо рухи більш плавними помноживши на час(взаємодія гравітації на персонажа)
        rb.AddForce(moveDir * speedPlayer* Time.deltaTime, ForceMode2D.Impulse);//Також всі рухи робимо плавними з інерцією (ракета як не як)
    }
    private void FixedUpdate()
    {
        //Стрільба
        StartCoroutine(Shoot());
    }
    int k = 0;
    IEnumerator Shoot()
    {
        if (Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))
        {
            k++;
            //Debug.Log("K: "+k);
            while(k>1)
            {
                BulletCopy = Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity) as GameObject;
                k = 0;
            }
            yield return new WaitForSeconds(100.0f);//затримка в 1с
        }
        
    }
}
