using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeHomeScreenToInfiniteMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("InfiniteMode"); // ��ȣ �� ��ȯ�� scene �̸� ����
    }


    void Start()
    {

    }


    void Update()
    {

    }
}
