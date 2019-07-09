using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshScript : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public GameObject alvo;
    private Vector3 alvoPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        alvoPos = alvo.transform.position;
        //Debug.Log(alvoPos);
        agent.SetDestination(alvoPos);
        if (agent.speed>0)
        {
            float dis = (alvoPos - transform.position).magnitude;
            agent.speed = (dis* dis) / 20;
        }
    }
}
