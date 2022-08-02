using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SliderOff : MonoBehaviour
{
    Slider slOff;

    //GameObject S1ToS1M1BackGroundMusic;
    //AudioSource backMusic;

    // Start is called before the first frame update
    void Start()
    {
        slOff = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�. ---- �ٸ� ��ũ��Ʈ�� �߰��ϱ�
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (slOff.value == 1) // �����̰� 1�� �ִٸ�
        {
            // ���� ȭ������ �Ѿ��
            //Debug.Log("haha");
            SceneManager.LoadScene("S1M2FindMission");

            //// 1. DontDestroy �� ������Ʈ ã��
            //S1ToS1M1BackGroundMusic = GameObject.Find("S1ToS1M1BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S1ToS1M1BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }

        
    }
}
