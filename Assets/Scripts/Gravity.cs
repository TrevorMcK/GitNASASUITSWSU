using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 newGravity = new Vector3(0,1.62f,0);
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = newGravity; 
    }

}
