using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    float nextTimeTemperature = 0;
    float nextTimePowerLevel = 0;
    float nextTimeOxygenInterval = 0;
    float oxygen = 100;
    float power = 100;
    public int Oxygen_Interval = 1;
    public int Power_Level_Interval = 5;
    public int TemperatureInterval = 20;
    public GameObject OxygenTxt;
    public GameObject TemperatureTxt;
    public GameObject Power_LevelTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeOxygenInterval)
        {
            oxygen--;
            OxygenTxt.GetComponent<TextMeshProUGUI>().SetText("Oxygen: " + oxygen +"%");
            nextTimeOxygenInterval += Oxygen_Interval;
        }
        if(Time.time >= nextTimePowerLevel)
        {
            power--;
            Power_LevelTxt.GetComponent<TextMeshProUGUI>().SetText("Power Level: " + power + "%");
            nextTimePowerLevel += Power_Level_Interval;
        }
        if(Time.time >= nextTimeTemperature)
        {
            TemperatureTxt.GetComponent<TextMeshProUGUI>().SetText("Temperature: " +Mathf.Round( Random.Range(-272.0f, -250.0f)) + "C");
            nextTimeTemperature += TemperatureInterval;
        }
    }
}
