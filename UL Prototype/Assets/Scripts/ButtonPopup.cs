using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{   public string Description;
    public GameObject Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Controller.GetComponent<GameController>().UpgradeDescription = Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
