using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Core : MonoBehaviour
{
    public TextMeshProUGUI core;
    public bool checkcore = true;
    public List<Doituong> doituongs = new List<Doituong>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void Update()
    {
        if(checkcore == true)
        {
            core.text = ".";
        }
        
    }
    void OnTriggerStay(Collider other)
    {
        foreach (var x in doituongs)
        {
            if (other.CompareTag(x.doituong))
            {
                checkcore = false;
                core.text = ">.<";
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        foreach (var x in doituongs)
        {
            if (other.CompareTag(x.doituong))
            {
                checkcore = true;
            }
        }
    }
    public void coree()
    {
        core.text = ".";
    } 
    [Serializable]
    public class Doituong
    {
        public string doituong;
    }
}
