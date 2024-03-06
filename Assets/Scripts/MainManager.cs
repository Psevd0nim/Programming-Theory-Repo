using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    private CatScript ñatScript;

    private void Start()
    {
        ñatScript = GameObject.Find("Cat Asisstant").GetComponent<CatScript>();
        ñatScript.Dialogue(0);
    }

    public void ExitToMainMenu()
    {
        EnemyTwo.enemyCloseTwo = false;
        EnemyThree.enemyCloseThree = false;
        SceneManager.LoadScene(0);
    }
}