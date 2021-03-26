using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggersGameScene : MonoBehaviour
{
    public static int namber { get; set; } = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "GameController")
        {
            Debug.Log("Triger Start");
            namber++;
        }
    }
}
