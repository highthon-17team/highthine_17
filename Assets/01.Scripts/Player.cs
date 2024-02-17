using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Animator _anim;

    Vector3 dir;
    [SerializeField]float moveSpeed = 5f;
    [SerializeField] private bool Light_On = false;
    public GameObject lightObject; // Light2D를 가진 게임 오브젝트 변수 추가
	public GameObject FairyLight;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        if (Light_On == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && lightObject != null) // lightObject가 null이 아닌 경우에만 FadeOutLight 함수 호출
            {
                StartCoroutine(FadeOutLight(lightObject));
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        dir = new Vector2(x, y).normalized;

        Vector3 pos = transform.position + (dir * moveSpeed * Time.deltaTime);

        transform.position = pos;

        _anim.SetFloat("DirX", x);
        _anim.SetFloat("DirY", y);
        _anim.SetBool("Walking", true);
        
        if (x == 0 && y == 0)
            _anim.SetBool("Walking", false);
    }

    IEnumerator FadeOutLight(GameObject obj)
    {
        UnityEngine.Rendering.Universal.Light2D light2D = obj.GetComponent<UnityEngine.Rendering.Universal.Light2D>(); // 게임 오브젝트로부터 Light2D 컴포넌트를 가져옴
        if (light2D != null)
        {
			LightMinus();
            float duration = 1f; // 1초 동안 서서히 감소
            float startIntensity = light2D.intensity;
            float targetIntensity = 0.9f;

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                light2D.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Light2D 컴포넌트를 찾을 수 없습니다.");
        }
    }
	void LightMinus()
	{
		UnityEngine.Rendering.Universal.Light2D Fairy_Light2D = FairyLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
		Fairy_Light2D.intensity -= 0.3f;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Light_On = true;
            lightObject = other.gameObject; // lightObject 변수에 Light2D를 가진 게임 오브젝트 할당
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Light_On = false;
        }
    }
}
