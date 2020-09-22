using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, Damageable
{
    int lifeTotal = 1;
    protected SoundPlayer soundPlayer;

    void Start()
    {
        soundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();

        EnemyStart();
    }

    public abstract void EnemyStart();

    public abstract void Die();

    public void TakeDamange(int damage)
    {
        lifeTotal -= damage;

        if (lifeTotal <= 0)
        {
            Die();
        }
    }
}
