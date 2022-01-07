// En este archivo se practica el agente que camina sobre el Navmesh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agente : MonoBehaviour
{
    public GameObject target;   // Objetivo al que intentará ir
    private NavMeshAgent agent; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        // Si el destino es diferente de nulo entonces...
        if(target != null){   

            // ...  asigna como posición destino la position del objetivo
            agent.SetDestination(target.transform.position);
        }
        
    }
}
