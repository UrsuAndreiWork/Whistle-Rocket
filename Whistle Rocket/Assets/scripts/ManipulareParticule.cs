using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulareParticule : MonoBehaviour
{
    public ParticleSystem particuleExplozie;
    public ParticleSystem particuleRandom;
    public int DeathParticle;
    // Start is called before the first frame update
    void Start()
    {
        DeathParticle = 0;

    }
    public void startDeathPaticle(float xRacheta,float yRacheta)
    {
        particuleExplozie.transform.position = new Vector2(xRacheta, yRacheta);
        if (DeathParticle == 0)
        { particuleExplozie.Play(); }
        if(DeathParticle == 1)
        { particuleRandom.Play(); }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
