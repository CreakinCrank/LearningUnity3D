using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotator : MonoBehaviour
{
    public float spinSpeed = 10;
    Vector3 spin = new Vector3(0,1,0); // Equivalent to Vector3.up
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        // Keeping rotation speed independent of framerate:
        float angleRotation = spinSpeed * Time.deltaTime;
        transform.Rotate(angleRotation*spin, Space.World);
        
    }
}
