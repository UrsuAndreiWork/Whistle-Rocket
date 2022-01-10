using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManipulareButoane : MonoBehaviour
{
    public Camera camera_menu;
    public Camera camera_joc;
    public Camera camera_shop;
    public bool Start_Game = false;
    public GameObject Racheta;
    public Rigidbody2D CorpRacheta;
    public GameObject restartButton;
    public GameObject exitButton;
    public GameObject shopButton;
    public float pozSpawnRachetaX=-191;
    public float pozSpawnRachetaY=337;
    public GameObject Spawner;
    public TextMeshProUGUI schimbareScrisStartGame;

    // Start is called before the first frame update
    void Start()
    {
        camera_menu.enabled = true;
        camera_joc.enabled = false;
        camera_shop.enabled = false;


        restartButton.SetActive(false);
        exitButton.SetActive(false);
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed,75);
    }

    // Update is called once per frame
  public void ChangeCamera()
    { 
        helpmegod = 0;

        if (lastRocketPositionY > 440)
        { 
            Racheta.transform.position = new Vector2(pozSpawnRachetaX, pozSpawnRachetaY); 
        }
        else { 
            Racheta.transform.position = new Vector2(pozSpawnRachetaX, lastRocketPositionY);
            
        }
        CorpRacheta.velocity = Vector2.zero;
        Racheta.GetComponent<SageaMove>().copGrav = -16;
        Start_Game = true;
        camera_menu.enabled = false;
        camera_joc.enabled = true;
        camera_shop.enabled = false; 
    }
    //*disable la buton ca sa mergi in shop
    public void ChangeCameraShop()
    {
        camera_menu.enabled = false;
        camera_joc.enabled = false;
        camera_shop.enabled = true;

    }

    public void ChangeBackMenu()
    {
        helpmegod = 0;
        lastRocketPositionY =455;
        Racheta.transform.position = new Vector2(pozSpawnRachetaX,455);
        CorpRacheta.velocity = Vector2.zero;
        Racheta.GetComponent<SageaMove>().copGrav = -16;
        Spawner.GetComponent<ManipulareEntitati>().scor = 0;
        restartButton.SetActive(false);
        exitButton.SetActive(false);

        schimbareScrisStartGame.text = "START GAME";
        Start_Game = false;
        camera_menu.enabled = true;
        camera_joc.enabled = false;
        camera_shop.enabled = false;
    }

    public void doExitGame()
    {
        Spawner.GetComponent<ManipulareSkinuri>().updateCoins();
        Application.Quit();
    }
    public void restartGame()
    {

        Racheta.transform.position = new Vector2(pozSpawnRachetaX, pozSpawnRachetaY);
        Racheta.GetComponent<SageaMove>().death = false;
        CorpRacheta.velocity = Vector2.zero;
        Racheta.GetComponent<SageaMove>().copGrav = -16;
        Start_Game = true;
        Spawner.GetComponent<ManipulareEntitati>().scor = 0;
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        lastRocketPositionY = 455;
    }

    public float lastRocketPositionY = 337;
    int helpmegod = 0; //* e bug si intra de 2 ori in if-ul de la escape si o trebuit sa il fortez sa se opreasca
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && restartButton.activeSelf==false )
        {
            if (helpmegod == 0)
            { lastRocketPositionY = Racheta.transform.position.y;
                helpmegod = 1;
            }
            Racheta.transform.position = new Vector2(Racheta.transform.position.x, 455);
            Start_Game = false;
            camera_menu.enabled = true;
            camera_joc.enabled = false;
            camera_shop.enabled = false;
            if (lastRocketPositionY < 440)
            {
                schimbareScrisStartGame.text="CONTINUE";
            }
            else { schimbareScrisStartGame.text = "START GAME"; }

        }
    }
}
