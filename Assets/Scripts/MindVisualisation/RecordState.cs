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

public class RecordState : MonoBehaviour {

    public GameObject MuseRecieve;
    public Text UITextForStateRecording;
    public Text UITextForCalibration;   // Один и тот же скрипт используется для калибровки из меню и записи состояния из программы
    public GameObject ResultsOfCalibrationWaiter;
    public Toggle CalmRecordToggle;


    float timeToConcentrate = 15;
    float constTimeToConcentrate = 15;
    int string_num = 0;
    string ConcentrateOrRelax = "Concentrate";
    int ConcentrateState = 1;
    StringBuilder csvcontent = new StringBuilder();
    string csvpath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\musedata1.csv";
    StringBuilder csvConcentrate = new StringBuilder();
    string csvConcentratepath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\Concentrate.csv";
    StringBuilder csvRelax = new StringBuilder();
    string csvRelaxpath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\CalmBaseState.csv";

    // Use this for initialization
    void OnEnable () {
        timeToConcentrate = 15;
        constTimeToConcentrate = 15;
        string_num = 0;
        ConcentrateState = 1;
        csvcontent = new StringBuilder();  // Обнуление предыдущих записей в CSV
        //csvRelax = new StringBuilder();
        csvConcentrate = new StringBuilder();

        ConcentrateOrRelax = "Concentrate";
        csvcontent.AppendLine("a_r_TP9;a_r_Fp1;a_r_Fp2;a_r_TP10;b_r_TP9;b_r_Fp1;b_r_Fp2;b_r_TP10;g_r_TP9;g_r_Fp1;g_r_Fp2;g_r_TP10;state");
    }

    // Update is called once per frame
    void Update ()
    {
        
        float[] a_r = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;
        float[] b_r = MuseRecieve.GetComponent<MuseRecieve>().beta_relative;
        float[] g_r = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;


        UITextForStateRecording.text = ConcentrateOrRelax;
        UITextForCalibration.text = ConcentrateOrRelax;   // Один и тот же скрипт используется для калибровки из меню и записи состояния из программы


        switch (CalmRecordToggle.isOn)
        {
            case false:   // Запись двух состояний 
                timeToConcentrate -= Time.deltaTime;
                if (timeToConcentrate > 0)  // Concentrate state
                {
                    csvcontent.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);

                    csvConcentrate.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);
                }
                else if (timeToConcentrate <= 0)  //Base state
                {
                    ConcentrateOrRelax = "Relax";
                    ConcentrateState = 0;

                    csvcontent.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);

                    csvRelax.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);

                }
                if (timeToConcentrate < -constTimeToConcentrate)
                {
                    File.WriteAllText(csvpath, csvcontent.ToString());
                    File.AppendAllText(csvConcentratepath, csvConcentrate.ToString());
                    File.AppendAllText(csvRelaxpath, csvRelax.ToString());
                    ConcentrateOrRelax = "Calibration done! \nPlease run transfer file";
                    UITextForStateRecording.text = ConcentrateOrRelax;
                    UnityEngine.Debug.Log("Enabling results of calibration waiter");  // <= Delete here
                    ResultsOfCalibrationWaiter.SetActive(true);
                }
                return;
            case true:     // Запись только целевого состояния (без состояния спокойствия)
                timeToConcentrate -= Time.deltaTime;
                if (timeToConcentrate > 0)  // Concentrate state
                {
                    csvcontent.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);

                    csvConcentrate.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                    + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);
                }
                if (timeToConcentrate <= 0)
                {
                    using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\Relax.csv"))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            csvcontent.AppendLine(line);
                        }
                    }

                    File.WriteAllText(csvpath, csvcontent.ToString());
                    File.AppendAllText(csvConcentratepath, csvConcentrate.ToString());
                    ConcentrateOrRelax = "Calibration done! \nPlease run transfer file";
                    UITextForStateRecording.text = ConcentrateOrRelax;
                    UnityEngine.Debug.Log("Enabling results of calibration waiter");   // <= Delete here
                    ResultsOfCalibrationWaiter.SetActive(true);
                }
                    return;
        }


        

        /*csvcontent.AppendLine(a_r[0] + "," + a_r[1] + "," + a_r[2] + "," + a_r[3] + "," + b_r[0]
            + "," + b_r[1] + "," + b_r[2] + "," + b_r[3] + "," + g_r[0] + "," + g_r[1] + "," + g_r[2] + "," + g_r[3] + "," + ConcentrateState);
        UnityEngine.Debug.Log(csvcontent);*/


        
    }

}
