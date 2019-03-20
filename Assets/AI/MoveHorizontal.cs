using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : StateMachineBehaviour
{
    public float Speed;
    public GameObject AI;
    public CharacterController Body;
    public float distance;
    public float jumpSpeed = .2F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private int dir;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dir = animator.GetInteger("Dir");
        AI = animator.gameObject;
        GroundCheck = AI.transform.Find("GroundCheck");
        Body = AI.GetComponent<CharacterController>();
        Body.Move(Vector3.zero);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        RaycastHit groundInfo;
        Physics.Raycast(AI.transform.position + (Vector3.right * Speed * dir), Vector3.down, out groundInfo,distance);
        if(groundInfo.collider == false)
        {
            //flip the direction
            //AI.transform.Rotate(new Vector3(0, 180, 0));
            dir = dir * -1;
            //animator.SetTrigger("Turn");
        }
        else
        {
            
            if (Body.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            //moveDirection.y -= gravity * Time.deltaTime;
            
        }
        if (dir < 0)
        {
            AI.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            AI.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }

        Body.SimpleMove(Vector3.right * Speed * dir);
        moveDirection.y -= gravity * Time.deltaTime;
        Body.Move(moveDirection * Time.deltaTime);
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //moveDirection.y -= gravity * Time.deltaTime;
        //Body.Move(moveDirection * Time.deltaTime);
        animator.SetInteger("Dir", dir);
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
