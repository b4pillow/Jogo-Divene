using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public float flyTime;
    float currentTime;
    public float chaseDistance;
    public SpriteRenderer sprite;

    Transform playerTransform;
    Vector3 moveDirection;

    private void Awake()
    {
        moveDirection = Vector3.right;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Move();
        sprite.flipX = moveDirection.x <= 0;
        if (Vector3.Distance(playerTransform.position, transform.position) <= chaseDistance) 
        {
            ChasePlayer();
        }
        else
        {
            moveDirection.y = 0;
            if (currentTime >= flyTime)
            {
                moveDirection.x *= -1;
                currentTime = 0;
            }
            currentTime += Time.deltaTime;
        }
    }

    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
    
    void ChasePlayer()
    {
        moveDirection = (playerTransform.position - transform.position).normalized;
    }
}