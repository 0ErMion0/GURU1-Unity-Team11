using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeGameOverToInfiniteMode : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("InfiniteMode"); // ��ȣ �� ��ȯ�� scene �̸� ����
    }

}
