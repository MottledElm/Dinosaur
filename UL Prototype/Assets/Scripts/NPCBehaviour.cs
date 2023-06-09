using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform CurrentDestination;
    public Transform BeforeMelee;
    public Transform Stage;
    public Transform DuringInvestigation;
    public Transform AfterInvestigation;
    public Transform ProjectionRoom;

    // Start is called before the first frame update
    void Start()
    {
        CurrentDestination = BeforeMelee;
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(CurrentDestination.position);
        if (CurrentDestination == DuringInvestigation && this.transform.position.x == DuringInvestigation.position.x)
        {
            this.gameObject.SetActive(false);
        }
    }
}
