using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    private ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpwanBullet()
    {
        GameObject bullet = objectPool.SpwanFromPool("Bullet");
    }
}
