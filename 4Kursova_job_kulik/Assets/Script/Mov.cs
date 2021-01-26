﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov: MonoBehaviour
{
    private CharacterController controller;

    //Швидкість ігрока Player
    public float speed = 4.0f;
    //Швидкість спринту
    public float sprintSpeed = 20.0f;
    //Швидкість прижка jump
    public float jumpspeed = 8.0f;
    //Змінна яка відповідає за гравітацію(силу притяжіння)
    public float gravity = 20.0f;
    //Змінна яка відповідає за рух в 3 плоскостях
    private Vector3 moveDir = Vector3.zero;//При старті програми, персонаж нікуди не рухається
    //щоб кожного разу не писати CharacterController ми дамо йому іншу назву яку потім будемо використовувати(змінна яка містить компонент CharacterController)
    
    void Start()
    {
        controller = GetComponent<CharacterController>();//Обумовлюємо що сонтроллер бере значення з CharacterController)
    }

    void FixedUpdate()
    {
        //Перевірка чи стоїть персонаж на землі
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//задаємо що можна рухатись по горизонталі і по вертикалі
            moveDir = transform.TransformDirection(moveDir);//Обумовлюємо що рух персонажа буде міняти параметри transform згідно ж цього руху
            moveDir *= speed;//рух дорівнює швидкості
        }



        //Ускорєніє
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= sprintSpeed;
        }



        ////перевіряємо, якщо нажата кнопка Space(пробєл до низу, бо можна написати ап, і тоді спрацювання буде коли кнопка буде віджата) і персонаж на землі(isGrounded)
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)    //якщо забрати &&controller.isGrounded то можна пригати вгору нескінченно разів
        {
            moveDir.y = jumpspeed;//рух по осі У дорівнює швидкості прижка
        }
        moveDir.y -= gravity * Time.deltaTime;//від швидкості прижка віднімаємо гравітацію і робимо рухи більш плавними помноживши на час(взаємодія гравітації на персонажа)
        controller.Move(moveDir * Time.deltaTime);//Також всі рухи робимо плавними
    }
}
