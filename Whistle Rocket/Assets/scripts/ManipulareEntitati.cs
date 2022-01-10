using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulareEntitati : MonoBehaviour
{
    public int x1 = 134, y1 = 417, x2 = 134, y2 = 244;
    public GameObject Sign;
    public GameObject Banut;
    public GameObject yellow_sign;
    public GameObject capsuna;
    public GameObject Ou;
    public GameObject Spawner;
    public GameObject Inamic_laser;
    public GameObject Racheta;
    public ParticleSystem LoadingGun;
    private int xOu, yOu;
    public int scor = 0;


    private int ok = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void spawnSIGN()
    {

        GameObject Semn = Instantiate(Sign) as GameObject;
        xOu = Random.Range(x1, x2);
        yOu = Random.Range(y1, y2);
        Semn.transform.position = new Vector2(xOu, yOu);


    }

    public void spawnYellowSIGN()
    {

        GameObject SemnY = Instantiate(yellow_sign) as GameObject;
        xOu = Random.Range(x1, x2);
        yOu = Random.Range(y1, y2);
        SemnY.transform.position = new Vector2(xOu, yOu);


    }

    private MiscareArmaLaser I_l;
    public void startLaserAttack()
    {
        LoadingGun.Play();
        Inamic_laser.transform.position = new Vector2(184, Racheta.transform.position.y);
        I_l = Inamic_laser.GetComponent<MiscareArmaLaser>();
        I_l.startAttack = true;
    }
    public void spawnOU(float xSemn, float ySemn)
    {
        GameObject egg = Instantiate(Ou) as GameObject;
        egg.transform.position = new Vector2(xSemn + 40, ySemn);


    }
    public void spawnCapsuna(float xSemn, float ySemn)
    {
        GameObject cap = Instantiate(capsuna) as GameObject;
        cap.transform.position = new Vector2(xSemn + 40, ySemn);


    }
    private float yban1=250, yban2=306;
    public void spawnBanut()
    {
       float rndpoz= Random.Range(yban1, yban2);
        GameObject ban = Instantiate(Banut) as GameObject;
        ban.transform.position = new Vector2(219, rndpoz);


    }


    // Update is called once per frame

    //* sign
    private float timer;
    private float respawnTime = 5;
    public float intervalRespawnSignMin = 5, intervalRespawnSignMax = 9;
    private float crestereDif = 0;



    //* yellow sign
    private float timerY = 0;
    private float respawnTimeY = 9;
    private float intervalRespawnSignYMin = 8, intervalRespawnSignYMax = 12;
    private float crestereDifY = 0;


    //* laser
    private float timerL = 0;
    private float respawnTimeL = 15;
    private float intervalRespawnLMin = 12, intervalRespawnLMax = 20;
    private float crestereDifL = 0;

    //* banut
    private float timerB = 5;
    private float intervalRespawnBMin = 10, intervalRespawnBMax = 11;
    private float respawnTimeB;
    void Update()
    {
        if (Spawner.GetComponent<ManipulareButoane>().Start_Game == true)
        {
            //*banut
            timerB = timerB + Time.deltaTime;
            if ((int)timerB > respawnTimeB)
            {
                spawnBanut();
                respawnTimeB = Random.Range(intervalRespawnBMin, intervalRespawnBMax);
                timerB = 0;
            }



            //*YELLOW SIGN
            timerY = timerY + Time.deltaTime;
            if ((int)timerY > respawnTimeY)
            {
                spawnYellowSIGN();
                respawnTimeY = Random.Range(intervalRespawnSignYMin - crestereDifY, intervalRespawnSignYMax - crestereDifY);
                if (crestereDif <= 5)
                {
                    crestereDifY = crestereDifY + 0.2f;
                }
                timerY = 0;
            }

            //* SIGN
            timer = timer + Time.deltaTime;
            if ((int)timer > respawnTime)
            {
                spawnSIGN();
                timer = 0;
                respawnTime = Random.Range(intervalRespawnSignMin - crestereDif, intervalRespawnSignMax - crestereDif);
                if (crestereDif <= 5)
                {
                    crestereDif = crestereDif + 0.2f;
                }
            }


            //* LASER
            timerL = timerL + Time.deltaTime;
            if ((int)timerL > respawnTimeL)
            {
                startLaserAttack();
                timerL = 0;
                respawnTimeL = Random.Range(intervalRespawnLMin - crestereDifL, intervalRespawnLMax - crestereDifL);
                if (crestereDifL <= 5)
                {
                    crestereDifL = crestereDifL + 0.2f;
                }
            }


            /*
              if (scor%5==0 && ok==0 && scor !=0)
              {

                  startLaserAttack();
                  ok = 1;
              }
              else if(scor%5!=0 && scor!= 0)
              {
                  ok = 0;
              }
          }
          else if(Racheta.transform.position.y>440 && Spawner.GetComponent<ManipulareButoane>().Start_Game == false)
          {
              crestereDif = 0;
          }
            */


        }
    }
}
