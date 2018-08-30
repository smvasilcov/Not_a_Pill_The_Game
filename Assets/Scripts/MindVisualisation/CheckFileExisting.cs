using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class CheckFileExisting : MonoBehaviour {

    public bool CheckExisting()
    {
        string fileName = gameObject.GetComponent<Dropdown>().options[gameObject.GetComponent<Dropdown>().value].text.ToString();

        return File.Exists("C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileName + ".csv");
    }
}
