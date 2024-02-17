using UnityEngine;

public class CameraChasePlayer : MonoBehaviour
{
    // 플레이어 위치
    public Transform target;

    // 천천히 따라가는 속도 조정 수치
    public float chase_speed;

    // 플레이어와 카메라 간 거리
    public Vector3 offset;

    private void Update()
    {
        // 플레이어 위치에 offset을 더하여 최종 목표 위치 계산
        Vector3 final_target = target.position + offset;

        // 카메라의 위치를 부드럽게 업데이트
        transform.position = Vector3.Lerp(transform.position, final_target, chase_speed * Time.deltaTime);
    }
}
