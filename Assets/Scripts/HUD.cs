using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    float nextTime = 0;
    float oxygen = 100;
    public int interval = 1;
    public GameObject OxygenTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTime)
        {
            oxygen--;
            OxygenTxt.GetComponent<TextMeshProUGUI>().SetText("Oxygen: " + oxygen +"%");
            nextTime += interval;
        }
    }
}
