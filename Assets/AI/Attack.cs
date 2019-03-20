using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    private bool shot = false;
    public GameObject Blob;

    private GameObject NPC;
    private GameObject Player;
    public float force;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        Player = Camera.main.gameObject;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > 1f)
        {
            
            Shoot();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shot = false;
    }

    public void Shoot()
    {
        if (shot)
        {
            return;
        }
        shot = true;
        GameObject Projectile = GameObject.Instantiate(Blob, NPC.transform.position, Quaternion.identity, null);
        Vector3 Target = Player.transform.position - NPC.transform.position;
        Projectile.GetComponent<Rigidbody>().AddForce(Target.normalized * force);
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
