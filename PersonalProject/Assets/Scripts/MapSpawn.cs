using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    private GameObject[] MapObjectArray;
    [SerializeField] private Spawn MainRoad;
    [SerializeField] private Spawn WaterRoad;
    [SerializeField] private TreeObjectSpawn LawnRoad;

    private List<Transform> MapList = new List<Transform>();    
    private Dictionary<int, Transform> MapDic = new Dictionary<int, Transform>();
    private RoadType roadType = RoadType.Max;
    private Transform moveTranform;
    private int LastLinePos = 0;

    private int minLineValue = 0;
    private int DeleteCountLine = 10;
    private int DeleteCountBackLine = 30;

    [SerializeField] int minValueZ;
    [SerializeField] int maxValueZ;

    [SerializeField] int frontPosZ;
    [SerializeField] int backPosZ;

    private void Start()
    {

    }

    // 플레이어가 움직이는 방향에 맞춰 조정
    public void CreateMap(int playerPosZ)
    {

        // 처음 라인 생성
        if (MapList.Count <= 0)
        {
            roadType = RoadType.Lawn;
            minLineValue = minValueZ;
            int i = 0;
            for (i = minValueZ; i < maxValueZ; ++i)
            {
                int offSetValue = 0;
                if (i < 0)
                {
                    // Lawn 생성
                    CreateLawnLine(i);
                }
                else
                {
                    if (roadType == RoadType.Lawn)
                    {
                        int randomRoadValue = Random.Range(0, 2);

                        if (randomRoadValue == 0)
                        {
                            offSetValue = GroupWaterLine(i);
                        }
                        else
                        {
                            offSetValue = GroupRoadLine(i);
                        }

                        roadType = RoadType.Road;
                    }
                    else
                    {
                        offSetValue = GroupLawnLine(i);
                        roadType = RoadType.Lawn;
                    }

                    i += offSetValue - 1;

                }
            }

            LastLinePos = i;
        }

        // 생성
        if (LastLinePos < playerPosZ + frontPosZ)
        {
            int offSetValue = 0;
            if (roadType == RoadType.Lawn)
            {
                int randomRoadValue = Random.Range(0, 2);

                if (randomRoadValue == 0)
                {
                    offSetValue = GroupWaterLine(LastLinePos);
                }
                else
                {
                    offSetValue = GroupRoadLine(LastLinePos);
                }

                roadType = RoadType.Road;
            }
            else
            {
                offSetValue = GroupLawnLine(LastLinePos);
                roadType = RoadType.Lawn;
            }

            LastLinePos += offSetValue;
        }

        // 삭제
        if (playerPosZ - DeleteCountBackLine > minLineValue - DeleteCountLine)
        {
            int count = minLineValue + DeleteCountLine;

            for (int i = minLineValue; i < count; ++i)
            {
                RemoveLine(i);
            }

            minLineValue += DeleteCountLine;
        }
    }

    private void RemoveLine(int playerPosZ)
    {
        if (MapDic.ContainsKey(playerPosZ))
        {
            Transform transformObj = MapDic[playerPosZ];
            GameObject.Destroy(transformObj.gameObject);
            
            MapList.Remove(transformObj);
            MapDic.Remove(playerPosZ);
        }
    }

    private int GroupRoadLine(int playerPosZ)
    {
        int randomCount = Random.Range(1, 4);

        for (int i = 0; i < randomCount; ++i)
        {
            CreateRoadLine(playerPosZ + i);
        }

        return randomCount;
    }
    private int GroupWaterLine(int playerPosZ)
    {
        int randomCount = Random.Range(1, 4);

        for (int i = 0; i < randomCount; ++i)
        {
            CreateWaterLine(playerPosZ + i);
        }

        return randomCount;
    }
    private int GroupLawnLine(int playerPosZ)
    {
        int randomCount = Random.Range(1, 2);

        for (int i = 0; i < randomCount; ++i)
        {
            CreateLawnLine(playerPosZ + i);
        }

        return randomCount;
    }

    private void CreateRoadLine(int playerPosZ)
    {
        GameObject cloneObj = GameObject.Instantiate(MainRoad.gameObject);

        cloneObj.SetActive(true);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)playerPosZ;
        cloneObj.transform.SetParent(moveTranform);
        cloneObj.transform.position = offsetPos;

        int randomRotate = Random.Range(0, 2);
        if (randomRotate == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }

        MapList.Add(cloneObj.transform);
        MapDic.Add(playerPosZ, cloneObj.transform);
    }

    private void CreateWaterLine(int playerPosZ)
    {
        GameObject cloneObj = GameObject.Instantiate(WaterRoad.gameObject);

        cloneObj.SetActive(true);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)playerPosZ;
        cloneObj.transform.SetParent(moveTranform);
        cloneObj.transform.position = offsetPos;

        int randomRotate = Random.Range(0, 2);
        if (randomRotate == 1)
        {
            cloneObj.transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }

        MapList.Add(cloneObj.transform);
        MapDic.Add(playerPosZ, cloneObj.transform);
    }

    private void CreateLawnLine(int playerPosZ)
    {
        GameObject cloneObj = GameObject.Instantiate(LawnRoad.gameObject);

        cloneObj.SetActive(true);

        Vector3 offsetPos = Vector3.zero;
        offsetPos.z = (float)playerPosZ;
        cloneObj.transform.SetParent(moveTranform);
        cloneObj.transform.position = offsetPos;

        MapList.Add(cloneObj.transform);
        MapDic.Add(playerPosZ, cloneObj.transform);
    }

    public enum RoadType
    {
        Lawn = 0,
        Road,

        Max
    }

    public enum EnvironmentType
    { 
        Lawn = 0,
        Road,
        Water,

        Max
    }
}
