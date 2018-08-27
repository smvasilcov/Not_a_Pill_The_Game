using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.IO;

public class ResultsOfCalibrationWaiter : MonoBehaviour {

    public GameObject PythonRecieve;
    public GameObject Objects;
    public GameObject GameController;
    public GameObject CalibrationPlusCSV;
    public GameObject WelcomeMenu;
    public GameObject CalibrationMenu;
    public Text AccuracyText;

    // Use this for initialization
    void Start () {
        CalibrationPlusCSV.SetActive(false);

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "C:\\Users\\Sergey\\Documents\\MuseCSV\\log_regression.py";
        startInfo.Arguments = "py -3";
        Process.Start(startInfo);
    }
	
	// Update is called once per frame
	void Update () {
        if (PythonRecieve.GetComponent<PythonRecieve>().accuracy_ > 0)
        {
            AccuracyText.text = ("Acc: " + Convert.ToString(PythonRecieve.GetComponent<PythonRecieve>().accuracy_));
            WelcomeMenu.SetActive(false);
            CalibrationMenu.SetActive(false);
            GameController.SetActive(true);
            Objects.SetActive(true);
        }
	}
}
