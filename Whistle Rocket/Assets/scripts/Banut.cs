using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banut : MonoBehaviour
{
    public float inc = 0.5f;
    public GameObject spawner;
   public GameObject Racheta;
    public GameObject banut;
    // Start is called before the first frame update
    void Start()
    {

 
    }
    private float var = 2.5f;
    // Update is called once per frame
    void Update()
    {
        if (Racheta.GetComponent<SageaMove>().death == true && gameObject.name.Contains("(Clone)"))
        {
            Destroy(banut);
        }
        if (gameObject.name.Contains("(Clone)") && spawner.GetComponent<ManipulareButoane>().Start_Game == true)
        {
            transform.position = new Vector2(gameObject.transform.localPosition.x-inc, gameObject.transform.localPosition.y-var);
            if(gameObject.transform.localPosition.y<255)
            {
                var = var * -1;
            }
            if(gameObject.transform.localPosition.y> 425)
            {
                var = var * -1;
            }
        }
        if (gameObject.transform.localPosition.x <= (-223))
        {

            Destroy(banut);
        }  
    }
 

}   