using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayFairy : MonoBehaviour
{
    public float floatHeight = 0.3f; // 떠다니는 높이
    public float floatSpeed = 2f; // 떠다니는 속도

    private Animator _anim;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = startPosition + new Vector3(0, newY, 0);
    }
}
