using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Vector3 offsetPos;
    public VehicleController CloneSpawn;
    public Transform StandardPos;

    // Spawn ����
    public float _spawnPersent = 50;

    // Spawn �ð�
    public float _spawnSecond = 1f;
    public float _nextSpawnSecond = 0f;

    // �ڵ��� Spawn�� ���� �ڵ�
    private void Update()
    {
        // ���� �ð��� ���� �� ���� �ð�
        float currentSecond = Time.time;
        // ���� ���� Spawn �ð��� ���� �ð����� ���ų� �۴ٸ�
        if (_nextSpawnSecond <= currentSecond)
        {
            // �����ϰ� ���� �� �ֵ��� ����
            float randomClone = Random.Range(0, 100);
            if (randomClone <= _spawnPersent)
            {
                // CloneCar �Լ��� ȣ��
                CloneVehicle();
            }

            // ���� Spawn �ð��� ���� �ð� + SpawnTime
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
