using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // 움직이는 오브젝트 이동속도 설정
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _moveRange;

    private void Update()
    {
        float move = _moveSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, move);

        if (this.transform.localPosition.x >= _moveRange)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
