using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System;
using System.Diagnostics;
using System.ComponentModel;

public class test_concentration : MonoBehaviour {

    public GameObject MuseRecieve;
    public Text UIText;
    public GameObject ResultsOfCalibrationWaiter;


    float timeToConcentrate = 15;
    float constTimeToConcentrate = 15;
    int string_num = 0;
    string ConcentrateOrRelax = "Concentrate";
    int ConcentrateState = 1;
    StringBuilder csvcontent = new StringBuilder();
    string csvpath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\musedata1.csv";

    // Use this for initialization
    void Start () {
        csvcontent.AppendLine("a_r_TP9;a_r_Fp1;a_r_Fp2;a_r_TP10;b_r_TP9;b_r_Fp1;b_r_Fp2;b_r_TP10;g_r_TP9;g_r_Fp1;g_r_Fp2;g_r_TP10;state");
    }

    // Update is called once per frame
    void Update () {
        
        float[] a_r = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;
        float[] b_r = MuseRecieve.GetComponent<MuseRecieve>().beta_relative;
        float[] g_r = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;
       

        UIText.text = ConcentrateOrRelax; 

        timeToConcentrate -= Time.deltaTime;
        if (timeToConcentrate < 0)
        {
            ConcentrateOrRelax = "Relax";
            ConcentrateState = 0;
        }

        csvcontent.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
            + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);
        UnityEngine.Debug.Log(csvcontent);


        if (timeToConcentrate < -constTimeToConcentrate)
        {
            File.WriteAllText(csvpath, csvcontent.ToString());
            ConcentrateOrRelax = "Calibration done! \nPlease run transfer file";
            UIText.text = ConcentrateOrRelax;
            ResultsOfCalibrationWaiter.SetActive(true);
            
            
        }
    }

}
