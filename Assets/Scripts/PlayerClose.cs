using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerClose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Two"))
            EnemyTwo.enemyCloseTwo = true;
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Three"))
            EnemyThree.enemyCloseThree = true;
    }
}