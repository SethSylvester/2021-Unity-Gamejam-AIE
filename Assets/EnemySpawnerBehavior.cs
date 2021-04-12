using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    public float timerDefault = 2.0f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerDefault;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Instantiate(enemy, transform);
            timer = timerDefault;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
