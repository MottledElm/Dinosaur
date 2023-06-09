using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour
{
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator.Play("FightIdle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
