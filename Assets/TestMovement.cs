using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestMovement : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent AI;
    // Start is called before the first frame update
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            AI.SetDestination(Target.position);
        }
    }
}
