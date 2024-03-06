using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance { get; private set; }
    public bool PlayerDead;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}