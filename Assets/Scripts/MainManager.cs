using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCat;
    [SerializeField] private AudioSource audioSource;
    public static string[] arrayText { get; set; }
    [SerializeField] private TextAsset dialogueFile;

    public void DialogueTwo()
    {
        Talk(arrayText[1]);
    }
    
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        arrayText = dialogueFile.text.Split('\n');
        Talk(arrayText[0]);
    }


    void Talk(string text)
    {
        textCat.text = null;
        StartCoroutine(StepByStep(text));
    }

    IEnumerator StepByStep(string text)
    {;
        audioSource.PlayDelayed(0.06f);
        var number = 0;
        while (text.Length != number)
        {
            yield return new WaitForSeconds(0.05f);
            textCat.text += text[number];
            number++;
        }
        audioSource.Stop();
    }

    
}