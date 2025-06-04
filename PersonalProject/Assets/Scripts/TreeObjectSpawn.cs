using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObjectSpawn : MonoBehaviour
{
    // ���� �������� �����ϱ� ���� ����Ʈ
    public List<Transform> AllRoadObjectList = new List<Transform>();
    private GameObject CloneObject;

    Vector3 offsetPos = Vector3.zero;

    // �� ������
    [SerializeField] private int minValue;
    // �� ����
    [SerializeField] private int maxValue;

    // ���� ���� ����
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
        // ���� ���� �ε���
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
        // ���� ���� �ε���
        int creatRandomIndex = 0;
        // ���� ������ ��
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
