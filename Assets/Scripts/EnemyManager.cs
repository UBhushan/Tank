using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private int totalNumEnemy;
    private float levelEndCallDelay = 6f;

    private int enemyDestroyedCount = 0;

    public void OnEnemyDestroyedEvent()
    {
        enemyDestroyedCount++;

        if(enemyDestroyedCount >= totalNumEnemy)
        {
            Invoke(nameof(EndLevel), levelEndCallDelay);

            if(CameraManager.instance != null)
            {
              CameraManager.instance.ChangeTOEndCam();
            }    
            
            if(SoundManager.instance != null)   SoundManager.instance.PlayVictory();
        }
    }


    private void EndLevel()
    {
        GameManager.instance.LevelEnded();
    }
}
