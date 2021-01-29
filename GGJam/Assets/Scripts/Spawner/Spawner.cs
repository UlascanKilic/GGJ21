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
    public List<string> obstacleNames;
    private int counter = 0;
    void Start()
    {
        obstacleNames = new List<string>();
        collectibleNames = new List<string>();

        childPoints = new List<Transform>();

        foreach(GameObject child in collectibles)
        {
            collectibleNames.Add(child.name+"(Clone)");
        }
        foreach (GameObject child in objects)
        {
            obstacleNames.Add(child.name + "(Clone)");
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
            Instantiate(collectibles[i], targetPosition, collectibles[i].transform.rotation);
            childPoints.RemoveAt(random);
        }

        for(int i = 0;i < objects.Count; i++)//kalan yerlere objectleri yerleştiricem
        {
            random = Random.Range(0, childPoints.Count);
            targetPosition = childPoints[random].transform.position;
            Instantiate(objects[i], targetPosition, objects[i].transform.rotation);
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
