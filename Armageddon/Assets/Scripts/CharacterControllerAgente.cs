using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterControllerAgente : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null)
        {
            // Search the map for an object tagged Target
            target = GameObject.FindGameObjectWithTag("Personaje");
        }
        else
        {
            // If there is a target selected, tell the Agent to go there
            agent.SetDestination(target.transform.position);
        }
    }
}
