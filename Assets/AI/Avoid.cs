using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Avoid : StateMachineBehaviour
{


    public NavMeshAgent AI;
    public float dist;
    [SerializeField] private int dir;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI = animator.gameObject.GetComponent<NavMeshAgent>();
        Move(animator.GetFloat("EnemyDirection"));
        //Move();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AI.remainingDistance <= AI.stoppingDistance)
        {
            Move(animator.GetFloat("EnemyDirection"));
        }
        
    }

    public void Move(float EnemyDirection)
    {
        if (EnemyDirection > 0)
        {
            dir = 1;      
        }
        else if(EnemyDirection < 0)
        {
            dir = -1;
        }

        Vector3 Direction = AI.gameObject.transform.position + (Vector3.right * dir * dist);
        NavMeshHit navHit;

        NavMesh.SamplePosition(Direction, out navHit,1,-1);
        AI.SetDestination(Direction);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
