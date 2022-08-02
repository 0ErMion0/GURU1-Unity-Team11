using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 연결되어야 하는 전선 색 표시 배열
public enum EWireColor
{
    // 유니티에서 제공하는 색상11가지: Black, Blue, Cyan, Gray, Green, Magenta, Red, White, Yellow, Clear
    None = -1,
    Magenta,//Pink,
    Blue,
    Yellow,
    Gray //Brown
}

public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<LeftWire> mLeftWires;

    [SerializeField]
    private List<RightWire> mRightWires;

    // 현재 선택된 와이어 기억 위해 선언
    private LeftWire mSelectedWire;

    private void OnEnable()
    {
        List<int> numberPool = new List<int>();

        // Left
        for(int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        int index = 0;
        while(numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mLeftWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }

        // Right
        for (int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        index = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mRightWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        
         // 마우스 버튼 누르는 순간 Raycast를 쏴서 맞은 콜라이더의 부모에서 (up)leftwire를 찾아서
         // mSelectedWire로 설정해 줌
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);

            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if (left != null)
                {
                    mSelectedWire = left;
                }
            }
        }

        // 마우스 클릭을 떼는 순간
        // mWireBody의 각도, 거리 원상 복구 and mSelectedWire 비워주기
        if (Input.GetMouseButtonUp(0))
        {
            // 
            if (mSelectedWire != null)
            {
                // 클릭 떼는 순간 레이케스터 발사하고 rightwire 찾도록
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();
                        if (right != null)
                        {
                            mSelectedWire.SetTarget(hit.transform.position, 50f);
                            mSelectedWire.ConnectWire(right);
                            right.ConnectWire(mSelectedWire);

                            mSelectedWire = null;
                            CheckCompleteTask(); // 와이어가 끊어지고 연ㄱㄹ되는 순간마다 검사하도록 update안에
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire.DisconnectWire();
                //mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
                //mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y); 
                mSelectedWire = null;
                CheckCompleteTask();
            }
        }


        // mSelectedWire가 비어있지 않은 동안에는 오브젝트의 위치와 마우스 커서의 위치를 이용해서
        // 전선이 움직일 각도와 거리 계산 후 WireBody에 적용하도록 
        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, 30f);
        }
    }

    private void CheckCompleteTask()
    {
        bool isAllComplete = true;
        foreach (var wire in mLeftWires)
        {
            if(!wire.IsConnected)
            {
                isAllComplete = false;
                break;
            }
        }

        if(isAllComplete)
        {
            SceneManager.LoadScene("FailEnding5");
        }
    }
}
