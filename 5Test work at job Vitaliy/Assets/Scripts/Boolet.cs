using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
{
    public GameObject boolet;

        private void OnCollisionEnter(Collision collision)
        {
        GameObject[] copyShootObject;
        copyShootObject = GameObject.FindGameObjectsWithTag("ShootObject");

        if (collision.gameObject.transform.tag == "ShootObject")
            {
            
            for(int i=0;i< copyShootObject.Length;i++)
            {
                float dist = Vector3.Distance(copyShootObject[i].transform.position, collision.transform.position);//п
                //print("1:"+ copyShootObject[i].transform.position + "2:"+ collision.transform.position + "Dist"+ dist);
                if (dist <= 10f)//якщо дистанція між вистреленим обєктом і оточуючими обєктами менше 10
                {
                    collision.gameObject.GetComponent<Renderer>().material.color = Color.green;//заразити обєкти
                }
                }
                
            }
        if (collision.gameObject.name == "Boolet(Clone)")
        {
            Destroy(collision.gameObject,3f);
        }
        if (collision.collider.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                Destroy(collision.gameObject, 2f);//знижує обєкти трігера при дотику, для економії ресурсів пк
            }
        }
    
}
