using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject punchLocation;
    [SerializeField]
    GameObject punch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(punch, punchLocation.transform);
        }
    }
}
