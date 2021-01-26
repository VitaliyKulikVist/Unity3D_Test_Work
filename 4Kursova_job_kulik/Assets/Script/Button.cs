using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public GameObject buttonStart;
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsFaq;
    public GameObject buttonsSettings;



    public GameObject buttonsBack;
    public GameObject buttonsTheEnd;


    public GameObject Corpus_1_1;
    public GameObject Corpus_1_2;
    public GameObject Corpus_1_3;
    public GameObject Corpus_1_4;
    public GameObject Corpus_1_5;

    // Start is called before the first frame update
    
    public void ShowStartMenu()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsFaq.SetActive(false);
        buttonsSettings.SetActive(false);
        buttonStart.SetActive(true);
    }
    public void ShowExitButtons()//Кнопка "Вихід" робить видимими 2 кнопки і текст а не видимим все інше
    {
        buttonsFaq.SetActive(false);
        buttonsSettings.SetActive(false);
        buttonsMenu.SetActive(false);
        buttonStart.SetActive(false);
        buttonsExit.SetActive(true);
    }
    public void ShowFaq()//Кнопка "Про програму" робить невидимим всі вікна окрім налаштувань.
    {
        buttonsSettings.SetActive(false);
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonStart.SetActive(false);
        buttonsFaq.SetActive(true);
    }
    public void ShowSettings()//Кнопка "налаштування", робить видимими всі настройкі і не видимими всі інші
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsFaq.SetActive(false);
        buttonStart.SetActive(false);
        buttonsSettings.SetActive(true);
    }
    public void ShowMainMenu()//Кнопка повернення на головний екран, робить не видимими всі параметри окрім мейн
    {
        buttonsExit.SetActive(false);
        buttonsFaq.SetActive(false);
        buttonsSettings.SetActive(false);
        buttonStart.SetActive(false);
        buttonsMenu.SetActive(true);
    }
    public void ClosedTheProgram()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsFaq.SetActive(false);
        buttonsSettings.SetActive(false);
        buttonStart.SetActive(false);
        Application.Quit();
    }
    //не забути прописати цифри сцен в Меню контроллері
    public int number_0_0_scene, number_1_1_scene, number_1_2_scene, number_1_3_scene, number_1_4_scene, number_1_5_scene;
    public void Show_Corpus_0_0()
    {
        SceneManager.LoadScene(number_0_0_scene);
    }
    public void Show_Corpus_1_1()
    {
    SceneManager.LoadScene(number_1_1_scene);
    }
    public void Show_Corpus_1_2()
    {
        SceneManager.LoadScene(number_1_2_scene);
    }
    public void Show_Corpus_1_3()
    {
        SceneManager.LoadScene(number_1_3_scene);
    }
    public void Show_Corpus_1_4()
    {
        SceneManager.LoadScene(number_1_4_scene);
    }
    public void Show_Corpus_1_5()
    {
        SceneManager.LoadScene(number_1_5_scene);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(number_0_0_scene);
        }
    }

}


