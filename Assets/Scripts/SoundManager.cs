using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private SoundFxPrefab fxPrefab;
    [SerializeField] private AudioClip victoryMusic;

    private AudioSource musicPlayer;



    private void Awake() {
        SingletonSetup();

        musicPlayer = GetComponentInChildren<AudioSource>();
    }

    public void PlayAudioFx(AudioClip clip)
    {
        if(this.gameObject.activeInHierarchy)
        {
            SoundFxPrefab fx = Instantiate(fxPrefab, transform.position, Quaternion.identity);
            fx.PlayFxClip(clip);
        }
        
    }

    public void PlayVictory()
    {
        Invoke(nameof(PlayVictoryDelay), 2f);
    }

    private void PlayVictoryDelay()
    {
        if(musicPlayer != null)
        {
            musicPlayer.Pause();
            musicPlayer.clip = victoryMusic;
            musicPlayer.loop = false;
            musicPlayer.Play();
        }
    }

    public void EnableThis(bool setActiveBool)
    {
        this.gameObject.SetActive(setActiveBool);
    }

    private void SingletonSetup()
    {
        if(instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
}
