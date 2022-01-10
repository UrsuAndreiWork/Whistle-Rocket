using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageaMove : MonoBehaviour
{
    public GameObject frequency;
    public GameObject racheta;
    public GameObject Banut;
    private getFrequency sunet;
    public float x=0;
    public bool death = false;
    public Rigidbody2D rb;
    public float gravitatie = -16;
    public float copGrav = -16;
    public float gravitatieAcceleratie = -0.05f;
    public float jump=60;
    public ParticleSystem particle;
    public GameObject Spawner;
    public GameObject restartButton;
    public GameObject exitButton;
    // Start is called before the first frame update
    void Start()
    {
      

        Application.targetFrameRate = 75;
        sunet = frequency.GetComponent<getFrequency>();
        
    }
    public int spawnInitialX=-193;
    public int spawnInitialY = 455;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ban")
        {
            Debug.Log("o intrat aici");
            Destroy(collision.gameObject);
            Spawner.GetComponent<ManipulareEntitati>().scor = Spawner.GetComponent<ManipulareEntitati>().scor + 10;
            return;
        }
        Spawner.GetComponent<ManipulareSkinuri>().coins= Spawner.GetComponent<ManipulareSkinuri>().coins+ Spawner.GetComponent<ManipulareEntitati>().scor;
        Spawner.GetComponent<ManipulareSkinuri>().updateCoins();
        death = true;

        Spawner.GetComponent<ManipulareParticule>().startDeathPaticle(racheta.transform.localPosition.x, racheta.transform.localPosition.y);
        Debug.Log("ai pierdut");
        this.transform.position = new Vector2(spawnInitialX, spawnInitialY);
        Spawner.GetComponent<ManipulareButoane>().Start_Game = false;
        restartButton.SetActive(true);
        exitButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Spawner.GetComponent<ManipulareButoane>().Start_Game == true)
        {
            if (sunet.frequency < 0.4 && sunet.loudness > 1)
            {

                rb.velocity = new Vector2(rb.velocity.x, sunet.loudness);
                copGrav = gravitatie;
                copGrav = -16;
           //*   Debug.Log("O IA IN SUS" + sunet.loudness + " " + sunet.frequency);

            }
            else if (sunet.loudness > 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, copGrav-jump);
                copGrav = copGrav + gravitatieAcceleratie;
               //* Debug.Log("Jump down");

            }

            else
            {
                rb.velocity = new Vector2(rb.velocity.x, copGrav - sunet.loudness);

                copGrav = copGrav + gravitatieAcceleratie;
                //* Debug.Log("Gravitatie");

            }
        }
            
        
    }
}
