using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class ChooseDateTime : MonoBehaviour {

    public GameObject WriteReadCoefsController;
    public Dropdown StateDropdown;
    public Dropdown TimeListDropdown;

    private string[,] listOfStates = new string[20, 2];   // listOfStates[1] соответствует строке coefsArray[1,]
    private float[,] coefsArray = new float[20, 20];
    private int amountOfElements = 0;

    private string stateLabel;

    public void ChooseDateTimeFunction()
    {
        stateLabel = StateDropdown.GetComponent<Dropdown>().options[StateDropdown.GetComponent<Dropdown>().value].text.ToString();  // Вот это состояние нужно искать в CSV

        WriteReadCoefsController.GetComponent<WriteReadCoefs>().FindCoefs(stateLabel);
        listOfStates = WriteReadCoefsController.GetComponent<WriteReadCoefs>().GetListOfStates();
        coefsArray = WriteReadCoefsController.GetComponent<WriteReadCoefs>().GetCoefsArray();
        amountOfElements = WriteReadCoefsController.GetComponent<WriteReadCoefs>().GetAmountOfElements();

        Debug.Log("Amount of elements = " + amountOfElements.ToString());

        TimeListDropdown.ClearOptions();
        for (int counter = 0; counter < amountOfElements; counter++)
        {
            TimeListDropdown.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(listOfStates[counter, 1]));   // Запись даты и времени в Dropdown
        }
        TimeListDropdown.GetComponentInChildren<Text>().text = listOfStates[0, 1];
    }

    public float GetAccuracy()
    {
        int value_ = TimeListDropdown.GetComponent<Dropdown>().value;
        return coefsArray[value_, 12];
    }

    public float GetIntercept()
    {
        int value_ = TimeListDropdown.GetComponent<Dropdown>().value;
        return coefsArray[value_, 13];
    }

    public float[] GetCoefs()
    {
        int value_ = TimeListDropdown.GetComponent<Dropdown>().value;
        float[] chosenCoefs = new float[13];
        for (int counter = 0; counter < 12; counter++)
        {
            chosenCoefs[counter] = coefsArray[value_, counter];
        }
        return chosenCoefs;
    }

}
