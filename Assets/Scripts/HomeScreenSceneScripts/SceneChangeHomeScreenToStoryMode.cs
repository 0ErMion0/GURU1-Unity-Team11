using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

public class SceneChangeHomeScreenToStoryMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("StoryMode"); // 괄호 속 전환할 scene 이름 적기

    }


    void Start()
    {
    }

    
    void Update()
    {
        
    }
}
