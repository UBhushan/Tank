using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSFX : MonoBehaviour
{
    public static UiSFX instance;

    [SerializeField] private AudioClip[] clicks;
 
    private AudioSource uiSfxPlayer;

    private void Awake() {
        SingletonSetup();

        uiSfxPlayer = GetComponentInChildren<AudioSource>();
    }


    public void PlayClick()
    {
        uiSfxPlayer.clip = clicks[Random.Range(0 , clicks.Length)];
        uiSfxPlayer.Play();
    }

    private void SingletonSetup()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
}

