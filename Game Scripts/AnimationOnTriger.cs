using UnityEngine;
using UnityEngine.UI;


public class AnimationOnTriger : MonoBehaviour
{
    public Text winText;

    public static int k = 0;

    public GameObject Candy;
    public GameObject HeartTope;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            winText.text = "";
        }
    }
    
private void setCounter()
{
    winText.text = "You Win!!!";
}
private void OnTriggerEnter(Collider col)
    {
        
        
        if (col.gameObject.transform.position== Candy.transform.position)
        {
            k++;
            Candy.GetComponent<Animation>().Play();
        }
        //Debug.Log("On Triger:" + col.gameObject.name+"k:"+k);

        if (k == 8)
        {
            HeartTope.GetComponent<Animation>().Play();
        setCounter();
        }
    }


}
