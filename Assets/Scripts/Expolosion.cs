using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expolosion : MonoBehaviour
{

    public float radius;
    public float force;
    
    void Start()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in col)
        {
            if (c.name != "Rug_Corridor (4)")
            {
                c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
            }

        }
    }

    
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);


    }
}
