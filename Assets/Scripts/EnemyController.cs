﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 90f;
    private Rigidbody rb;
    private GameObject player;
    private Vector3 seekDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        seekDirection = player.transform.position - transform.position;
        rb.AddForce(seekDirection.normalized * speed * Time.deltaTime);
    }
}
