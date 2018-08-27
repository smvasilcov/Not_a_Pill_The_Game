using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Diagnostics;
using System.IO;

public class RunPython : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "C:\\Users\\Sergey\\Documents\\MuseCSV\\log_regression.py";
        startInfo.Arguments = "py -3";
        Process.Start(startInfo);
        
        //Process.Start("C:\\Users\\Sergey\\Documents\\UnityProjects\\MuseRecieveTest2\\Assets\\OSC simpl\\Scripts\\start.bat");
        UnityEngine.Debug.Log("Python has started!");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
