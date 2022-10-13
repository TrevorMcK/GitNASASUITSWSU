using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrigin : MonoBehaviour
{
    public float x = 6;
    public float y = 1;
    public float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(6, 1, 0);
    }

}
