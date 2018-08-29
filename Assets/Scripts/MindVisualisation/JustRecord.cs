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

public class JustRecord : MonoBehaviour {

    public GameObject MuseRecieve;

    public Dropdown StateToRecordDropdown;
    public Dropdown CompleteRewriteDropdown;
    public Button RecordButton;
    public Button StopButton;
    public Text MaxRecTimeText;
    public Text RecTimeText;
    public Text StatusText;

    public GameObject TopPanel;
    public Text TopUIText;

    //private int stateToRecID;
    private string stateToRecText;
    private bool recordState = false;

    float timeToConcentrate = 15;
    int ConcentrateState = 1;
    

    StringBuilder csvGoal = new StringBuilder();
    string csvGoalPath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\csvGoalPath.csv";

    // Use this for initialization
    public void StartRecord ()
    {
        timeToConcentrate = float.Parse(MaxRecTimeText.text);
        stateToRecText = StateToRecordDropdown.options[StateToRecordDropdown.GetComponent<Dropdown>().value].text.ToString();
        ConcentrateState = 1;
        if (stateToRecText == "CalmBaseState") ConcentrateState = 0;

        UnityEngine.Debug.Log("State text = " + stateToRecText);

        csvGoalPath = ("C:\\Users\\Sergey\\Documents\\MuseCSV\\" + stateToRecText + ".csv");
        TopUIText.text = ("Do " + stateToRecText.ToString());  // Дублирвание статуса на верхней панели
        recordState = true;
        StatusText.text = ("Recording of " + stateToRecText.ToString() + " started");
        TopPanel.SetActive(true);
        RecordButton.GetComponent<Image>().color = Color.red;

        switch (CompleteRewriteDropdown.GetComponent<Dropdown>().value)
        {
            case 0:     // Дополнить предыдущие CSV без перезаписи
                UnityEngine.Debug.Log("Clomplete old CSV mode");
                return;
            case 1:     // Обнулить предыдущие CSV
                csvGoal = new StringBuilder();
                UnityEngine.Debug.Log("Rewrite old CSV mode");
                return;
        }

        
    }

    public void StopRecord()
    {
        recordState = false;
        StatusText.text = ("Recording of " + stateToRecText.ToString() + " ended");
        TopUIText.text = ("Recording of " + stateToRecText.ToString() + " ended");     // Дублирование статуса на верхней панели
        TopPanel.SetActive(false);
        RecordButton.GetComponent<Image>().color = Color.white;
        File.WriteAllText(csvGoalPath, csvGoal.ToString());
    }

    private void Update()
    {
        if(recordState)
        {
            float[] a_r = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;
            float[] b_r = MuseRecieve.GetComponent<MuseRecieve>().beta_relative;
            float[] g_r = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;

            timeToConcentrate -= Time.deltaTime;
            RecTimeText.text = timeToConcentrate.ToString("0.0");
            if (timeToConcentrate > 0)  // Record goal state
            {
                csvGoal.AppendLine(a_r[0] + ";" + a_r[1] + ";" + a_r[2] + ";" + a_r[3] + ";" + b_r[0]
                + ";" + b_r[1] + ";" + b_r[2] + ";" + b_r[3] + ";" + g_r[0] + ";" + g_r[1] + ";" + g_r[2] + ";" + g_r[3] + ";" + ConcentrateState);
            }
            else if (timeToConcentrate <= 0)
            {
                StopRecord();
            }
        }
    }
}
