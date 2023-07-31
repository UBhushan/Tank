using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private UnityEvent enemyDestroyed;

    private void OnDestroy() {
        if(enemyDestroyed != null && SoundManager.instance != null)
        {
            enemyDestroyed.Invoke();
        }

    }
}
