using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeAI : MonoBehaviour
{
    public Animator Animator;
    public GameObject Player;
    public NavMeshAgent nav;

    public float JumpHeight;
    public float JumpDuration;
    public bool EnableNav = true;
    public Transform SpriteTransform;
    public List<Transform> Patrol;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
       /*Vector3 MyPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        Vector3 PlayerPos = Camera.main.WorldToViewportPoint(Player.transform.position);
        Animator.SetFloat("EnemyDistance", Vector2.Distance(MyPos, PlayerPos));
        Animator.SetFloat("EnemyDirection", (MyPos - PlayerPos).x);
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        nav.enabled = EnableNav;
        Animator.SetTrigger("Floor");
    }

    IEnumerator Jump()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                StartCoroutine(Parabola(agent, JumpHeight, JumpDuration));
                agent.CompleteOffMeshLink();
            }
            yield return null;
        }
    }

    IEnumerator Parabola(NavMeshAgent agent, float height, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        Animator.SetBool("Jumping", true);
        while (normalizedTime < 1.0f)
        {
            float yOffset = height * 4.0f * (normalizedTime - normalizedTime * normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        Animator.SetBool("Jumping", false);
    }
}
