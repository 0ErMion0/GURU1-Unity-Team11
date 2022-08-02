using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManagerIn3 : MonoBehaviour
{
    public List<GameObject> EnemyPool = new List<GameObject>();        //��������3 ��ֹ�����
    public GameObject[] Enemys;                                        //��������3 ��ֹ�

    public int objCnt = 1;
    int count = 0;

    GameObject smObject;
    public bool playC = true;

    void Awake()
    {
        for (int i = 0; i < Enemys.Length; i++)
        {
            for (int j = 0; j < objCnt; j++)
            {
                EnemyPool.Add(CreateObj(Enemys[i], transform));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
        StartCoroutine(AddCount());

        smObject = GameObject.Find("MenuManager");
    }

    IEnumerator AddCount()
    {
        while (true)
        {
            if(playC)
                count++;

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            if (playC)
                EnemyPool[DeactiveEnemy()].SetActive(true);

            yield return new WaitForSeconds(Random.Range(1.5f, 3f));      //���� �ð� > ��ֹ� ����
        }
    }

    int DeactiveEnemy()             //�������� Ȱ��ȭ
    {
        List<int> num = new List<int>();

        for (int i = 0; i < EnemyPool.Count; i++)
        {
            if (!EnemyPool[i].activeSelf)
            {
                num.Add(i);
            }
        }
        int x = 0;

        if (num.Count > 0)
        {
            x = num[Random.Range(0, num.Count)];

        }
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent)      //��ֹ� ����
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if (sm.play)
            playC = true;
        else
            playC = false;
    }
}
