using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Enemy : MonoBehaviour
{

    private int countStep;
    private Vector3 moveDirection = Vector3.left;
    private SpriteRenderer spriteRenderer;
    private bool flipBool = true;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Move();
    }

    public virtual void Move()
    {
        StartCoroutine(MoveCoroutine(moveDirection));
    }
    
    private void MoveStep(Vector3 direction)
    {
        gameObject.transform.Translate(direction * 0.5f);
        countStep++;
    }

    IEnumerator MoveCoroutine(Vector3 direction)
    {
        yield return new WaitForSeconds(0.5f);
        MoveStep(direction);
        if (countStep == 75)
        {
            spriteRenderer.flipX = !flipBool;
            flipBool = !flipBool;
            countStep = 0;
            direction.x *= -1;
        }
        StartCoroutine(MoveCoroutine(direction));
    }
}