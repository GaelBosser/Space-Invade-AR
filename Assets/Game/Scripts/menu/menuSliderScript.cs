using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuSliderScript : MonoBehaviour
{
    public Slider slider;
    private float position = 0.5F;
    private float speed = 1;
    private float oldPos = 0;

    void Start()
    {
        GameObject obj = GameObject.Find("menuSlider");
        slider = obj.GetComponent<Slider>();
        slider.value = 0.5F;
        slider.onValueChanged.AddListener(delegate { Moove(); });
    }

    void Moove()
    {
        this.transform.Translate(new Vector3((slider.value - 0.5F - oldPos)*60 , 0, 0));
        oldPos =+ slider.value-0.5F;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
