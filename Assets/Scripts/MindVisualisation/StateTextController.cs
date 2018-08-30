using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateTextController : MonoBehaviour {

    public GameObject Dropdown; 

    public void RefreshText()
    {
        if(Dropdown.GetComponent<CheckFileExisting>().CheckExisting())
        {
            gameObject.GetComponent<Text>().text = "CSV Exist";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "CSV not exist";
        }
    }

	
}
