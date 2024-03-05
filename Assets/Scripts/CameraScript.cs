using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        gameObject.transform.position = Player.transform.localPosition + offset;
    }
}