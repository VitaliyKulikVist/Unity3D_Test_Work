using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{//Перемістити цей файл на створений Івент системи в кожній сцені яку буду робити
    public int number_0_0_scene, number_1_1_scene, number_1_2_scene, number_1_3_scene, number_1_4_scene, number_1_5_scene;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
                SceneManager.LoadScene(number_0_0_scene);
        }
        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene(number_1_1_scene);
        }
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene(number_1_2_scene);
        }
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene(number_1_3_scene);
        }
        if (Input.GetKey(KeyCode.F4))
        {
            SceneManager.LoadScene(number_1_4_scene);
        }
        if (Input.GetKey(KeyCode.F5))
        {
            SceneManager.LoadScene(number_1_5_scene);
        }




    }
}
