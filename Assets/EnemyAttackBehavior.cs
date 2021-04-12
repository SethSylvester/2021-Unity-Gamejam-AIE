using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehavior : MonoBehaviour
{
    bool hit = false;
    private void OnTriggerEnter(Collider other)
    {
        //If its an enemy
        if (other.CompareTag("Player") && !hit)
        {
            hit = true;
            //Hurt it
            other.GetComponent<PlayerBehavior>().TakeDamage(1);
            //Then remove
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }
}
