using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FaceCamera : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localEulerAngles = -gameObject.transform.parent.localEulerAngles;
        
        anim.SetFloat("VelX", agent.velocity.x);
        anim.SetFloat("VelY", agent.velocity.y);
    }
}
