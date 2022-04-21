using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip landing, cherry;
    public AudioClip mussic_tiktok;
    public GameObject soundObject;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
    }

} 
