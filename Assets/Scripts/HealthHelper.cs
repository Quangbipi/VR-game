﻿using UnityEngine;
using System.Collections;
using System;

public class HealthHelper : MonoBehaviour
{
    
    public GameObject BoodPrefab;
    // hp default
    public float MaxHealth = 100;
    public float Health = 100;

    private bool _isDead;
    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }
    GameHelper _gameHelper;
    // Use this for initialization
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void TakeDamage(int damagePerShot, Vector3 point)
    {
        //hp
        float health = Health - damagePerShot;
        // turn on effect and destroy sau 1s
        #region Hit
        GameObject hitEffect = Instantiate(BoodPrefab);
        hitEffect.transform.position = point;
        Destroy(hitEffect, 1);
        #endregion

        if (IsDead)
            return;
        // khi zombie bi tieu diet
        if (health <= 0)
        {
            Health = 0;
            IsDead = true;

            if (GetComponent<Animator>())
                GetComponent<Animator>().SetTrigger("Dead");
            _gameHelper.DeadEnemyes++;

            GetComponent<Collider>().enabled = false;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            Destroy(gameObject, 3);
        }
        else
        {
            Health = health;
        }

    }
}
