using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float _cameraFollow;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 pos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, pos, _cameraFollow * Time.deltaTime);
    }

    private void Update()
    {
        
    }
}
