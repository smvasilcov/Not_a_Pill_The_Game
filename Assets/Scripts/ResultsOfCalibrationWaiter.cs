using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using System.IO;

public class ResultsOfCalibrationWaiter : MonoBehaviour {

    public GameObject PythonRecieve;
    //public GameObject Objects;
    public GameObject GameController;
    public GameObject CalibrationPlusCSV;
    //public GameObject WelcomeMenu;
    //public GameObject CalibrationMenu;
    //public GameObject LevelCanvas;
    //public Text AccuracyText;
    public GameObject CanvasController;

    //ProcessStartInfo startInfo = new ProcessStartInfo();
    Process runPython = new Process();

    // Use this for initialization
    void OnEnable ()
    {
        CalibrationPlusCSV.SetActive(false);
        UnityEngine.Debug.Log("runPython");
        runPython = new Process();
        runPython.StartInfo.FileName = "C:\\Users\\Sergey\\Documents\\MuseCSV\\log_regression.py";
        runPython.StartInfo.Arguments = "py -3";
        runPython.Start();
            //Process.Start(startInfo);
        
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if (PythonRecieve.GetComponent<PythonRecieve>().accuracy_ > 0 && PythonRecieve.GetComponent<PythonRecieve>().accuracy_ != GameController.GetComponent<MindVisualisationGameController>().GetAccuracy()) 
        {
            UnityEngine.Debug.Log("Acc: " + Convert.ToString(PythonRecieve.GetComponent<PythonRecieve>().accuracy_));
            string local_accuracy = "Acc: " + Convert.ToString(PythonRecieve.GetComponent<PythonRecieve>().accuracy_);
            PythonRecieve.GetComponent<PythonRecieve>().accuracy_ = 0.0f;
            runPython.Kill();
            CanvasController.GetComponent<CanvasController>().StartGame(local_accuracy);
            
            /*AccuracyText.text = ("Acc: " + Convert.ToString(PythonRecieve.GetComponent<PythonRecieve>().accuracy_));
            WelcomeMenu.SetActive(false);
            CalibrationMenu.SetActive(false);
            LevelCanvas.SetActive(true);
            GameController.SetActive(true);
            Objects.SetActive(true);*/
        }
	}
}
