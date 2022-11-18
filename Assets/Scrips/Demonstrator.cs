using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Demonstrating how to use Gauge.cs
//Press space to increase the displaying ratio
public class Demonstrator : MonoBehaviour
{
    [SerializeField] private GaugeWithExcellentArea gauge1;
    [SerializeField] private Gauge gauge2;

    [SerializeField] float initialRatio = 0f;
    private float ratio = 0f;

    [SerializeField] float excellentWidthRatio = 0.8f;
    [SerializeField] float excellentCenterRatio = 0.1f;

    [SerializeField] float fillSpeed = 0.1f;

    private void Start()
    {
        ratio = initialRatio;

        //must initialize
        gauge1.Initialize(ratio,
            excellentWidthRatio,
            excellentCenterRatio);
        gauge2.Initialize(ratio);
    }

    private void Update()
    {
        //press space and increase ratio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Increase();
        }
    }

    private void Increase()
    {
        ratio += fillSpeed;
        gauge1.SetRatio(ratio);
        gauge2.SetRatio(ratio);
    }
}
