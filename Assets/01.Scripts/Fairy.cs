using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public float floatHeight = 0.3f; // 떠다니는 높이
    public float floatSpeed = 2f; // 떠다니는 속도

    private Animator _anim;
    private Vector3 startPosition;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _anim.SetFloat("DirX", x);
        _anim.SetFloat("DirY", y);

        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = startPosition + new Vector3(0, newY, 0);
    }
}
