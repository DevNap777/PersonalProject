using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigid;

    // 플레이어 이동속도
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    // 점프를 했는지 하지 않았는지
    private bool _isjumped;
    // 땅을 밟고 있는지 아닌지
    private bool _isRoaded;

    private Vector3 _userInputVec;

    private void Awake() => Init();

    private void Init()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isjumped = true;
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();

        if (_isjumped && _isRoaded)
        {
            PlayerJump();
        }
    }

    // 입력받은 값에 따라 플레이어 움직임 구현
    private void PlayerInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _userInputVec = new Vector3(x, 0, z).normalized;
    }

    private void PlayerMove()
    {
        _rigid.velocity = _userInputVec * _moveSpeed * Time.deltaTime;
    }

    private void PlayerJump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);

        _isjumped = false;
        _isRoaded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Road"))
        {
            Debug.Log("길길길");
            _isRoaded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
