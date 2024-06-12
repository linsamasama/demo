using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Mapbuilder : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject treePrefab;
    public GameObject grassPrefab;
    public GameObject mountainPrefab;

    public int mapWidth = 1000;
    public int mapHeight = 1000;
    public float spacing = 1.0f;
    public int numberOfTrees = 10; // 树木数量
    public int numberOfMountains = 20; // 小山峰数量
    public float treeMinDistance = 10.0f; // 树木之间的最小距离

    private void Start()
    {
        GenerateScene();
    }

    void GenerateScene()
    {
        // 生成地面
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);
                GameObject ground = Instantiate(groundPrefab, position, Quaternion.identity);
                ground.tag = "Ground";
            }
        }

        // 生成树木
        int treesCount = 0;
        while (treesCount < numberOfTrees)
        {
            int x = Random.Range(0, mapWidth);
            int z = Random.Range(0, mapHeight);
            Vector3 position = new Vector3(x * spacing, 0, z * spacing);

            if (IsValidPosition(position))
            {
                GameObject tree = Instantiate(treePrefab, position, Quaternion.Euler(-90, 0, 0));
                tree.tag = "Tree";
                treesCount++;
            }
        }

        // 生成小山峰
        for (int i = 0; i < numberOfMountains; i++)
        {
            int x = Random.Range(0, mapWidth);
            int z = Random.Range(0, mapHeight);
            Vector3 position = new Vector3(x * spacing, 0, z * spacing);
            GameObject mountain = Instantiate(mountainPrefab, position, Quaternion.identity);
            mountain.tag = "Mountain";
        }
    }

    bool IsValidPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, treeMinDistance);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Tree") || collider.gameObject.CompareTag("Mountain"))
            {
                return false; // 如果位置附近有树木或山峰，则位置无效
            }
        }
        return true;
    }
}