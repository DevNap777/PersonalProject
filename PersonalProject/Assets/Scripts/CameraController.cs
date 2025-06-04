using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    // 카메라가 플레이어를 따라오는 속도 조절
    [SerializeField] private float _cameraFollow;

    // 시작할 때, 카메라 위치를 알기 위한 변수
    Vector3 currentOffset;

    private void Start()
    {
        currentOffset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 pos = player.position + currentOffset;

        // 선형 보간을 이용해 카메라가 부드럽게 따라올 수 있도록 설정
        transform.position = Vector3.Lerp(transform.position, pos, _cameraFollow * Time.deltaTime);
    }
}
