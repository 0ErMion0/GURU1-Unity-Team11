using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

public class SceneChangeStageOneToS1M1AlarmOffMission : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("S1M1AlarmOffMission"); // 괄호 속 전환할 scene 이름 적기
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
