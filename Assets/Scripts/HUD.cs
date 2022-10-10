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
    public int Power_Level_Interval = 1;
    public int TemperatureInterval = 20;
    public GameObject OxygenTxt;
    public GameObject TemperatureTxt;
    public GameObject PowerTxt;
    public GameObject WarningOxygen;
    public GameObject WarningPower;
    public GameObject WelcomeMessage;
    public float oxygenwartime = 0;
    public float powerwartime = 0;
    bool warningCalledOx1 = false;
    bool warningCalledOx2 = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showWelcomeMessage(3.0f));
        IEnumerator showWelcomeMessage(float delay)
        {
            WelcomeMessage.SetActive(true);
            yield return new WaitForSeconds(delay);
            WelcomeMessage.SetActive(false);
        }
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
            PowerTxt.GetComponent<TextMeshProUGUI>().SetText("Power Level: " + power + "%");
            nextTimePowerLevel += Power_Level_Interval;
        }
        if(Time.time >= nextTimeTemperature)
        {
            TemperatureTxt.GetComponent<TextMeshProUGUI>().SetText("Temperature: " +Mathf.Round( Random.Range(-272.0f, -250.0f)) + "C");
            nextTimeTemperature += TemperatureInterval;
        }
        if(oxygen == 75)
        {
            OxygenTxt.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }
        
        if (oxygen == 35)
        {
            StartCoroutine(showWarningOx(3.0f));
            oxygenwartime = Time.time;
            OxygenTxt.GetComponent<TextMeshProUGUI>().color = Color.red;
        }


        if (power == 75)
        {
            PowerTxt.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        }

        //else WarningOxygen.SetActive(false);
        if (power == 35)
        {
            StartCoroutine(showWarningPw(3.0f));
            powerwartime = Time.time;
            PowerTxt.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        
        //else WarningPower.SetActive(false);
        if(oxygen == 10)
        {
            StartCoroutine(showWarningOx(5.0f));
            WarningOxygen.GetComponent<TextMeshProUGUI>().SetText("Warning Oxygen levels critical!!!! Return to base");
        }
        if(power == 10)
        {
            StartCoroutine(showWarningPw(5.0f));
            WarningPower.GetComponent<TextMeshProUGUI>().SetText("Warning Power levels critical!!!! Return to base");
        }
        
        IEnumerator showWarningOx(float delay)
        {
            WarningOxygen.SetActive(true);
            yield return new WaitForSeconds(delay);
            WarningOxygen.SetActive(false);
        }
        IEnumerator showWarningPw(float delay)
        {
            WarningPower.SetActive(true);
            yield return new WaitForSeconds(delay);
            WarningPower.SetActive(false);
        }
    }
    
}
