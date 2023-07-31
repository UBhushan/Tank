using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentBoxScaler : MonoBehaviour
{
    private RectTransform rect;
    private int numOfCards;

    private float cardSpaceSize = 250f;

    private void Awake() {
        rect = GetComponent<RectTransform>();
    }

    private void Start() {
        numOfCards = GameManager.instance.NumOfLevels();

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, numOfCards * cardSpaceSize);
    }
}
