using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeStoryModeToStageThree : MonoBehaviour
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    //GameObject S2BackGroundMusic;
    //AudioSource S2backMusic;

    public void SceneChange()
    {
        SceneManager.LoadScene("StageThree"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusic.Stop();


        //// 1. DontDestroy �� ������Ʈ ã��
        //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //S2backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //S2backMusic.Stop();
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
