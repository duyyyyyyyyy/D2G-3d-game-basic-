using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private GameObject currentItem;
    public GameObject intText;
    private GameObject flash;
    public TextMeshProUGUI itemcount;
    private int _itemCount;

    void Start()
    {
        _itemCount = 0;
        itemcount.text = $"X{_itemCount}";
    }

    void Update()
    {
        Get();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Brain"))
        {
            currentItem = other.gameObject;
            intText.SetActive(true);
        }
        if (other.gameObject.CompareTag("Flashlight"))
        {
            flash = other.gameObject;
            intText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Brain"))
        {
            intText.SetActive(true);
            currentItem = null;
        }
        if (other.gameObject.CompareTag("Flashlight"))
        {
            intText.SetActive(true);
            flash = null;
        }
    }

    private void Get()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(currentItem);
            _itemCount++;
            itemcount.text = $"X{_itemCount}";
            intText.SetActive(false);
            currentItem = null;
            gameObject.GetComponent<Core>().coree();
        }
        if(flash != null && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(flash);
            intText.SetActive(false);
            flash = null;
            gameObject.GetComponent<Core>().coree();
        }
    }
}
