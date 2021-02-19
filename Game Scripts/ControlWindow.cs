using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlWindow : MonoBehaviour
{

    

    private void Start()
    {

    }
    public void Update()
    {
        if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
        {
            Application.Quit();    // закрыть приложение
        }
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene(1);

    }
    public void LoadStartGameScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitAtGame()
    {
        Application.Quit();
    }

    

}
