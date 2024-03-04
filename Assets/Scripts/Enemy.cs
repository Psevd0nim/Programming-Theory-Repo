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
        StartCoroutine(Move(moveDirection));
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void MoveStep(Vector3 direction)
    {
        gameObject.transform.Translate(direction * 2);
        countStep++;
    }

    IEnumerator Move(Vector3 direction)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(countStep);
        MoveStep(direction);
        if (countStep == 5)
        {
            spriteRenderer.flipX = !flipBool;
            flipBool = !flipBool;
            countStep = 0;
            direction.x *= -1;
        }
        StartCoroutine(Move(direction));
    }
}