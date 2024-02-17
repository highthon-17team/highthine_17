using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Vector3 dir;
	float moveSpeed = 5f;
	[SerializeField]private bool Light_On = false;

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
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Light"))
		{
			Light_On = true;
			if(Input.GetKeyDown(KeyCode.F))
			{
				//불끄는 코드 작성
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Light"))
		{
			Light_On = false;
		}
	}
}
