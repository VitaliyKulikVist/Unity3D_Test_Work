using UnityEngine;


public class MoveCandy : MonoBehaviour
{
    private Vector3 movDir = Vector3.zero;
    bool MouseDowns = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        MouseDowns = true;
        
    }

    private void OnMouseUp()
    {
        MouseDowns = false;
    }

    void Update()
    {

        Vector3 Curs = Input.mousePosition;
        Curs = Camera.main.ScreenToWorldPoint(Curs);

        if (MouseDowns)
        {
            Vector3 moveven = new Vector3(Input.GetAxis("Mouse X"), 0f, Input.GetAxis("Mouse Y"));//позиції по 3 векторам ікс ігрик зет а якщо вектор 2 то просто по іксу і ігрику
            rb.AddForce(moveven*200f* Time.fixedDeltaTime);
        }
    }
}
