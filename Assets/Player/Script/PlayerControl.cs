﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour
{
    public int movementSpeed = 100;
    public GameObject bulletPrefab;
    public float fireDelay = 0.1f;
    private float delayBeforeNextFire = 0f;

    private Rigidbody myRigidbody;
    private Camera myCamera;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        MovePlayer();
        OrientatePlayer();
        ProcessFire();
    }

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical) * Time.deltaTime * movementSpeed;

        myRigidbody.MovePosition(myRigidbody.position + movement);
    }

    private void OrientatePlayer()
    {
        Vector3 result = FindPositionOfMouse();
        result.y = myRigidbody.position.y;
        Vector3 relativePosition = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        myRigidbody.MoveRotation(quaternionRotation);
    }

    private void ProcessFire()
    {
        delayBeforeNextFire -= Time.deltaTime;

        if (Input.GetAxis("Fire1") != 0)
        {
            if (delayBeforeNextFire <= 0)
            {
                ShootBullet();

                delayBeforeNextFire = fireDelay;
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

    private Vector3 FindPositionOfMouse()
    {
        Vector3 result = Vector3.zero;
        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }

        return result;
    }
}
