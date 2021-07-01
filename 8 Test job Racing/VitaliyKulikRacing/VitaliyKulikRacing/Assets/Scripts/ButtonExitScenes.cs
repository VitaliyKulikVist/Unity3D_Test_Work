using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExitScenes : MonoBehaviour
{
    //[SerializeField]
    public Button _buttonYes;
    //[SerializeField]
    public Button _buttonNo;

    private void Start()
    {
        _buttonYes.onClick.AddListener(() => ExitGame());
        _buttonNo.onClick.AddListener(() => Return());
    }
    private void RemoveListener()
    {
        _buttonYes.onClick.RemoveListener(() => ExitGame());
        _buttonNo.onClick.RemoveListener(() => Return());
    }
    public void ExitGame()
    {
        Application.Quit();

    }
    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            Application.Quit();   
        }
        if (Input.GetKeyDown(KeyCode.End)|| Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            Application.Quit();    
        }
    }
    public void Return()
    {
        MoveCar._Speed = 0f;
        TriggersGameScene.namber = 0;
        ButtonCarsScenes.SaveBasicSpeed = 0f;
        ButtonCarsScenes.SaveBasicControl = 0f;
        WindowGameScene.SaveFinalTime = 0f;
        HealthPlayerGameScene.Health = 100f;
        MoveCar.SaveFinalSpeed = 0f;
        SceneManager.LoadScene(0);//1 exit scene    0 menu scene
    }
}
