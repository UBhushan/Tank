using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFxPrefab : MonoBehaviour
{
    private AudioSource source;

    private void Awake() {
        source = GetComponent<AudioSource>();
    }

    public void PlayFxClip(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        Destroy(this.gameObject, 6f);
    }

}
