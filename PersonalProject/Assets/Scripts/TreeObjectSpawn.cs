using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObjectSpawn : MonoBehaviour
{
    // 맵을 랜덤으로 생성하기 위한 리스트
    public List<Transform> AllRoadObjectList = new List<Transform>();
    private GameObject CloneObject;

    Vector3 offsetPos = Vector3.zero;

    // 맵 시작점
    [SerializeField] private int minValue;
    // 맵 끝점
    [SerializeField] private int maxValue;

    // 랜덤 생성 비율
    [SerializeField] private int randomCreate;

    private void Start()
    {
        CreateAllRoad();
    }

    private void Update()
    {

    }

    private void CreateAllRoad()
    {
        if (this.transform.position.z <= -4)
        {
            CreateNotBack();
        }
        else if (this.transform.position.z <= -4)
        {
            CreateNotRound();
        }
        else
        {
            CreateTree();
        }
    }

    private void CreateNotRound()
    {

    }

    private void CreateNotBack()
    {
        // 랜덤 생성 인덱스
        int creatRandomIndex = 0;

        Vector3 offsetPos = Vector3.zero;



        for (int i = minValue; i < maxValue; ++i)
        {
            creatRandomIndex = Random.Range(0, AllRoadObjectList.Count);

            CloneObject = GameObject.Instantiate(AllRoadObjectList[creatRandomIndex].gameObject);
            CloneObject.SetActive(true);

            offsetPos.Set(i, 1f, 0f);

            CloneObject.transform.SetParent(this.transform);

            CloneObject.transform.localPosition = offsetPos;
        }
    }

    private void CreateTree()
    {
        // 랜덤 생성 인덱스
        int creatRandomIndex = 0;
        // 생성 비율과 비교
        int creatRandomValue = 0;

        Vector3 offsetPos = Vector3.zero;

        float posZ = this.transform.position.z;

        for (int i = minValue; i < maxValue; ++i)
        {
            creatRandomValue = Random.Range(0, 100);

            if (creatRandomValue < randomCreate)
            {
                creatRandomIndex = Random.Range(0, AllRoadObjectList.Count);

                CloneObject = GameObject.Instantiate(AllRoadObjectList[creatRandomIndex].gameObject);
                CloneObject.SetActive(true);

                offsetPos.Set(i, 1f, 0f);

                CloneObject.transform.SetParent(this.transform);

                CloneObject.transform.localPosition = offsetPos;
            }
        }
    }
}
