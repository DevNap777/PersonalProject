using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public Car CloneSpawn;
    public Transform StandardPos;

    // Spawn ����
    public float SpawnPersent = 50;

    // Spawn �ð�
    public float SpawnSecond = 1f;
    public float NextSpawnSecond = 0f;

    // �ڵ��� Spawn�� ���� �ڵ�
    private void Update()
    {
        // ���� �ð��� ���� �� ���� �ð�
        float currentSecond = Time.time;
        // ���� ���� Spawn �ð��� ���� �ð����� ���ų� �۴ٸ�
        if (NextSpawnSecond <= currentSecond)
        {
            // �����ϰ� ���� �� �ֵ��� ����
            float randomClone = Random.Range(0, 100);
            if (randomClone <= SpawnPersent)
            {
                // CloneCar �Լ��� ȣ��
                CloneCar();

            }

            // ���� Spawn �ð��� ���� �ð� + SpawnTime
            NextSpawnSecond = currentSecond + SpawnSecond;
        }
    }

    private void CloneCar()
    {
        Transform cloneCarPos = StandardPos;
        Vector3 offsetPos = cloneCarPos.position;
        offsetPos.y = 0.5f;

        GameObject cloneObject = GameObject.Instantiate(CloneSpawn.gameObject, offsetPos, StandardPos.rotation, this.transform);

        cloneObject.SetActive(true);
    }
}
