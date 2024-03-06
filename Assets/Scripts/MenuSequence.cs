using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuSequence : MonoBehaviour
{
    private CatScript ñatScript;
    [SerializeField] GameObject closedLock;
    [SerializeField] GameObject openLock;

    private void Start()
    {
        ñatScript = GameObject.Find("Cat Asisstant").GetComponent<CatScript>();
        if (GameObject.Find("DataPersistence") != null && DataPersistence.Instance.PlayerDead)
        {
            ñatScript.Dialogue(3);
            MainMenu.lockIsOpen = true;
            closedLock.SetActive(false);
            openLock.SetActive(true);
        }
    }
}