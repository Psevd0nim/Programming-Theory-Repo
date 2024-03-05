using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainTittle;
    [SerializeField] private GameObject Settings;
    [SerializeField] private Button JumpHotKeyButton;
    public static KeyCode JumpHotKey { get; private set; }
    [SerializeField] private GameObject PressAnyKeyText;
    private TextMeshProUGUI JumpHotKeyText;
    private bool JumpHotKeyPressed;
    private bool lockIsOpen;

    private void Awake()
    {
        UploadData();
    }

    private void Start()
    {
        JumpHotKeyButton.onClick.AddListener(() => HotKeyChangePressed());
        JumpHotKeyText = JumpHotKeyButton.GetComponentInChildren<TextMeshProUGUI>();
        //JumpHotKeyText.text = JumpHotKey.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Settings.activeInHierarchy)
        {
            SettingsOff();
        }
        if(JumpHotKeyPressed)
        {
            HotKeyChanging();
        }

    }

    private void HotKeyChanging()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    JumpHotKey = keyCode;
                    JumpHotKeyText.text = keyCode.ToString();
                    JumpHotKeyPressed = false;
                    PressAnyKeyText.SetActive(false);
                    break;
                }
            }
        }
    }

    private void HotKeyChangePressed()
    {
        PressAnyKeyText.SetActive(true);
        JumpHotKeyPressed = true;
    }
    
    public void SettingsButton()
    {
        if (lockIsOpen)
        {
            MainTittle.SetActive(false);
            Settings.SetActive(true);
        }
    }

    public void SettingsOff()
    {
        MainTittle.SetActive(true);
        Settings.SetActive(false);
        SaveData();
    }

    void SaveData()
    {
        var data = new SettingsData { JumpKey = JumpHotKey };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/datasave.json", json);
    }

    void UploadData()
    {
        string path = Application.persistentDataPath + "/datasave.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            JumpHotKey = data.JumpKey;
        }
        //else JumpHotKey = KeyCode.Space;
    }

    [Serializable] class SettingsData
    {
        public KeyCode JumpKey;
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