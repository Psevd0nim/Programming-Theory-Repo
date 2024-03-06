using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : Enemy
{
    private Player player;
    private Vector3 directionPosition;
    [SerializeField] private float speed = 1.0f;
    private float xValue;
    public static bool enemyCloseThree;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void Move()
    {
        xValue = player.transform.position.x - transform.position.x;
        directionPosition = new Vector3(xValue, 0, 0);
        gameObject.transform.Translate(directionPosition.normalized * Time.deltaTime * speed);
    }

    private void Update()
    {
        if (enemyCloseThree)
            Move();
    }
}
