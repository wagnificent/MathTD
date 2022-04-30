using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{


    private void Start()
    {
        //InvokeRepeating("Move", 1 / Speed, 1 / Speed);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Debug.Log("Moving");
        //follow the tower's path, moving from one point to another at a set speed
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
