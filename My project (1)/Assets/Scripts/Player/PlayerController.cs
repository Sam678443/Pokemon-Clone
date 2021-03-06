using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask longGrassLayer;
    
    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Remove diagonal movement
            if (input.x != 0) input.y = 0;

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                //Player Movement
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;


                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    //Coroutine - Used to do something over a period of time


    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;


        while ((targetPos
                - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();

    }


    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer))
        {
            return false;
        }
        return true;

    }


    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, longGrassLayer) != null)
        {
            if (Random.Range(1,101) <= 10)
            {
                Debug.Log("Encountered a wild Pokemon");
            }
        }
    }





}