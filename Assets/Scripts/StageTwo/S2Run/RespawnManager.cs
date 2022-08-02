using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> EnemyPool = new List<GameObject>();
    public GameObject[] Enemys;

    public int objCnt = 1;
    int count = 0;

    void Awake()
    {
        for(int i=0;i<Enemys.Length;i++)
        {
            for(int j=0;j<objCnt;j++)
            {
                EnemyPool.Add(CreateObj(Enemys[i], transform));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMob());
        StartCoroutine(AddCount());
    }

    IEnumerator AddCount()
    {
        while (true)
        {
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CreateMob()
    {
        while(true)
        {
            EnemyPool[DeactiveEnemy()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    int DeactiveEnemy()
    {
        List<int> num = new List<int>();

        for(int i=0;i<EnemyPool.Count;i++)
        {
            if(!EnemyPool[i].activeSelf)
            {
                num.Add(i);
            }
        }
        int x = 0;

        if (num.Count>0)
        {
            x = num[Random.Range(0, num.Count)];

        }

        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }


    // Update is called once per frame
    void Update()
    {
        if (count > 35)
        {
            StopAllCoroutines();
        }
    }
}
