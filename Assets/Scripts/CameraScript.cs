using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offset = new Vector3(0, 0, -10);
    private CatScript ñatScript;
    private AudioSource audioSource;
    private int count;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        ñatScript = GameObject.Find("Cat Asisstant").GetComponent<CatScript>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(4f);
    }

    void LateUpdate()
    {
        gameObject.transform.position = Player.transform.localPosition + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && count < 1)
        {
            ñatScript.Dialogue(1);
            count++;
        }
    }
}