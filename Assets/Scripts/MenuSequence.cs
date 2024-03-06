using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuSequence : MonoBehaviour
{
    private CatScript �atScript;
    [SerializeField] GameObject closedLock;
    [SerializeField] GameObject openLock;

    private void Start()
    {
        �atScript = GameObject.Find("Cat Asisstant").GetComponent<CatScript>();
        if (GameObject.Find("DataPersistence") != null && DataPersistence.Instance.PlayerDead)
        {
            �atScript.Dialogue(3);
            MainMenu.lockIsOpen = true;
            closedLock.SetActive(false);
            openLock.SetActive(true);
        }
    }
}