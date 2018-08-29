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


public class CompareStates : MonoBehaviour {

    public Dropdown StateToRecordDropdown;
    public GameObject ResultsOfCalibrationWaiter;

    StringBuilder csvcontent = new StringBuilder();
    string csvpath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\musedata1.csv";

    public void Compare()
    {
        csvcontent = new StringBuilder();
        csvcontent.AppendLine("a_r_TP9;a_r_Fp1;a_r_Fp2;a_r_TP10;b_r_TP9;b_r_Fp1;b_r_Fp2;b_r_TP10;g_r_TP9;g_r_Fp1;g_r_Fp2;g_r_TP10;state");

        string fileName = StateToRecordDropdown.options[StateToRecordDropdown.GetComponent<Dropdown>().value].text.ToString();  // сравнивается файл из выпадающего списка с базовым состоянием

        using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileName + ".csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                csvcontent.AppendLine(line);
            }
        }

        using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\CalmBaseState.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                csvcontent.AppendLine(line);
            }
        }

        File.WriteAllText(csvpath, csvcontent.ToString());
        ResultsOfCalibrationWaiter.SetActive(true);
    }
}
