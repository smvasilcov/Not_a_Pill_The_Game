using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChooseWhatToCompare : MonoBehaviour {

    public Dropdown DropdownToChoose;
    public GameObject MathCompareController;
    public Text[] textToShowIn = new Text[12];

    private float[] arrayToShow = new float[15];

    public void CooseAndShow()  // Average or Median
    {

        if (DropdownToChoose.value == 0)
        {
            Array.Clear(arrayToShow,0,arrayToShow.Length);
        }
        else if (DropdownToChoose.value == 1)
        {
            arrayToShow = MathCompareController.GetComponent<MathCompare>().GetAverageComparison();
        }
        else if (DropdownToChoose.value == 1)
        {
            arrayToShow = MathCompareController.GetComponent<MathCompare>().GetMedianComparison();
        }

        for(int counter = 0; counter < textToShowIn.Length; counter++)
        {
            textToShowIn[counter].text = arrayToShow[counter].ToString("0.00000");
        }

    }


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
