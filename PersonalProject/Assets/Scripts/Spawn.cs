using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Vector3 offsetPos;
    public VehicleController CloneSpawn;
    public Transform StandardPos;

    // Spawn 비율
    public float _spawnPersent = 50;

    // Spawn 시간
    public float _spawnSecond = 1f;
    public float _nextSpawnSecond = 0f;

    // 자동차 Spawn을 위한 코드
    private void Update()
    {
        // 현재 시간은 시작 후 실행 시간
        float currentSecond = Time.time;
        // 만약 다음 Spawn 시간이 현재 시간보다 같거나 작다면
        if (_nextSpawnSecond <= currentSecond)
        {
            // 랜덤하게 나올 수 있도록 설정
            float randomClone = Random.Range(0, 100);
            if (randomClone <= _spawnPersent)
            {
                // CloneCar 함수를 호출
                CloneVehicle();
            }

            // 다음 Spawn 시간은 현재 시간 + SpawnTime
            _nextSpawnSecond = currentSecond + _spawnSecond;
        }
    }

    private void CloneVehicle()
    {
        Transform cloneVehiclePos = StandardPos;
        Vector3 offsetPos = cloneVehiclePos.position;
 

        GameObject cloneObject = GameObject.Instantiate(CloneSpawn.gameObject, offsetPos, StandardPos.rotation, this.transform);

        cloneObject.SetActive(true);
    }
}
