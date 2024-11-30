using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector2 targetOffset;
    [SerializeField] private Transform targetTransform;
    
    public float platformSpeed;
    public bool useTargetTransform;
    public bool flipDirection;

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private Vector2 currentMoveDirection;
    private bool isReturningToStart;
    private float originalLocalScaleX;
    private PlayerController playerController;

    private void Start()
    {
        InitializePlatform();
    }

    private void Update()
    {
        MovePlatform();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        HandlePlayerCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        DrawMovementPath();
    }

    private void InitializePlatform()
    {
        if (flipDirection) 
            originalLocalScaleX = transform.localScale.x;

        targetPosition = useTargetTransform ? targetTransform.localPosition : targetOffset;

        startPosition = transform.position;
        currentMoveDirection = (startPosition + targetPosition - (Vector2)transform.position).normalized;
    }

    private void MovePlatform()
    {
        if (!isReturningToStart)
        {
            if (Vector2.Distance(transform.position, startPosition + targetPosition) < 1f)
            {
                isReturningToStart = true;
                currentMoveDirection = (startPosition - (Vector2)transform.position).normalized;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, startPosition) < 1f)
            {
                isReturningToStart = false;
                currentMoveDirection = (startPosition + targetPosition - (Vector2)transform.position).normalized;
            }
        }

        if (flipDirection)
            FlipPlatformDirection();

        transform.position += (Vector3)currentMoveDirection * platformSpeed * Time.deltaTime;
    }

    private void FlipPlatformDirection()
    {
        if (isReturningToStart)
            transform.localScale = new Vector3(-originalLocalScaleX, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(originalLocalScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            return;
        }

        if (collision.transform.position.y <= transform.position.y)
        {
            collision.transform.SetParent(null);
            return;
        }

        playerController ??= collision.gameObject.GetComponent<PlayerController>();

        if (playerController.rb.velocity.x == 0)
        {
            collision.transform.SetParent(transform);
        }
        else
        {
            collision.transform.SetParent(null);
        }
    }

    private void DrawMovementPath()
    {
        if (useTargetTransform)
        {
            Debug.DrawLine(transform.position, transform.position + targetTransform.localPosition, Color.yellow);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)targetOffset, Color.red);
        }
    }
}
