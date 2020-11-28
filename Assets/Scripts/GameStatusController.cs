using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatusController : MonoBehaviour
{

    public TextMeshProUGUI timePlayed;
    public TextMeshProUGUI deaths;
    public TextMeshProUGUI kicks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.FloorToInt(GameStatusManager.timePlayed / 60);  
        float seconds = Mathf.FloorToInt(GameStatusManager.timePlayed % 60);
        
        timePlayed.text = "Time Played: " + $"{minutes:00}:{seconds:00}";
        deaths.SetText("Deaths: " + GameStatusManager.deaths);
        kicks.SetText("Kicks: " + GameStatusManager.kicks);
    }

}
