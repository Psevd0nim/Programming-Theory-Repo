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
    [SerializeField] private Button SprintHotKeyButton;
    public static KeyCode JumpHotKey { get; private set; }
    public static KeyCode SprintHotKey { get; private set; }
    [SerializeField] private GameObject PressAnyKeyText;
    private TextMeshProUGUI JumpHotKeyText;
    private TextMeshProUGUI SprintHotKeyText;
    private bool JumpHotKeyPressed;
    private bool SprintHotKeyPressed;
    public static bool lockIsOpen;
    private CatScript ñatScript;

    private void Awake()
    {
        UploadData();
    }

    private void Start()
    {
        JumpHotKeyButton.onClick.AddListener(() => JumpHotKeyChangePressed());
        SprintHotKeyButton.onClick.AddListener(() => SprintHotKeyChangePressed());
        JumpHotKeyText = JumpHotKeyButton.GetComponentInChildren<TextMeshProUGUI>();
        SprintHotKeyText = SprintHotKeyButton.GetComponentInChildren<TextMeshProUGUI>();
        ñatScript = GameObject.Find("Cat Asisstant").GetComponent<CatScript>();
        //JumpHotKeyText.text = JumpHotKey.ToString();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Settings.activeInHierarchy)
        {
            SettingsOff();
        }
        if (JumpHotKeyPressed)
        {
            HotKeyChanging();
        }
        if(SprintHotKeyPressed)
        {
            SprintHotKeyChanging();
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
                    ñatScript.Dialogue(4);
                    break;
                }
            }
        }
    }

    private void SprintHotKeyChanging()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    SprintHotKey = keyCode;
                    SprintHotKeyText.text = keyCode.ToString();
                    SprintHotKeyPressed = false;
                    PressAnyKeyText.SetActive(false);
                    break;
                }
            }
        }
    }

    private void JumpHotKeyChangePressed()
    {
        PressAnyKeyText.SetActive(true);
        JumpHotKeyPressed = true;
    }
    private void SprintHotKeyChangePressed()
    {
        PressAnyKeyText.SetActive(true);
        SprintHotKeyPressed = true;
    }

    public void SettingsButton()
    {
        //if (lockIsOpen)
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
        var data = new SettingsData { JumpKey = JumpHotKey, SprintKey = SprintHotKey };
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
            SprintHotKey = data.SprintKey;
        }
        //else JumpHotKey = KeyCode.Space;
    }

    [Serializable] class SettingsData
    {
        public KeyCode JumpKey;
        public KeyCode SprintKey;
    }
    
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
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