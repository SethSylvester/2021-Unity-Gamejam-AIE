using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandCollisionBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //If its an enemy
        if (other.CompareTag("EnemyHitbox"))
        {
            //Hurt it
            Destroy(other.gameObject);
            //Then remove
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }
}