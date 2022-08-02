using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderMovement : MonoBehaviour
{
    Slider slMovement;

    // Start is called before the first frame update
    void Start()
    {
        slMovement = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다. ---- 다른 스크립트에 추가하기
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            slMovement.value += 1;
        }

        // 성공 시
        if(slMovement.value == slMovement.maxValue)
        {
            SceneManager.LoadScene("FailEnding4");
        }
    }
}
