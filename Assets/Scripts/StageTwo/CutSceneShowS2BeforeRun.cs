using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneShowS2BeforeRun : MonoBehaviour
{
    // 현재 시간
    public float currentTime;

    // 일정 시간
    public float CreateTime = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        if(currentTime >= CreateTime)
        {
            SceneManager.LoadScene("S2Run");
        }
    }
}
