using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCat;
    [SerializeField] private AudioSource audioSource;
    public static string[] arrayText { get; set; }
    [SerializeField] private TextAsset dialogueFile;

    public void Dialogue(int number)
    {
        Talk(arrayText[number]);
    }

    private void Start()
    {
        arrayText = dialogueFile.text.Split('\n');
    }


    void Talk(string text)
    {
        textCat.text = null;
        StartCoroutine(StepByStep(text));
    }

    IEnumerator StepByStep(string text)
    {
        ;
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
