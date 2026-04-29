using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Umber;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance { get; private set; }

    [field: SerializeField]
    public SoundManager SoundManager { get; private set; }

    [field: SerializeField]
    public SoundContainer SoundContainer { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }    
}
