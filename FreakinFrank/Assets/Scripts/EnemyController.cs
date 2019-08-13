using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed=0.02f;
    public float height = 30;
    public float downSpeedMutiplier = 1.2f;
    //bool isMultiplied = false;
    Vector3 initPos;
    Vector3 direction = new Vector3(0,1,0);
    float adjustedSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        adjustedSpeed=speed;             
    }

    // Update is called once per frame
    void Update()
    {
        //print(adjustedSpeed);
        float upSpeed=speed;
        float downSpeed = speed*-downSpeedMutiplier;
        float jumpHeight = height + initPos.y;
        float tc = (adjustedSpeed*Time.deltaTime);
        transform.position += tc*direction;
        if (transform.position.y >= jumpHeight && adjustedSpeed>=0){
            adjustedSpeed = downSpeed;            
            //isMultiplied = false;
            //speed*=-1;
        }
        if (transform.position.y <= initPos.y && adjustedSpeed<=0){            
            adjustedSpeed=upSpeed;
                       
        }
        //if (speed<0 && isMultiplied = 0){
        //    speed*=1.2f;
        //    isMultiplied = 1;
        //}
    }
}
