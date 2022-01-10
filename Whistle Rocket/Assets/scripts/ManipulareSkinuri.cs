using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro; 
public class ManipulareSkinuri : MonoBehaviour
{
    public Camera camera_menu;
    public Camera camera_joc;
    public Camera camera_shop;
    public GameObject leftBt;
    public GameObject rightBt;
    public TextMeshProUGUI setSkinBT;
    public GameObject rocketF;
    public GameObject rocketF1;
    public GameObject rocket;


    public List<Sprite> skins;
    private List<String>skin_state=new List<string>();
    private int contor = 0;

    public int coins;

    public void getCoins()
    {
        string path = Path.GetDirectoryName(Application.dataPath) + "\\coins.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        coins=Int32.Parse(reader.ReadToEnd());
        reader.Close();

    }
    public void updateCoins()
    {
        string path = Path.GetDirectoryName(Application.dataPath) + "\\coins.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(coins);
        writer.Close();
    }
    public void updateSkins()
    {
        string path = Path.GetDirectoryName(Application.dataPath) + "\\purchased_skins.txt";
        StreamWriter writer = new StreamWriter(path, false);
        for(int i=0;i<skin_state.Count;i++)
        {
          writer.WriteLine(skin_state[i]);
        }
       
        writer.Close();
    }
  public void leftIteration()
    {
  
        if (contor - 1 < 0)
            contor = skins.Count - 1;
        else contor--;
       
        rocketF.GetComponent<SpriteRenderer>().sprite = skins[contor];

        if (skin_state[contor].Equals("false"))
        {
            setSkinBT.text = contor * 25+"$";
        }
        else
        {
            setSkinBT.text = "Select";
        }

    }

    public void rightIteration()
    {

        if (contor+1 > skins.Count-1)
            contor = 0;
        else contor++;

        rocketF.GetComponent<SpriteRenderer>().sprite = skins[contor];
           
        if(skin_state[contor].Equals("false"))
        {
            setSkinBT.text =contor*25+"$";
        }
        else
        {
            setSkinBT.text="Select";
        }
    }

    public void setSprite()
    {

        if (skin_state[contor].Equals("false") && coins > contor * 25)
        {
            coins = coins - contor * 25;
            skin_state[contor] = "true";
            updateCoins();
            updateSkins();
            setSkinBT.text = "Select";
        }
        else if(skin_state[contor].Equals("true"))
        {
            rocket.GetComponent<SpriteRenderer>().sprite = skins[contor];
            rocketF1.GetComponent<SpriteRenderer>().sprite = skins[contor];
            camera_menu.enabled = true;
            camera_joc.enabled = false;
            camera_shop.enabled = false;
            
        }
    }
    void Start()
    {   
                
        if (!File.Exists(Path.GetDirectoryName(Application.dataPath) + "\\purchased_skins.txt"))
        {
              File.AppendAllText(Path.GetDirectoryName(Application.dataPath) + "\\purchased_skins.txt", "true\nfalse\nfalse\nfalse\n");
        }

        if (!File.Exists(Path.GetDirectoryName(Application.dataPath) + "\\coins.txt"))
        {
            File.AppendAllText(Path.GetDirectoryName(Application.dataPath) + "\\coins.txt", "1");
        }

        var lines = File.ReadLines(Path.GetDirectoryName(Application.dataPath) + "\\purchased_skins.txt");
        foreach (var line in lines)
        {

            skin_state.Add(line);
        }

        getCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
