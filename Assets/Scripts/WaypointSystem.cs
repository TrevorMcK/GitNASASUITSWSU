using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    float nextTime = 0;
    public int interval = 1;
    public GameObject waypoint;
    public Vector3 spacing = new Vector3(1f, 1f, 1f);
    bool startWaypoints = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (startWaypoints)
        {
            if (Time.time >= nextTime)
            {
                Instantiate(waypoint);
                waypoint.transform.position = this.transform.position - spacing;

                nextTime += interval;
            }
        }
    }

    public void startWay()
    {
        startWaypoints = !startWaypoints;
    }
}
