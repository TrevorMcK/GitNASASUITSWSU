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
    public GameObject WarningOxygen;
    public GameObject WarningPower;
    public float oxygenwartime = 0;
    public float powerwartime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeOxygenInterval && oxygen>=0+1)
        {
            oxygen--;
            OxygenTxt.GetComponent<TextMeshProUGUI>().SetText("Oxygen: " + oxygen +"%");
            nextTimeOxygenInterval += Oxygen_Interval;
        }
        if(Time.time >= nextTimePowerLevel && power>=0)
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
        if (oxygen < 25)
        {
            WarningOxygen.SetActive(true);
            oxygenwartime = Time.time;
        }
        else if (Time.time>=oxygenwartime +5)
        {
            WarningOxygen.SetActive(false);
        }
        else WarningOxygen.SetActive(false);
        if (power < 25)
        {
            WarningPower.SetActive(true);
            powerwartime = Time.time;
        }
        else if(Time.time>=powerwartime + 5){
            WarningPower.SetActive(false);
        }
        else WarningPower.SetActive(false);
        if(oxygen < 10)
        {
            WarningOxygen.SetActive(true);
            WarningOxygen.GetComponent<TextMeshProUGUI>().SetText("Warning Oxygen levels critical!!!! Return to base");
            oxygenwartime = Time.time;
        }
        if(power< 10)
        {
            WarningPower.SetActive(true);
            WarningPower.GetComponent<TextMeshProUGUI>().SetText("Warning Power levels critical!!!! Return to base");
            powerwartime = Time.time;
        }
    }
    
}
