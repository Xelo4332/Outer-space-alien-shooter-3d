using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    //Deni
    [SerializeField] private Text _recordLabel;

    //Saves record with help int funktion
    private void Start()
    {
        int record = PlayerPrefs.GetInt("record");
        _recordLabel.text =  "Time Record: " + record.ToString() ;
    }
}
