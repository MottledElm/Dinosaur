using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerBehaviour : MonoBehaviour
{
    public string Message1;
    public string Message2;
    public string Message3;
    public string Message4;
    public string Message5;
    public string Message6;
    public string Message7;
    public string Message8;
    public string Message9;
    public string Message10;
    public string Message11;
    public string Message12;
    public string Message13;
    public string Message14;
    public string Message15;
    public string Message16;
    public string Message17;
    public string Message18;
    public string Message19;
    public Color[] LineColors;
    public AudioSource[] Voices;

    public TextMeshProUGUI TextDisplayer;

    public bool IsTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag("Player") && IsTriggered == false)
        {
            IsTriggered = true;
            TextDisplayer.GetComponent<TextDisplay>().TextColor = LineColors;
            TextDisplayer.GetComponent<TextDisplay>().TextVoice = Voices;
            TextDisplayer.GetComponent<TextDisplay>().lines[0] = Message1;
            TextDisplayer.GetComponent<TextDisplay>().lines[1] = Message2;
            TextDisplayer.GetComponent<TextDisplay>().lines[2] = Message3;
            TextDisplayer.GetComponent<TextDisplay>().lines[3] = Message4;
            TextDisplayer.GetComponent<TextDisplay>().lines[4] = Message5;
            TextDisplayer.GetComponent<TextDisplay>().lines[5] = Message6;
            TextDisplayer.GetComponent<TextDisplay>().lines[6] = Message7;
            TextDisplayer.GetComponent<TextDisplay>().lines[7] = Message8;
            TextDisplayer.GetComponent<TextDisplay>().lines[8] = Message9;
            TextDisplayer.GetComponent<TextDisplay>().lines[9] = Message10;
            TextDisplayer.GetComponent<TextDisplay>().lines[10] = Message11;
            TextDisplayer.GetComponent<TextDisplay>().lines[11] = Message12;
            TextDisplayer.GetComponent<TextDisplay>().lines[12] = Message13;
            TextDisplayer.GetComponent<TextDisplay>().lines[13] = Message14;
            TextDisplayer.GetComponent<TextDisplay>().lines[14] = Message15;
            TextDisplayer.GetComponent<TextDisplay>().lines[15] = Message16;
            TextDisplayer.GetComponent<TextDisplay>().lines[16] = Message17;
            TextDisplayer.GetComponent<TextDisplay>().lines[17] = Message18;
            TextDisplayer.GetComponent<TextDisplay>().lines[18] = Message19;
            TextDisplayer.GetComponent<TextDisplay>().StartDialogue();
        }
    }
}
