using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMenuActivation : MonoBehaviour
{
    bool start = false;
    public GameObject gameObj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void testReveal()
    {
        if (start)
        {
            gameObj.SetActive(false);
            start = !start;
        }
        else if (!start)
        {
            gameObj.SetActive(true);
            start = !start;
        }
    }
}
