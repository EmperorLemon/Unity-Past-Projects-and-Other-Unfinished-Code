using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;

    bool hasSpottedPlayer;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo))
        {
            hasSpottedPlayer = true;
        }

        Debug.DrawRay(transform.position, transform.forward);

        if (hasSpottedPlayer)
        {
            StartCoroutine("PlayerSpotted");
        }
    }

    IEnumerator PlayerSpotted()
    {
        agent.SetDestination(target.position);

        yield return new WaitForSeconds(1.5f);

        agent.isStopped = true;

    }
}
