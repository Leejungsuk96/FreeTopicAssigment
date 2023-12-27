using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    [SerializeField] private GameObject poolingObjectPrefabs;
    private Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetBullet(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Bullet CreateBullet()
    {
        var newBullet = Instantiate(poolingObjectPrefabs, transform).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void SetBullet(int count)
    {
        for(int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateBullet());
        }
    }

    public Bullet GetBullet()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var Bullet = Instance.poolingObjectQueue.Dequeue();
            Bullet.transform.SetParent(null);
            Bullet.gameObject.SetActive(true);
            return Bullet;
        }
        else
        {
            var newBullet = Instance.CreateBullet();
            newBullet.transform.SetParent(null);
            newBullet.gameObject.SetActive(true);
            return newBullet;
        }
    }

    public static void RetrunBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(bullet);
    }
}
