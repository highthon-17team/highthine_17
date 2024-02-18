using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UI 관련 기능을 사용하기 위해 추가
using TMPro;

public class Player : MonoBehaviour
{
    private Animator _anim;

    Vector3 dir;
    [SerializeField]float moveSpeed = 5f;
    [SerializeField] private bool Light_On = false;
    public GameObject lightObject;
    public GameObject FairyLight;
    public int Light_Num;

    // 텍스트를 표시할 UI Text 객체
    public TextMeshProUGUI lightCountText;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        if (Light_On == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && lightObject != null)
            {
                StartCoroutine(FadeOutLight(lightObject));
            }
        }

        // 텍스트 업데이트
        UpdateLightCountText();
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
        UnityEngine.Rendering.Universal.Light2D light2D = obj.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        if (light2D != null)
        {
            if(light2D.intensity == 0.2f)
            {
                LightMinus();
                float duration = 1f;
                float startIntensity = light2D.intensity;
                float targetIntensity = 0.9f;

                float elapsedTime = 0f;
                while (elapsedTime < duration)
                {
                    light2D.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                Light_Num++;
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
            lightObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Light_On = false;
        }
    }

    // 텍스트 업데이트 메서드
    void UpdateLightCountText()
    {
        // 텍스트 업데이트
        if(lightCountText != null)
        {
            lightCountText.text = "킨조명 " + Light_Num + "/3";
        }
    }
}
