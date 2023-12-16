using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDirection : MonoBehaviour
{
    public Transform Light;
    void Start()
    {
        
    }
    void Update()
    {
        Light.rotation = Quaternion.LookRotation(transform.position - Light.position);
    }
}