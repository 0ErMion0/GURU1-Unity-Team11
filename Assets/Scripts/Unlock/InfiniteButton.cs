using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteButton : MonoBehaviour
{
    public int nextStage;

    // Start is called before the first frame update
    void Start()        //StageTwo/StageThree ���� �ִ� ������Ʈ �Ҽ�
    {
        nextStage = SceneManager.GetActiveScene().buildIndex;           //nextStage�� ���� �� ��ȣ �޾ƿ�(25/26)

        if (nextStage > PlayerPrefs.GetInt("InfiniteAct"))                 //nextStage(25/26)�� StageAct(ù ���࿡ 24)���� Ŭ ��� 
            PlayerPrefs.SetInt("InfiniteAct", nextStage);                  //StageAct�� nextStage�� �ٲ� (PlayerPrefs ��������Ƿ� �� ����) 
    }                                                                   //���� LevelSelction ��ũ��Ʈ �ݺ����� ���� ���� â���� ���ư��� �� 2/3�� Ȱ��ȭ��

    // Update is called once per frame
    void Update()
    {

    }
}