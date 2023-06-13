using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPre;
    public GameObject coinPre;
    public GameObject conePre;
    private int startPos = 80;
    private int goalPos = 360;
    private float posRange = 3.4f;
    private GameObject unitychan;
    private List<GameObject> spawnedObjects;
  
    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        spawnedObjects = new List<GameObject>();    


        for (int i = startPos; i < goalPos; i += 15)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePre);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    spawnedObjects.Add(cone);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPre);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        spawnedObjects.Add(coin);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPre);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        spawnedObjects.Add(car);
                    }
                }

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            GameObject obj = spawnedObjects[i];
            if (obj != null)
            {
                if (obj.transform.position.z < unitychan.transform.position.z - 10f)
                {
                    spawnedObjects.RemoveAt(i);
                    Destroy(obj);
                }
            }
            else
            {
                spawnedObjects.RemoveAt(i);
            }
        }
    }
}