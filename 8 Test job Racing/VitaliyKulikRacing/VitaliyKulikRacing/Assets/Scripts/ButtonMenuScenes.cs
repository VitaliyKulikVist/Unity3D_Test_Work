using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ButtonMenuScenes : MonoBehaviour
{
    //[SerializeField]
    public Button _EndGame;
    //[SerializeField]
    public Button _StartSingleGame;
    //[SerializeField]
    public Button _StartMultiGame;
    public static int SwitchMenu=0;

    private void Start()
    {
        _EndGame.onClick.AddListener(() => EndGame());
        _StartSingleGame.onClick.AddListener(() => StartSingleGame());
        _StartMultiGame.onClick.AddListener(() => StartMultiGame());

    }
    private void RemoveListener()
    {
        _EndGame.onClick.RemoveListener(() => EndGame());
        _StartSingleGame.onClick.RemoveListener(() => StartSingleGame());
        _StartMultiGame.onClick.RemoveListener(() => StartMultiGame());
    }
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            RemoveListener();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.End)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartSingleGame()
    {
        SwitchMenu = 1;
        SceneManager.LoadScene(2);
    }
    public void StartMultiGame()
    {
        SwitchMenu = 2;
        SceneManager.LoadScene(2);
    }
}

