using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject Switch_1;
    public GameObject Switch_2;
    public GameObject Switch_3;
    public GameObject[] array_1;
    public GameObject[] array_2;
    public GameObject[] array_3;
    public GameObject[] flowerArray; // 꽃 게임오브젝트 배열 추가

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Rendering.Universal.Light2D Sw_1 = Switch_1.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        UnityEngine.Rendering.Universal.Light2D Sw_2 = Switch_2.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        UnityEngine.Rendering.Universal.Light2D Sw_3 = Switch_3.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Rendering.Universal.Light2D Sw_1 = Switch_1.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        UnityEngine.Rendering.Universal.Light2D Sw_2 = Switch_2.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        UnityEngine.Rendering.Universal.Light2D Sw_3 = Switch_3.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        if(Sw_1.intensity <= 0.7f)
        {
            GameObject randomFlower_1 = flowerArray[Random.Range(0, flowerArray.Length)]; // 수정: 꽃 배열에서 랜덤한 값을 선택하도록 수정
            Instantiate(randomFlower_1, transform.position, Quaternion.identity);
        }
        if(Sw_2.intensity <= 0.7f)
        {
            GameObject randomFlower_2 = flowerArray[Random.Range(0, flowerArray.Length)]; // 수정: 꽃 배열에서 랜덤한 값을 선택하도록 수정
            Instantiate(randomFlower_2, transform.position, Quaternion.identity);
        }
        if(Sw_3.intensity <= 0.7f)
        {
            GameObject randomFlower_3 = flowerArray[Random.Range(0, flowerArray.Length)]; // 수정: 꽃 배열에서 랜덤한 값을 선택하도록 수정
            Instantiate(randomFlower_3, transform.position, Quaternion.identity);
        }
    }
}
