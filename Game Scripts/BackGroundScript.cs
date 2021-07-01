using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    //Код з інтернету за для прокрутки фонів
    public MeshRenderer firstBackGround;//перший фон
    //[SerializeField]
    private float firstBGBasicSpeed = 0.1f;//множник швидкості першого фону
    public MeshRenderer secondBackGround;//другий фон
    //[SerializeField]
    private float secondBGBasicSpeed = 0.5f;//множник швидкості другого фону
    public MeshRenderer thirdBackGround;//третій фон
    //[SerializeField]
    private float thirdBGBasicSpeed = 0.2f;//множник швидкості третього фону

    private Vector2 savedFirst;
    private Vector2 savedSecond;
    private Vector2 savedThird;
    private GameObject playerTarget;

    void Awake()
    {
        if (firstBackGround) savedFirst = firstBackGround.sharedMaterial.GetTextureOffset("_MainTex");
        if (secondBackGround) savedSecond = secondBackGround.sharedMaterial.GetTextureOffset("_MainTex");
        if (thirdBackGround) savedThird = thirdBackGround.sharedMaterial.GetTextureOffset("_MainTex");
        playerTarget = GameObject.Find("PlayerCar");
    }

    void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = Vector2.zero;
        float tmpX = Mathf.Repeat(Time.time * speed, 1);
        float tmpY = Mathf.Repeat(Time.time, 1);
        //offset = new Vector2(savedOffset.x, tmpX);//По осі У
        //offset = new Vector2(tmpY, savedOffset.y);//По осі Х
        //offset = new Vector2(tmpX, tmpY);
        offset = new Vector2(playerTarget.transform.position.x*Time.deltaTime, playerTarget.transform.position.y * Time.deltaTime);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
    private void FixedUpdate()//Знаю що трєбоватєльна, но якщо не добавлю буде розрив кадрів
    {
        if (firstBackGround) Move(firstBackGround, savedFirst,  firstBGBasicSpeed*Time.deltaTime);
        if (secondBackGround) Move(secondBackGround, savedSecond, secondBGBasicSpeed* Time.deltaTime);
        if (thirdBackGround) Move(thirdBackGround, savedThird, thirdBGBasicSpeed* Time.deltaTime);
    }
    void OnDisable()
    {
        if (firstBackGround) firstBackGround.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
        if (secondBackGround) secondBackGround.sharedMaterial.SetTextureOffset("_MainTex", savedSecond);
        if (thirdBackGround) thirdBackGround.sharedMaterial.SetTextureOffset("_MainTex", savedThird);
    }
}
