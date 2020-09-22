using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody myRigidBody;
    public int lifeSpan = 10;
    public int bulletSpeed = 10;
    public int bulletDamage;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeSpan);
    }

    void Update()
    {
        Vector3 position = transform.position;
        position += transform.forward * Time.deltaTime * bulletSpeed;
        myRigidBody.MovePosition(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamange(1);
        }
    }
}
