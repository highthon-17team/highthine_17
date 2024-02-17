using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Vector3 dir;
	float moveSpeed = 5f;

    private void Update()
    {
		Move();
    }

    private void Move()
    {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		dir = new Vector2(x, y).normalized;

		Vector3 pos = transform.position + (dir * moveSpeed * Time.deltaTime);

		transform.position = pos;
	}
}
