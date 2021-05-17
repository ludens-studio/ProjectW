using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BarLight : MonoBehaviour
{
    Light2D barLight;
    float timer = 0;
    void Start()
    {
        barLight = this.GetComponent<Light2D>();
    }

    void FixedUpdate()
    {
        timer+=0.02f;
        if(timer > 0.05f){
            barLight.pointLightOuterAngle = Random.Range(140f,200f);
            barLight.intensity = Random.Range(1,2);
            timer = 0f;
        }
    }
}
