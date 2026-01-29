using UnityEngine;
using UnityEngine.AI;

public class CatAnimation : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }
}
