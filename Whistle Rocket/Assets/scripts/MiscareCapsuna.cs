using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscareCapsuna : MonoBehaviour
{
    public float inc = 2f;
    public GameObject Capsuna;
    public GameObject spawner;
    public GameObject Racheta;
    private ManipulareEntitati getScor;
    // Start is called before the first frame update
    void Start()
    {
        getScor = spawner.GetComponent<ManipulareEntitati>();
        inval=Random.Range(0.05f,0.15f );
        inaltime = Random.Range(2f, 3f);
    }

    // Update is called once per frame
    private float rnval=0;
    private float inval = 0.1f;
    private float inaltime = 2;
    void Update()
    {
        if (Racheta.GetComponent<SageaMove>().death == true && gameObject.name.Contains("(Clone)"))
        {
            Destroy(Capsuna);
        }
        if (gameObject.name.Contains("(Clone)") && spawner.GetComponent<ManipulareButoane>().Start_Game == true)
        {
            rnval = rnval + inval;
            transform.position = new Vector2(gameObject.transform.localPosition.x - inc, gameObject.transform.localPosition.y+Mathf.Sin(rnval)*inaltime);
        }
        if (gameObject.transform.localPosition.x <= (-223))
        {

            getScor.scor++;
            Destroy(Capsuna);
        }
    }
}
