using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private float targetX;
    [SerializeField] private float animationSpeed;

    private void Start()
    {
        LeanTween.moveX(GetComponent<RectTransform>(), targetX, 1 / animationSpeed).setLoopType(LeanTweenType.punch);
    }
}
