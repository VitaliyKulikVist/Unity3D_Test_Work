using UnityEngine.UI;
using UnityEngine;
public class HealthPlayerGameScene : MonoBehaviour
{
    public Text textHealth;
    public Image imageHealth;
    private GameObject playerTarget;
    public static float Health { get; set; } = 100f;
    void Start()
    {
        playerTarget = GameObject.Find("PlayerCar");
    }
    void Update()
    {
        if(ControlEnemy.HIT)//перевірка на те чи папали
        {
            helthControll();
        }
    }
    void helthControll()
    {
        textHealth.enabled = true;
        imageHealth.enabled = true;
        imageHealth.fillAmount = Health / 100f;
        if (Health >= 70f)
            textHealth.color = Color.green;
        if (Health < 70f&& Health>=40f)
            textHealth.color = Color.yellow;
        if (Health < 40f)
            textHealth.color = Color.red;

        textHealth.text = $"{Health:0.00}%";
        if (Health <= 0)
        {
            TriggersGameScene.namber++;
        }
    }



}
