using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationAirlock : MonoBehaviour
{
    public Animator amiPlay;

    // Start is called before the first frame update

    public void open()
    {
        amiPlay.SetTrigger("Open Airlock");
    }
}
