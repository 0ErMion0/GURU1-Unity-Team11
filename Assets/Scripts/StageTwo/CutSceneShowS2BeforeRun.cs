using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneShowS2BeforeRun : MonoBehaviour
{
    // ���� �ð�
    public float currentTime;

    // ���� �ð�
    public float CreateTime = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        currentTime += Time.deltaTime;

        if(currentTime >= CreateTime)
        {
            SceneManager.LoadScene("S2Run");
        }
    }
}
