using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    
    public struct Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictonary;
    // Start is called before the first frame update

    private void Awake()
    {
        poolDictonary = new Dictionary<string, Queue<GameObject>>();
        foreach(var pool in pools)
        {
            Queue<GameObject> bulletPool = new Queue<GameObject>();
            for( int i = 0; i< pool.size; i++)
            {
                GameObject bullet = Instantiate(pool.prefab);
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
            poolDictonary.Add(pool.tag, bulletPool);
        }
    }

    public GameObject SpwanFromPool(string tag)
    {
        if (!poolDictonary.ContainsKey(tag))
        {
            return null;
        }

        GameObject bullet = poolDictonary[tag].Dequeue();
        poolDictonary[tag].Enqueue(bullet);

        return bullet;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
