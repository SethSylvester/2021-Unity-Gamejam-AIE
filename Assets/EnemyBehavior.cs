using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    GameObject player;
    float distanceToStop = 1.5f;

    NavMeshAgent navmesh;
    [SerializeField]
    GameObject attack;

    float timer;
    float timerDefault = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= distanceToStop)
        {
            transform.LookAt(player.transform);
            navmesh.SetDestination(player.transform.position);
            timer = timerDefault;
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timerDefault;
                Vector3 spawnVector = transform.position + transform.forward;
                Quaternion rotation = transform.rotation;
                Instantiate(attack, spawnVector, rotation);

                navmesh.SetDestination(transform.position);
            }
        }
    }
}
