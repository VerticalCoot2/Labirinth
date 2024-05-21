using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawnerScript : MonoBehaviour
{

    [SerializeField] List<Transform> ts;
    [SerializeField] GameObject spawnPoints;
    [SerializeField] GameObject colPrefab;
    

    List<int> usedIndex = new List<int>();

    void Awake()
    {
        for (int i = 0; i < spawnPoints.transform.childCount; i++)
        {
            ts.Add(spawnPoints.GetComponentInChildren<Transform>().GetChild(i));
        }
    }
    void Start()
    {
        Randomiser();
    }

    void Randomiser()
    {
        for(int i = 0; i < 8; i++)
        {
            int rand = Random.Range(0, ts.Count);
            if (!usedIndex.Contains(rand))
            {
                usedIndex.Add(rand);
                Instantiate(colPrefab, ts[rand].transform);
            }
        }
    }
    bool check(int num)
    {
        for(int i = 0; i < usedIndex.Count; i++)
        {
            if (usedIndex[i] == num)
            {
                return false;
            }
        }
        return true;
    }
        
}
