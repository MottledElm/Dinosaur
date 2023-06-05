using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolutionMeter : MonoBehaviour { 

    public GameObject smallSmoke;
    public GameObject mediumSmoke;
    public GameObject bigSmoke;
    public GameObject[] SmokeStates = new GameObject[2];
    int index;

    void Start()
    {
        index = 2;
        SmokeStates[0] = smallSmoke;
        SmokeStates[1] = mediumSmoke;
        SmokeStates[2] = bigSmoke;

}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            if (index == 0)
            {
                Debug.Log("Can't go lower"); }
            else { index -= 1; Debug.Log("Minus"); };
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            if (index == 2)
            {
                Debug.Log("Can't go higher"); }
            else { index += 1; Debug.Log("Plus"); };
        }
        if (index == 0)
        {
            SmokeStates[0].SetActive(true);
            SmokeStates[1].SetActive(false);
            SmokeStates[2].SetActive(false);
        }

        if (index == 1)
        {
            SmokeStates[0].SetActive(false);
            SmokeStates[1].SetActive(true);
            SmokeStates[2].SetActive(false);
        }

        if (index == 2)
        {
            SmokeStates[0].SetActive(false);
            SmokeStates[1].SetActive(false);
            SmokeStates[2].SetActive(true);
        }
    }
  }