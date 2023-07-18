using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform objectTransform;
    void Start()
    {
        objectTransform = GetComponent<Transform>();
    }
    void Update()
    {
        float playerRotation = 1; 
        
        if(playerRotation >= 1)
        {
            objectTransform.localScale = new Vector3(-4.855881f, 3.856391f, 1);
        }
        else
        {
            objectTransform.localScale = new Vector3(4.855881f, 3.856391f, 1);
        }
    }
}
