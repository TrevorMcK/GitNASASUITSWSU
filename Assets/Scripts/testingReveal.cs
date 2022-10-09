using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingReveal : MonoBehaviour
{
    // Start is called before the first frame update
    bool start = false;
    public GameObject reveal;
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
            reveal.SetActive(false);
            start = !start;
        }
        else if (!start)
        {
            reveal.SetActive(true);
            start = !start;
        }
    }
}
