using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeHomeScreenToInfiniteMode : MonoBehaviour
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    public void SceneChange()
    {
        SceneManager.LoadScene("InfiniteMode"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusic.Stop();
    }


    void Start()
    {

    }


    void Update()
    {

    }
}
