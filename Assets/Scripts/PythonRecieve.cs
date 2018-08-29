using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PythonRecieve : MonoBehaviour
{

    public OscIn oscIn;
    [HideInInspector]
    public float[] coefs_;
    [HideInInspector]
    public float accuracy_, intercept_;
    private float[] float_value = new float[14];

    // Use this for initialization
    void Start()
    {
        // Ensure that we have a OscIn component.
        if (!oscIn) oscIn = gameObject.AddComponent<OscIn>();

        // Start receiving from unicast and broadcast sources on port 9000.
        oscIn.Open(9000);
    }

    void OnEnable()
    {
        oscIn.Map("/log_reg", log_reg_coefs);
        oscIn.Map("/accuracy", log_reg_accuracy);
        oscIn.Map("/intercept", log_reg_intercept);

        float_value = new float[14]; // Обнуление массива коэффициентов
    }

    void OnDisable()
    {
        oscIn.Unmap(log_reg_coefs);
        oscIn.Unmap(log_reg_accuracy);
        oscIn.Unmap(log_reg_intercept);

    }

    void log_reg_coefs(OscMessage value)
    {
        string string_value = value.ToString();

        Debug.Log(string_value);
        
        string[] array_value = string_value.Split(' ');
        //float[] float_value = new float[14];
        for (int i=0; i<12; i++)
        {
            float_value[i] = float.Parse(array_value[i+1]);

            Debug.Log("Coeff b(" + i + "): " + float_value[i]);
        }
        coefs_ = float_value;        
    }

    void log_reg_accuracy(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        accuracy_ = float.Parse(array_value[1]);         // To public array
    }

    void log_reg_intercept(OscMessage value)
    {
        string string_value = value.ToString();
        string[] array_value = string_value.Split(' ');
        intercept_ = float.Parse(array_value[1]);         // To public array
    }

    public float[] GetCoefArray()
    {
        return float_value;
    }
}
