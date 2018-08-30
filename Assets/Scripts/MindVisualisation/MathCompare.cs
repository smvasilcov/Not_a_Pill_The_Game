using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class MathCompare : MonoBehaviour {

    public Dropdown WhatCompareDropdown;
    public Dropdown WithCompareDropdown;

    public float[,] coefsWhatArray;     // Первый индекс - номер строки в CSV
    public float[,] coefsWithArray;     // Второй индекс - номер элемента в строке. Указание на a_r0 или b_r2 и т.д.
                                        // Так как списки могут быть разного размера нужно сначала искать среднее, а потом сравнивать
    private float[] averageWhatArray;
    private float[] averageWithArray;

    private float[] sortedStolbecArray;

    private int amountOfStreams = 0;

                            // При изменении значений в Dropdown вызывать функцию MathCompareFunction и функцию перерисовки результатов на MathCompareCanvasController
    public void MathCompareFunction()    
    {
        string fileNameWhat = WhatCompareDropdown.options[WhatCompareDropdown.GetComponent<Dropdown>().value].text.ToString();  // сравнивается файл из выпадающего списка с базовым состоянием
        string fileNameWith = WithCompareDropdown.options[WithCompareDropdown.GetComponent<Dropdown>().value].text.ToString();

        if (WhatCompareDropdown.GetComponent<CheckFileExisting>().CheckExisting() && WithCompareDropdown.GetComponent<CheckFileExisting>().CheckExisting())    // Если выбранные элементы существуют
        {

            using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileNameWhat + ".csv"))
            {
                amountOfStreams = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    amountOfStreams++;
                }
            }
            coefsWhatArray = new float[amountOfStreams, 20];

            using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileNameWhat + ".csv"))
            {
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    for (int counter2 = 0; counter2 < values.Length; counter2++)        // запись строки из CSV в строку coefsWhatArray[counter,]
                    {
                        coefsWhatArray[counter, counter2] = float.Parse(values[counter2]);
                    }
                    counter++;
                }
            }

            // То же самое, только для второго файла

            using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileNameWith + ".csv"))
            {
                amountOfStreams = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    amountOfStreams++;
                }
            }
            coefsWithArray = new float[amountOfStreams, 20];

            using (var reader = new StreamReader(@"C:\\Users\\Sergey\\Documents\\MuseCSV\\" + fileNameWith + ".csv"))
            {
                int counter = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    for (int counter2 = 0; counter2 < values.Length; counter2++)        // запись строки из CSV в строку coefsWhatArray[counter,]
                    {
                        coefsWithArray[counter, counter2] = float.Parse(values[counter2]);
                    }
                    counter++;
                }
            }



            
        }
    }
    
    public float[] GetAverageComparison()
    {
        averageWhatArray = new float[coefsWhatArray.GetLength(1)];
                                        //  coefsWhatArray.GetLength(0) - размерность первого индекса массива
        for(int stolbec = 0; stolbec < coefsWhatArray.GetLength(1); stolbec++)      // Переходит между столбцами (их всего 13)
        {
            for (int stroka = 0; stroka < coefsWhatArray.GetLength(0); stroka++)      // Построччно добавляет значение каждого элемента столбца в averageWhatArray
            {
                averageWhatArray[stolbec] += coefsWhatArray[stroka, stolbec];
            }
            averageWhatArray[stolbec] = averageWhatArray[stolbec] / coefsWhatArray.GetLength(0);       // Получили среднее значение
        }

        // То же самое, только с coefsWithArray

        averageWithArray = new float[coefsWithArray.GetLength(1)];

        for (int stolbec = 0; stolbec < coefsWithArray.GetLength(1); stolbec++)      // Переходит между столбцами (их всего 13)
        {
            for (int stroka = 0; stroka < coefsWithArray.GetLength(0); stroka++)      // Построччно добавляет значение каждого элемента столбца в averageWhatArray
            {
                averageWithArray[stolbec] += coefsWithArray[stroka, stolbec];
            }
            averageWithArray[stolbec] = averageWithArray[stolbec] / coefsWithArray.GetLength(0);       // Получили среднее значение
        }

        // Сравнение средних значений (от what отнимаем with)

        float[] averageCompared = new float[averageWhatArray.Length];
        for(int counter = 0; counter < averageWhatArray.Length; counter++)
        {
            averageCompared[counter] = averageWhatArray[counter] - averageWithArray[counter];
        }

        return averageCompared;
    }

    public float[] GetMedianComparison()
    {
        sortedStolbecArray = new float[coefsWhatArray.GetLength(0)];
        float[] medianWhat = new float[coefsWhatArray.GetLength(1)];
        float[] medianWith = new float[coefsWhatArray.GetLength(1)];
        float[] medianCompared = new float[coefsWhatArray.GetLength(1)];

        for(int stolbec = 0; stolbec < coefsWhatArray.GetLength(1);stolbec++)   // Переходит между столбцами (их всего 13)
        {
            for(int stroka = 0; stroka < coefsWhatArray.GetLength(0); stroka++) // Построчно добавляет значение каждого элемента столбца массив
            {
                sortedStolbecArray[stroka] = coefsWhatArray[stroka, stolbec];
            }
            Array.Sort(sortedStolbecArray);
            medianWhat[stolbec] = sortedStolbecArray[sortedStolbecArray.Length / 2];
        }
        // То же самое для with
        sortedStolbecArray = new float[coefsWithArray.GetLength(0)]; // Переопределяем рабочий массив под with
        for (int stolbec = 0; stolbec < coefsWithArray.GetLength(1); stolbec++)   // Переходит между столбцами (их всего 13)
        {
            for (int stroka = 0; stroka < coefsWithArray.GetLength(0); stroka++) // Построчно добавляет значение каждого элемента столбца массив
            {
                sortedStolbecArray[stroka] = coefsWithArray[stroka, stolbec];
            }
            Array.Sort(sortedStolbecArray);
            medianWith[stolbec] = sortedStolbecArray[sortedStolbecArray.Length / 2];
        }
        // Сравнивает медианы (от what отнимаем with)
        for (int counter = 0; counter < medianWhat.Length; counter++)
        {
            medianCompared[counter] = medianWhat[counter] - medianWith[counter];
        }
        return medianCompared;
    }

}
