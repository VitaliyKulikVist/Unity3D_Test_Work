using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//не забути добавиити цю бібліотеку щоб працював сцен менеджер

public class LoadLevel : MonoBehaviour
{
    // Лоад сцен, вішаєм як скрипт на трігер(бок зробити як трігер) повісити на ігрока, тег Player
    public int number_1_scene;
    public string playerTag;
    void OnTriggerStay (Collider other)
    {
        Debug.Log("!!!!!");//Буде виводитись знак оклику якщо будемо в тригеры
        if(other.tag== playerTag)
        {

            //переход на сцену яка вказана на трігері!
            SceneManager.LoadScene(number_1_scene);//номер берем при додавані сцен в білд менеджері, там вони матимуть індекс якій вписуємо на трігері в скріпт



            /*
            if (Input.GetKeyDown(KeyCode.E))//Переход на сцену при нажиманні будучи в середині трігера на Е!
            {
                SceneManager.LoadScene(number_1_scene);//номер берем при додавані сцен в білд менеджері, там вони матимуть індекс якій вписуємо на трігері в скріпт
                
            }
        */
    
    }

        
    }
}
