using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI textMeshProCoins;
    public GameObject spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
;
        textMeshPro.SetText("Score: " + spawner.GetComponent<ManipulareEntitati>().scor);
        textMeshProCoins.SetText("Coins: " + spawner.GetComponent<ManipulareSkinuri>().coins);
    }
}
