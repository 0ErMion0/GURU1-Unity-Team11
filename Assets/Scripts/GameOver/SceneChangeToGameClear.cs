using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeToGameClear : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("GameClear"); // ��ȣ �� ��ȯ�� scene �̸� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
