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
            if (DataPersistence.Instance.Count < 1)
            {
                ñatScript.Dialogue(3);
                DataPersistence.Instance.Count++;
            }
            MainMenu.lockIsOpen = true;
            closedLock.SetActive(false);
            openLock.SetActive(true);
        }
    }
}