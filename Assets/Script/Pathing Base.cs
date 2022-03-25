using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathingBase : MonoBehaviour
{
    private NavMeshAgent Personnages;
    public Vector3 Destionation;

    // Start is called before the first frame update
    void Start()
    {
        Destionation = Destination();
        Personnages = GetComponent<NavMeshAgent>();
        Personnages.SetDestination(Destionation);
        
    }
    Vector3 Destination()
    {

        float limiteX_left = 0f;
        float limiteX_Right = 0f;
        float limiteZ = 0f;
        return new Vector3(limiteX_left, limiteX_Right, limiteZ);
        // Update is called once per frame
        void Update()
        {
            if 
        }
        
    }
}
