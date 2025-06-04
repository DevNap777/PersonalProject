using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class PlayerController : MonoBehaviour
{
    #region 예비
    //private Rigidbody rigid;
    //private float movePower;
    //
    //private Vector3 playerPos;
    //private Vector3 userInputVec;
    //
    //private GameObject raftObj;
    //private Transform raftObjTransfom;
    //
    //private void Awake() => Init();
    //
    //private void Init()
    //{
    //    rigid = GetComponent<Rigidbody>();
    //}
    //
    //private void Update()
    //{
    //    PlayerInput();
    //}
    //
    //private void RaftMove()
    //{
    //    Vector3 raftOffsetPos = Vector3.zero;
    //
    //    if (raftObj == null)
    //    {
    //        return;
    //    }
    //
    //    // 뗏목과 플레이어가 같이 움직이도록
    //    // 뗏목의 위치와 플레이어의 위치가 같도록
    //    Vector3 playerPos = raftObj.transform.position + raftOffsetPos;
    //    //raftObj
    //}
    //
    //private void PlayerInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        rigid.AddForce(Vector3.up * movePower, ForceMode.Force);
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        rigid.AddForce(Vector3.down * movePower, ForceMode.Force);
    //    }
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        rigid.AddForce(Vector3.left * movePower, ForceMode.Force);
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        rigid.AddForce(Vector3.right * movePower, ForceMode.Force);
    //    }
    //    //float x = Input.GetAxis("Horizontal");
    //    //float z = Input.GetAxis("Vertical");
    //    //
    //    //userInputVec = new Vector3(x, 0, z).normalized;
    //}
    //
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag.Contains("Raft"))
    //    {
    //        raftObj = transform.parent.GetComponent<GameObject>();
    //
    //        if (raftObj != null)
    //        {
    //            raftObjTransfom = raftObj.transform;
    //        }
    //
    //        Debug.Log($"{other.name}올라탐");
    //        return;
    //    }
    //}
    //
    //private void OnTriggerExit(Collider other)
    //{
    //    if (raftObjTransfom == other.transform)
    //    {
    //        raftObjTransfom = null;
    //        raftObj = null;
    //    }
    //}
    #endregion
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private VehicleController raftObj = null;
    [SerializeField] private Transform raftPos = null;

    public MapSpawn MapSpawnManager;
    Vector3 raftOffsetPos = Vector3.zero;

    public E_DirectionPlayer moveDirection = E_DirectionPlayer.Up;
    private int treeLayerMask = 1;

    private void Start()
    {
        string[] moveCheckPlayer = new string[] { "Tree" };
        treeLayerMask = LayerMask.GetMask(moveCheckPlayer);

        MapSpawnManager.CreateMap((int)this.transform.position.z);
    }

    private void Update()
    {
        PlayerMove();
        RaftMove();
    }

    private void RaftMove()
    {
        if (raftObj == null)
        {
            return;
        }

        Vector3 playerPos = raftObj.transform.position + raftOffsetPos;

        this.transform.position = playerPos;
    }

    private void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerInput(E_DirectionPlayer.Up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerInput(E_DirectionPlayer.Down);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerInput(E_DirectionPlayer.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerInput(E_DirectionPlayer.Right);
        }
    }

    private bool IsCheckMove(E_DirectionPlayer e_DirectionPlayer)
    {
        Vector3 playerOffsetPos = Vector3.zero;
    
        switch (e_DirectionPlayer)
        {
            case E_DirectionPlayer.Up:
                playerOffsetPos = Vector3.forward;
                break;
            case E_DirectionPlayer.Down:
                playerOffsetPos = Vector3.back;
                break;
            case E_DirectionPlayer.Left:
                playerOffsetPos = Vector3.left;
                break;
            case E_DirectionPlayer.Right:
                playerOffsetPos = Vector3.right;
                break;
            default:
                break;
        }
    
        if (Physics.Raycast(this.transform.position, playerOffsetPos, out RaycastHit raycastHit, 1f, treeLayerMask))
        {
            return true;
        }
    
        return false;
    }

    private void PlayerInput(E_DirectionPlayer e_DirectionPlayer)
    {
        if (!IsCheckMove(e_DirectionPlayer)) { return; }

        Vector3 playerOffsetPos = Vector3.zero;

        switch (e_DirectionPlayer)
        {
            case E_DirectionPlayer.Up:
                playerOffsetPos = Vector3.forward;
                break;
            case E_DirectionPlayer.Down:
                playerOffsetPos = Vector3.back;
                break;
            case E_DirectionPlayer.Left:
                playerOffsetPos = Vector3.left;
                break;
            case E_DirectionPlayer.Right:
                playerOffsetPos = Vector3.right;
                break;
            default:
                break;
        }

        this.transform.position += playerOffsetPos;

        raftOffsetPos += playerOffsetPos;

        MapSpawnManager.CreateMap((int)this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 뗏목에 올라탔는지 판별
        if (other.tag.Contains("Raft"))
        {
            raftObj = other.transform.parent.GetComponent<VehicleController>();

            if (raftObj != null)
            {
                raftPos = raftObj.transform;
                raftOffsetPos = this.transform.position - raftObj.transform.position;
            }

            Debug.Log("탐");
            return;
        }

        // 차에 부딪혔는지 판별
        if (other.tag.Contains("Car"))
        {
            Debug.Log("GameOver");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Raft") && raftPos == other.transform.parent)
        {
            raftPos = null;
            raftObj = null;

            // 뗏목에서 나올때의 포지션
            raftOffsetPos = Vector3.zero;
        }
    }

    public enum E_DirectionPlayer
    { 
        Up = 0,
        Down,
        Left,
        Right,
    }
}
