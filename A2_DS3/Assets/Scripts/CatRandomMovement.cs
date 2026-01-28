using UnityEngine;
using UnityEngine.AI;

public class CatRandomMovement : MonoBehaviour
{
    public float movementRadius = 8f;
    public float movementInterval = 3f;

    private NavMeshAgent agent;
    private float timer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = movementInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.isOnNavMesh) {
            return;
        }
        timer += Time.deltaTime;

        if(timer >= movementInterval)
        {
            Vector3 newPos = RandomNavmeshLocation(movementRadius);
            agent.SetDestination(newPos);
            timer=0f;
        }
    }
    Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection+= transform.position;

        if(NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas)) {
            return hit.position;
        }

        return transform.position;
    }
}
