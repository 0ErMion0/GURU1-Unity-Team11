using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeHomeScreenToStoryMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("StoryMode"); // ��ȣ �� ��ȯ�� scene �̸� ����
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
