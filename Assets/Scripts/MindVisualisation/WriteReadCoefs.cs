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
using System.Globalization;

public class WriteReadCoefs : MonoBehaviour {

    public Dropdown StateToRecordDropdown;

    private string[,] listOfStates = new string[200,2];   // listOfStates[1] соответствует строке coefsArray[1,]
    private float[,] coefsArray = new float[200, 20];
    private int amountOfElements = 0;
    

    StringBuilder coefsData = new StringBuilder();
    string coefsDataPath = "C:\\Users\\Sergey\\Documents\\MuseCSV\\coefsData.csv";

    public void WriteCoefs(float[] coefsArray, float accuracy, float intercept)
    {
        DateTime localDate = DateTime.Now;
        coefsData = new StringBuilder();
        string state = StateToRecordDropdown.options[StateToRecordDropdown.GetComponent<Dropdown>().value].text.ToString();
        coefsData.AppendLine(state+";"+coefsArray[0]+";"+coefsArray[1] + ";" + coefsArray[2] + ";" + coefsArray[3] + ";" + coefsArray[4] 
            + ";" + coefsArray[5] + ";" + coefsArray[6] + ";" + coefsArray[7] + ";" + coefsArray[8] + ";" + coefsArray[9] + ";" + coefsArray[10] 
            + ";" + coefsArray[11] + ";"+accuracy+";"+intercept+";"+ localDate.ToString());
        File.AppendAllText(coefsDataPath, coefsData.ToString());

        UnityEngine.Debug.Log("coefsData.csv appended");
    }

    //
    //          Вызов методов осуществляется в следующем порядке:
    //          Сначала void ReadCoefs или void FindCoefs(string)
    //          затем вызов string[,] GetListOfStates() и float[,] GetCoefsArray()
    //          чтобы получить найденные данные
    //

    public void ReadCoefs()
    {
        using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\coefsData.csv"))
        {
            int counter = 0;
            amountOfElements = 0;
            listOfStates = new string[200, 2];
            coefsArray = new float[200, 20];

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                
                listOfStates[counter,0] = values[0];
                coefsArray[counter, 0] = float.Parse(values[1]);    // coef[0]
                coefsArray[counter, 1] = float.Parse(values[2]);
                coefsArray[counter, 2] = float.Parse(values[3]);
                coefsArray[counter, 3] = float.Parse(values[4]);
                coefsArray[counter, 4] = float.Parse(values[5]);
                coefsArray[counter, 5] = float.Parse(values[6]);
                coefsArray[counter, 6] = float.Parse(values[7]);    // ...
                coefsArray[counter, 7] = float.Parse(values[8]);
                coefsArray[counter, 8] = float.Parse(values[9]);
                coefsArray[counter, 9] = float.Parse(values[10]);
                coefsArray[counter, 10] = float.Parse(values[11]);
                coefsArray[counter, 11] = float.Parse(values[12]);  // coef[11]
                coefsArray[counter, 12] = float.Parse(values[13]);  // accuracy
                coefsArray[counter, 13] = float.Parse(values[14]);  // intercept
                listOfStates[counter, 1] = values[15];  // date and time

                counter++;
            }
            amountOfElements = counter;
        }
    }

    public void FindCoefs(string stateLabel)
    {
        using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\coefsData.csv"))
        {
            int counter = 0;
            amountOfElements = 0;
            listOfStates = new string[200, 2];
            coefsArray = new float[200, 20];

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (values[0] == stateLabel)        // В массив записываются только значения совпадающие с stateLabel
                {
                    UnityEngine.Debug.Log("stateLabel in array = " + stateLabel);

                    listOfStates[counter, 0] = values[0];
                    coefsArray[counter, 0] = float.Parse(values[1]);    // coef[0]
                    coefsArray[counter, 1] = float.Parse(values[2]);
                    coefsArray[counter, 2] = float.Parse(values[3]);
                    coefsArray[counter, 3] = float.Parse(values[4]);
                    coefsArray[counter, 4] = float.Parse(values[5]);
                    coefsArray[counter, 5] = float.Parse(values[6]);
                    coefsArray[counter, 6] = float.Parse(values[7]);    // ...
                    coefsArray[counter, 7] = float.Parse(values[8]);
                    coefsArray[counter, 8] = float.Parse(values[9]);
                    coefsArray[counter, 9] = float.Parse(values[10]);
                    coefsArray[counter, 10] = float.Parse(values[11]);
                    coefsArray[counter, 11] = float.Parse(values[12]);  // coef[11]
                    coefsArray[counter, 12] = float.Parse(values[13]);  // accuracy
                    coefsArray[counter, 13] = float.Parse(values[14]);  // intercept
                    listOfStates[counter, 1] = values[15];  // date and time

                    counter++;
                }
            }
            amountOfElements = counter;
        }
    }

    public string[,] GetListOfStates()
    {
        return listOfStates;
    }

    public float[,] GetCoefsArray()
    {
        return coefsArray;
    }

    public int GetAmountOfElements()
    {
        return amountOfElements;
    }

}
