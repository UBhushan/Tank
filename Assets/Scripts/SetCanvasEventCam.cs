using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCanvasEventCam : MonoBehaviour
{
    private Canvas canvas;
    private Camera cam;

    private void Awake() {
        canvas = GetComponent<Canvas>();
    }

    private void Start() {
        cam = Camera.main;
        canvas.worldCamera = cam;
    }
}
