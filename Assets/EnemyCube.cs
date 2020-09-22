using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : Enemy
{
    public int movementSpeed = 10;
    public AudioMusic audioMusic;
    public GameObject deathParticle;

    private GameObject player;
    private Rigidbody myRigidBody;

    public override void EnemyStart()
    {
        myRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        myRigidBody.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movementSpeed));
    }

    public override void Die()
    {
        soundPlayer.PlayMusic(audioMusic);
        Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
