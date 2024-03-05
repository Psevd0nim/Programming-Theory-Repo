using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private string test = "Hello, stranger! Be carefull! These lands are dangerous!";
    [SerializeField] private TextMeshProUGUI textCat;
    [SerializeField] private AudioSource audioSource;

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        Talk();
    }


    void Talk()
    {
        StartCoroutine(StepByStep());
    }

    IEnumerator StepByStep()
    {;
        audioSource.PlayDelayed(0.06f);
        var number = 0;
        while (test.Length != number)
        {
            yield return new WaitForSeconds(0.05f);
            textCat.text += test[number];
            number++;
        }
        audioSource.Stop();
    }
}