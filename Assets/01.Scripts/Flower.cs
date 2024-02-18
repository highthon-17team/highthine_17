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
    private float lastSpawnTime = 0f;
    private float spawnInterval = 30f; // 꽃 생성 간격

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

        // 각 스위치의 강도가 0.7 이하이고, 마지막 생성 시간에서 일정 시간이 경과한 경우에만 꽃 생성
        if(Sw_1.intensity <= 0.7f && Time.time - lastSpawnTime >= spawnInterval)
        {
            GameObject randomFlower_1 = array_1[Random.Range(0, array_1.Length)]; 
            Instantiate(randomFlower_1, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
        if(Sw_2.intensity <= 0.7f && Time.time - lastSpawnTime >= spawnInterval)
        {
            GameObject randomFlower_2 = array_2[Random.Range(0, array_2.Length)]; 
            Instantiate(randomFlower_2, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
        if(Sw_3.intensity <= 0.7f && Time.time - lastSpawnTime >= spawnInterval)
        {
            GameObject randomFlower_3 = array_3[Random.Range(0, array_3.Length)]; 
            Instantiate(randomFlower_3, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
