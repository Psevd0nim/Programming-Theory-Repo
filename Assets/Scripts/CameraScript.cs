using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offset = new Vector3(0, 0, -10);
    private MainManager mainManager;
    private AudioSource audioSource;
    private int count;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        mainManager = GameObject.Find("Canvas").GetComponent<MainManager>();
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
            mainManager.DialogueTwo();
            count++;
        }
    }
}