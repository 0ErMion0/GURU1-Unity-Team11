using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeStageTwoToStageThree : MonoBehaviour
{
    //GameObject S2BackGroundMusic;
    //AudioSource S2backMusic;

    public void SceneChange()
    {
        SceneManager.LoadScene("StageThree"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //// 1. DontDestroy �� ������Ʈ ã��
        //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //S2backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //S2backMusic.Stop();
    }

}
