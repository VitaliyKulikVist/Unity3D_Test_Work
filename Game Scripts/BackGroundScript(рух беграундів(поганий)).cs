using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    MoveCar moveCar;
    private float speed = 0f;
    private Vector2 offset = Vector2.zero;
    private Material material;
    void Start()
    {
        var height = Camera.main.orthographicSize*3f;//висота
        //var height = Screen.height/40f;//висота
        var width = height * Screen.width/ Screen.height*0.15f;//ширина
        if (gameObject.tag=="BackGround")
        {
            transform.localScale = new Vector3(width, height, 0);
        }
        else
        {
            transform.localScale = new Vector3(width + 3f,5,0);
        }
        //////////////////////////////////////////////
        if (gameObject.tag == "Ground")
        {
            transform.localScale = new Vector3(width*1.5f, height/5f, 0);
        }
        else
        {
            transform.localScale = new Vector3(width + 3f, 5, 0);
        }
        material = GetComponent<Renderer>().material;
        offset = material.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        speed = MoveCar._Speed/20f;
        offset.x += speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
