using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YsignAnimation : MonoBehaviour
{
    public float alphaLevel = 1;
    private bool stop = false;
    public float increment = -0.01f;
    private int nr = 0;
    public GameObject yellow_sign;
    public GameObject Spawner;
    public GameObject Racheta;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.GetComponent<ManipulareButoane>().Start_Game == true)
        {
            if (gameObject.transform.localPosition.x < 175)
            {
                alphaLevel = alphaLevel + increment;
                if (alphaLevel <= 0)
                {
                    increment = increment * (-1);
                    nr++;
                }
                else if (alphaLevel >= 1)
                {
                    increment = increment * (-1);

                }

                if (nr >= 3)
                {
                    Spawner.GetComponent<ManipulareEntitati>().spawnCapsuna(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
                    Destroy(yellow_sign);
                }
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
            }
        }
        else if (gameObject.name.Contains("(Clone)") && Racheta.transform.position.y > 440)
        {
            Destroy(yellow_sign);
        }
    }
}
