using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // 자동차의 이동속도 설정
    [SerializeField] [Range(10, 40)] private float _moveSpeed;

    private void Update()
    {
        float move = _moveSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, move);
    }
}
