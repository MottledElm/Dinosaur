using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{
    public Image Tutorial;
    public bool IsTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) || Input.GetKey(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            Tutorial.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsTriggered == false)
        {
            Tutorial.gameObject.SetActive(true);
            IsTriggered = true;
        }
        
        
    }
}
