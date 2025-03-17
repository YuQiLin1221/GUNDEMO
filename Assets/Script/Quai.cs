﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    //public ScreenShake ScreenShake;
    public ParticleSystem explosion;

    public Transform player;
    public float chaseRange = 10f;     // Khoảng cách quái bắt đầu đuổi theo
    public float attackRange = 2f;     // Khoảng cách quái bắt đầu tấn công
    public float attackCooldown = 1.5f; // Thời gian giữa các lần tấn công
    public int attackDamage = 10;       // Lượng sát thương gây ra

    public NavMeshAgent agent;
    private Animator animator;
    private float lastAttackTime;

    public float maxHealth = 50f;
    private float currentHealth;

    enum EnemyState { Idle, Chasing, Attacking }
    private EnemyState currentState = EnemyState.Idle;

    public Slider _slider;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }

    void Update()
    {
        _slider.value = currentHealth;
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = EnemyState.Chasing;
                    animator.SetBool("isRunning", true);
                }
                break;

            case EnemyState.Chasing:
                if (distanceToPlayer > chaseRange)
                {
                    currentState = EnemyState.Idle;
                    animator.SetBool("isRunning", false);
                }
                else if (distanceToPlayer <= attackRange)
                {
                    currentState = EnemyState.Attacking;
                    animator.SetBool("isRunning", false);
                    animator.SetTrigger("Attack");
                }
                else
                {
                    agent.SetDestination(player.position);
                }
                break;

            case EnemyState.Attacking:
                if (distanceToPlayer > attackRange)
                {
                    currentState = EnemyState.Chasing;
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    if (Time.time - lastAttackTime >= attackCooldown)
                    {
                        AttackPlayer();
                        lastAttackTime = Time.time;
                    }
                }
                break;
        }
    }

    void AttackPlayer()
    {
        animator.SetTrigger("Attack01");
        Debug.Log("Quái tấn công Player! Gây sát thương: " + attackDamage);
        explosion.Play();
        //StartCoroutine(ScreenShake.Shake());
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
        _slider.value = currentHealth;
    }
    private void Die()
    {
        // Hủy quái khi chết
        Destroy(gameObject);
    }
}

