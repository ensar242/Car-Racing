using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hareket : MonoBehaviour
{
    public GameObject[] Noktalar;
    NavMeshAgent agent;
    int sira = 0;
    float mesafe;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        mesafe = Vector3.Distance(transform.position, Noktalar[sira].transform.position);
        if (mesafe < 10) {
            sira++;
        }
        if (sira == Noktalar.Length) {
        sira=0;
        }
        agent.SetDestination(Noktalar[sira].transform.position);
    }
}
