using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

//public class SceneChangeStoryModeToStageOne<T> : MonoBehaviour where T : MonoBehaviour // 2

public class SceneChangeStoryModeToStageOne : MonoBehaviour // 1
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    //pirvate static object BackGroundMusicControl = new object(); // 2

    //1
    public void SceneChange()
    {
        SceneManager.LoadScene("StageOne"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusic.Stop();
    }

    //// 2 
    //public static T Instance
    //{
    //    get
    //    {
    //        if()
    //    }
    //}
}
