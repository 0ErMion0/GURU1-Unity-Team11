using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeHomeScreenToOption : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Option"); // ��ȣ �� ��ȯ�� scene �̸� ����
    }


    void Start()
    {

    }


    void Update()
    {

    }
}