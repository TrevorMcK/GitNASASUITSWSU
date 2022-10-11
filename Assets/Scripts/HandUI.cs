using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandUI : MonoBehaviour
{
    float nextTimeTemperature = 0;
    public GameObject TemperatureTxt;
    public int TemperatureInterval = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTimeTemperature)
        {
            TemperatureTxt.GetComponent<TextMeshProUGUI>().SetText("Temperature: " + Mathf.Round(Random.Range(-272.0f, -250.0f)) + "C");
            nextTimeTemperature += TemperatureInterval;
        }
    }
}
