using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainTittle;    
    
    public void SettingsButton()
    {
        MainTittle.SetActive(false);
    }

    public void SettingsOff()
    {
        MainTittle.SetActive(true);
    }
    
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}