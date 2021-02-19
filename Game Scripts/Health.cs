using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField]
    private int HealthLimit_H = 6;

    public GameObject[] _Health;
    public GameObject[] _Enemies;

    public Text Value;
    public Text Lose;
    public Text Win;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Value.text = BulletMoov.val_H.ToString();

        _Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        _Health = GameObject.FindGameObjectsWithTag("Health");//Затратно по памяті но поки не знаю як по іншому

        if (_Health.Length > HealthLimit_H)
        {
            for (int i = 0; i < _Health.Length - HealthLimit_H; i++)
            {
                Destroy(_Health[i].gameObject);
            }
        }

        if (_Health.Length == 0)
        {
            Lose.GetComponent<Text>().enabled = true;//Не маю уявлення як втримати надпис довше( пробував через yield return WaitForSeconds(2f)
            SceneManager.LoadScene(0);
        }

        if (_Enemies.Length == 0)
        {
            Win.GetComponent<Text>().enabled = true;
            SceneManager.LoadScene(0);
        }
    }
}
