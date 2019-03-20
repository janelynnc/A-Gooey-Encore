using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrol : StateMachineBehaviour
{
    public NavMeshAgent AI;
    public List<Vector3> PatrolPoints;
    private int Cursor = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI = animator.gameObject.GetComponent<NavMeshAgent>();
        PatrolPoints.Clear();
        Transform Parent = GameObject.FindGameObjectWithTag("Patrol").transform;
        for(int i = 0; i < Parent.childCount; i++)
        {
            PatrolPoints.Add(Parent.GetChild(i).position);
        }
        AI.SetDestination(PatrolPoints[Cursor]);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AI.remainingDistance <= .25f)
        {
            Cursor = (Cursor + 1) % PatrolPoints.Count;
            AI.SetDestination(PatrolPoints[Cursor]);
        }    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
