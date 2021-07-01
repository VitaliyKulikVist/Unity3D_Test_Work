using UnityEngine;

public class TriggerStaticRally : MonoBehaviour
{
   public static string[] positionWin = new string[3];
    public static int kilkist { get; set; } = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GameController")
        {
            kilkist++;
        }
        if(kilkist==4)
        {
            positionWin[0] = collision.name.ToString();
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (kilkist == 5)
        {
            positionWin[1] = collision.name.ToString();
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (kilkist == 6)
        {
            positionWin[2] = collision.name.ToString();
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

}
