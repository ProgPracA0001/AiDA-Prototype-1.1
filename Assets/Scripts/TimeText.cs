using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{

    [SerializeField] private bool Using24HourTime = false;
    [SerializeField] private float secondsBetweenUpdates = 10f;

    private Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
        StartCoroutine(UpdateTimeAtInterval());
        
    }

    // Update is called once per frame
    private IEnumerator UpdateTimeAtInterval()
    {
        DateTime time = DateTime.Now;
        string hour = (Using24HourTime ? time.Hour : time.Hour % 12).ToString();
        string minute = time.Minute.ToString().PadLeft(2, '0');

        Text.text = hour + ":" + minute;

        yield return new WaitForSeconds(secondsBetweenUpdates);
    }
}
