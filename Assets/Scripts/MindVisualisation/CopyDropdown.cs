using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyDropdown : MonoBehaviour {

    public Dropdown DropdownToCopyFrom;
    public GameObject ChooseDateTimeController;

	void Start ()
    {
        this.GetComponent<Dropdown>().ClearOptions();
        List<string> m_DropOptions = new List<string>();
        int counter = 1;

        this.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData("")); // Первая пустая строка

        this.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(DropdownToCopyFrom.options[0].text.ToString()));
        while (DropdownToCopyFrom.options[counter-1].text.ToString() != DropdownToCopyFrom.options[counter].text.ToString()) 
        {
            //m_DropOptions.Add(DropdownToCopyFrom.options[counter].text.ToString());
            this.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData(DropdownToCopyFrom.options[counter].text.ToString()));
            Debug.Log("Dropdown option = " + DropdownToCopyFrom.options[counter].text.ToString());

            counter++;
        }

    }
}
