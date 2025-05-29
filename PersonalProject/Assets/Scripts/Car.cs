using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // �ڵ����� �̵��ӵ� ����
    [SerializeField] [Range(10, 40)] private float _moveSpeed;

    private void Update()
    {
        float move = _moveSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, move);
    }
}
