using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject OtherDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Lockpick()
    {
        Debug.Log("Lockpick");
        yield return new WaitForSeconds(2);
        OtherDoor.SetActive(true);
        Destroy(this.gameObject);
    }
}
