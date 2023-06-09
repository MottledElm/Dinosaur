using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour, IInteractable
{
    public string InteractionMessage1;
    public string InteractionMessage2;
    public string InteractionMessage3;
    public string InteractionMessage4;
    public string InteractionMessage5;
    public string InteractionMessage6;
    public string InteractionMessage7;
    public string InteractionMessage8;
    public string InteractionMessage9;
    public string InteractionMessage10;
    public string InteractionMessage11;
    public string InteractionMessage12;
    public string InteractionMessage13;
    public string InteractionMessage14;
    public string InteractionMessage15;
    public string InteractionMessage16;
    public string InteractionMessage17;
    public string InteractionMessage18;
    public string InteractionMessage19;
    public Color[] LineColors;
    public AudioSource[] Voices;


    public bool Interacted = false;

    public TextMeshProUGUI TextDisplayer;
    public Image InteractPrompt;
    private int PlayersAround;

    public ParticleSystem ScanEffect;
    public int ScanDuration = 1000;
    public int CurrentScanDuration;
    public float CurrentScanDelay;
    public Material ScanMaterial;
    public Material OriginalMaterial;
    public bool IsScan = false;
    public void Interact()
    {
        if (Interacted == false)
        {
            Interacted = true;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().TextColor = LineColors;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().TextVoice = Voices;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[0] = InteractionMessage1;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[1] = InteractionMessage2;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[2] = InteractionMessage3;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[3] = InteractionMessage4;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[4] = InteractionMessage5;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[5] = InteractionMessage6;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[6] = InteractionMessage7;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[7] = InteractionMessage8;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[8] = InteractionMessage9;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[9] = InteractionMessage10;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[10] = InteractionMessage11;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[11] = InteractionMessage12;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[12] = InteractionMessage13;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[13] = InteractionMessage14;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[14] = InteractionMessage15;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[15] = InteractionMessage16;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[16] = InteractionMessage17;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[17] = InteractionMessage18;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().lines[18] = InteractionMessage19;
            TextDisplayer.gameObject.GetComponent<TextDisplay>().StartDialogue();
            this.gameObject.tag = "Untagged";
        }
    }

    public void GetScanned()
    {
        CurrentScanDelay = GameObject.Find("Player").GetComponent<PlayerBehaviour>().ScanDelay * 10;
        IsScan = true;
        
    }
    public void Update()
    {
        
        if (CurrentScanDuration == 0)
            {
                ScanEffect.Stop();
                this.GetComponent<Renderer>().material = OriginalMaterial;
                
            }
           else CurrentScanDuration -= 1;

        if (CurrentScanDelay <= 0 && IsScan)
        {
            ScanEffect.Play();
            this.GetComponent<Renderer>().material = ScanMaterial;
            CurrentScanDuration = ScanDuration;
            IsScan = false;
        }
        else CurrentScanDelay -= 1;


        }
        
    }
    

