using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform spawnPoints;
    [SerializeField]
    public List<GameObject> collectibles;
    [SerializeField]
    public List<GameObject> objects;

    private Vector3 targetPosition;

    private List<Transform> childPoints;
    
    public List<int> forbiddenIndex;


    [HideInInspector]
    public List<string> collectibleNames;
    private int counter = 0;
    void Start()
    {
        collectibleNames = new List<string>();
        childPoints = new List<Transform>();

        foreach(GameObject child in collectibles)
        {
            collectibleNames.Add(child.name+"(Clone)");
        }

        Spawn();
    }

    void Spawn()
    {
        int random;
        foreach(Transform child in spawnPoints)
        {
            childPoints.Add(child);
        }

        for (int i = 0; i < collectibles.Count; i++)//collectiblesleri yerleştiricem
        {
            random = Random.Range(0, childPoints.Count);
            targetPosition = childPoints[random].transform.position;
            Instantiate(collectibles[i], targetPosition, Quaternion.identity);
            childPoints.RemoveAt(random);
        }

        for(int i = 0;i < objects.Count; i++)//kalan yerlere objectleri yerleştiricem
        {
            random = Random.Range(0, childPoints.Count);
            targetPosition = childPoints[random].transform.position;
            Instantiate(objects[i], targetPosition, Quaternion.identity);
            childPoints.RemoveAt(random);
        }   
    }
    private int ChooseRandomSpawn()
    {
        int random = Random.Range(0, spawnPoints.childCount);
        if (forbiddenIndex.Contains(random) && forbiddenIndex.Count != 0)
        {
            ChooseRandomSpawn();
        }
        else
        {
            forbiddenIndex.Add(random);            
        }
        return random;
    }
}
