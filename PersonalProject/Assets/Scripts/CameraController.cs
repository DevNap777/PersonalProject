using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    // ī�޶� �÷��̾ ������� �ӵ� ����
    [SerializeField] private float _cameraFollow;

    // ������ ��, ī�޶� ��ġ�� �˱� ���� ����
    Vector3 currentOffset;

    private void Start()
    {
        currentOffset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 pos = player.position + currentOffset;

        // ���� ������ �̿��� ī�޶� �ε巴�� ����� �� �ֵ��� ����
        transform.position = Vector3.Lerp(transform.position, pos, _cameraFollow * Time.deltaTime);
    }
}
