using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }

    #region singleton
    static public Pools instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objcetPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
               GameObject obj =  Instantiate(pool.prefab);
                obj.SetActive(false);
                objcetPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.name, objcetPool);
        }
    }

    public GameObject Spawn(string name, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(name))
        {
            Debug.LogWarning(name + "non esiste tra le piscine, coglione");
            return null;
        }


       GameObject objToSpawn = poolDictionary[name].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

      IpooledObj pooledObj =  objToSpawn.GetComponent<IpooledObj>();

        if(pooledObj != null)
        {
            pooledObj.PoolStart();
        }


        poolDictionary[name].Enqueue(objToSpawn);

        return objToSpawn;
    }
}
