using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private GameObject raycastedObj;
    public int rayLength = 10;
    public LayerMask layerMaskInteract;

    public Image uiCrosshair;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
           // if (hit.collider.CompareTag("GameObject"))
            //{
                raycastedObj = hit.collider.gameObject;
                CrosshairActive();

                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("I have touched.");
                    raycastedObj.GetComponent<animationAirlock>().open();
                }
            //}
        }
        else
        {
            CrosshairNormal();
        }
    }

    void CrosshairActive()
    {
        uiCrosshair.color = Color.red;
    }
    void CrosshairNormal()
    {
        uiCrosshair.color = Color.white;
    }
}
