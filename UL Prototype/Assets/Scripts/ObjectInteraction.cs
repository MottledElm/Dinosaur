using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour, IInteractable
{
    public string InteractionMessage1;
    public string InteractionMessage2;
    public string InteractionMessage3;

    public ParticleSystem ScanEffect;
    public int ScanDuration = 1000;
    public int CurrentScanDuration;
    public float CurrentScanDelay;
    public Material ScanMaterial;
    public Material OriginalMaterial;
    public bool IsScan = false;
    public void Interact()
    {
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage1 = InteractionMessage1;
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage2 = InteractionMessage2;
        GameObject.Find("Controller").GetComponent<GameController>().CurrentMessage3 = InteractionMessage3;
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
