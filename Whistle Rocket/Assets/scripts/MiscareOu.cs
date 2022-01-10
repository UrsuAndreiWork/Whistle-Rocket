using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscareOu : MonoBehaviour
{
    public float inc = 3f;
    public GameObject Out; 
    public GameObject Banut;
    public GameObject spawner;
    public GameObject Racheta;
    private ManipulareEntitati getScor;
    // Start is called before the first frame update
    void Start()
    {
       getScor = spawner.GetComponent<ManipulareEntitati>();

    }

    // Update is called once per frame
    void Update()
    {
       if(Racheta.GetComponent<SageaMove>().death==true && gameObject.name.Contains("(Clone)"))
        {
            Destroy(Out);
        }
        if (gameObject.name.Contains("(Clone)") && spawner.GetComponent<ManipulareButoane>().Start_Game == true)
       {
            transform.position = new Vector2(gameObject.transform.localPosition.x - inc, gameObject.transform.localPosition.y);
       }
        if(gameObject.transform.localPosition.x<=(-223))
        {

            getScor.scor++;
            Destroy(Out);
        }
    }
}
