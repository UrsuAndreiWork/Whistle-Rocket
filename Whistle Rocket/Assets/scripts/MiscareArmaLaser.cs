using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscareArmaLaser : MonoBehaviour
{

    public GameObject Spawner;
    public GameObject Laser;
    public GameObject Inamic_laser;
    public GameObject Racheta;
    public ParticleSystem LoadingGun;
    public GameObject restartButton;
    public float timer=0;
    public float attackTimer = 3;
    public bool startAttack=false;
    // Start is called before the first frame update
    void Start()
    {
        Laser.SetActive(false);
    }


    private float i=0;
    private float j = 0;
    private bool pozitieInitiala = false;
    private float pozActuala;
    private bool timePassedLoading=false;
    // Update is called once per frame
    void Update()
    {
        {
            if (Spawner.GetComponent<ManipulareButoane>().Start_Game == true)
            {
                if (startAttack == true)
                {
                    LoadingGun.transform.position = new Vector2(Inamic_laser.transform.position.x - 50, Inamic_laser.transform.position.y);
                    Inamic_laser.transform.position = new Vector2(184 - i, Inamic_laser.transform.position.y);
                    i = i + 0.5f;

                }
                if (i >= 48 && timePassedLoading == false)
                {
                    startAttack = false;
                    timer = timer + Time.deltaTime;
                    if ((int)timer > 2.5)
                    {
                        timer = 0;
                        timePassedLoading = true;
                    }
                }
                if (i >= 48 && timePassedLoading == true)
                {
                    Laser.SetActive(true);


                    timer = timer + Time.deltaTime;
                    if ((int)timer > attackTimer)
                    {
                        Laser.SetActive(false);
                        timer = 0;
                        i = 0;
                        pozitieInitiala = true;
                        pozActuala = Inamic_laser.transform.position.x;
                    }

                }
                if (pozitieInitiala == true)
                {
                    LoadingGun.Stop();
                    Inamic_laser.transform.position = new Vector2(pozActuala + j, Inamic_laser.transform.position.y);
                    j = j + 0.5f;
                    if (j >= 48)
                    {
                        j = 0;
                        pozitieInitiala = false;
                        timePassedLoading = false;
                    }
                }
            }
            else if(restartButton.activeSelf==true) {

              Inamic_laser.transform.position = new Vector2(Inamic_laser.transform.position.x, 218);
              LoadingGun.Stop();
            }
        }
    }
}
