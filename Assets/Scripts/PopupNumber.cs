using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupNumber : MonoBehaviour
{
    private float textMeshPro = 0f;

    [SerializeField] private float disappearSpeed = 1f;
    [SerializeField] private float maxSize = 1.5f; 

    private Vector3 scale;

    private void Awake() {
        
        scale = Vector3.one * 0.75f;
        transform.localScale = scale;
    }


    private void Update() {
        Grow();
        Disappear();
    }

    private void Grow()
    {
        scale = Vector3.Lerp(scale, Vector3.one * maxSize, Time.deltaTime);
        transform.localScale = scale;
    }

    public void Disappear()
    {
        textMeshPro += disappearSpeed * Time.deltaTime;

        if(textMeshPro >= 3f)
        {
            Destroy(this.gameObject);
        }
    }
}
