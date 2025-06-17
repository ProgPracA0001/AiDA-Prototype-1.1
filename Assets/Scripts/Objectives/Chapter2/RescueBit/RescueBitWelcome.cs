using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueBitWelcome : MonoBehaviour
{
    public GameObject pageOne;
    public GameObject pageTwo;
    // Start is called before the first frame update
    void Start()
    {
        pageOne.SetActive(true);
        pageTwo.SetActive(false);
    }

    // Update is called once per frame
    public void Next()
    {
        pageOne.SetActive(false);
        pageTwo.SetActive(true);

    }

    public void Back()
    {
        pageTwo.SetActive(false);
        pageOne.SetActive(true);
        
    }
}
