using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UnlockedCard : MonoBehaviour
{
    private TextMeshProUGUI levelNum;
    private int levelint;

    private void Awake() {
        levelNum = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetLevelNum(int n) 
    {
        levelint = n;
        levelNum.text = n.ToString();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelint);
    }

}
