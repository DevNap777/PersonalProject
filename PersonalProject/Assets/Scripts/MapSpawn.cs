using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] MapObjectArray;
    private Transform moveTranform;

    [SerializeField] int minValueZ;
    [SerializeField] int maxValueZ;

    private void Start()
    {
        for (int i = minValueZ; i < maxValueZ; ++i)
        {
            CloneRoad(i);
        }
    }

    private void CloneRoad(int playerPosZ)
    {
        int randomIndex = Random.Range(0, MapObjectArray.Length);
        GameObject cloneObj = GameObject.Instantiate(MapObjectArray[randomIndex]);
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
    }
}
