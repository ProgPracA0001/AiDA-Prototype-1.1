using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]    

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private bool Use24HourTime = false;
    [SerializeField] private float SecondsBetweenUpdates = 10f;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (text == null )
        {
            Debug.LogException(new MissingComponentException("DigitalClock requires Text component"), this);
        }

        StartCoroutine(UpdateTimeAtInterval());
    }

    private IEnumerator UpdateTimeAtInterval()
    {
        while (true)
        {
            DateTime time = DateTime.Now;
            string hour = (Use24HourTime ? time.Hour : time.Hour % 12).ToString();
            string minute = time.Minute.ToString().PadLeft(2, '0');

            text.text = hour + ":" + minute;

            yield return new WaitForSeconds(SecondsBetweenUpdates);
        }

    }
}

