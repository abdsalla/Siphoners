using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
    public GameObject journalImage;

    void Start()
    {
        journalImage.SetActive(false);
        journalImage.transform.Find("Journal").gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && journalImage.activeSelf == false)
        {
            journalImage.SetActive(true);
            journalImage.transform.Find("Journal").gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.J) && journalImage.activeSelf == true)
        {
            journalImage.SetActive(false);
            journalImage.transform.Find("Journal").gameObject.SetActive(false);
        }
    }
}
