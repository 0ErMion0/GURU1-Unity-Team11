using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    // 와이어 컬러 열거형 타입 이용한 프로퍼티 선언하고 색 입힘
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    // 다음으로 넘어가기 위한 점수 추가
    //public int PlusNext;

    [SerializeField]
    private List<Image> mWireImages;

    [SerializeField]
    private Image mLightImage;

    [SerializeField]
    private List<LeftWire> mConnectedWires = new List<LeftWire>();

    private void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
    }

    public void SetWireColor(EWireColor wireColor)
    {
        WireColor = wireColor;
        Color color = Color.black;
        switch (WireColor)
        {
            case EWireColor.Magenta:
                color = Color.magenta;
                break;

            case EWireColor.Blue:
                color = Color.blue;
                break;

            case EWireColor.Yellow:
                color = Color.yellow;
                break;

            case EWireColor.Gray:
                color = Color.gray;
                break;
        }

        foreach (var image in mWireImages)
        {
            image.color = color;
        }
    }

    // 연결 상태 함수
    // right 와이어엔 여러개의 전선 연결 가능하기 때문에 그 개수를 제한 필요
    public void ConnectWire(LeftWire leftWire)
    {
        if(mConnectedWires.Contains(leftWire))
        {
            return;
        }

        mConnectedWires.Add(leftWire);
        if(mConnectedWires.Count == 1 && leftWire.WireColor == WireColor)
        {
            mLightImage.color = Color.white;
            IsConnected = true;

            
        }
        else
        {
            mLightImage.color = Color.black;
            IsConnected = false;
        }
    }

    public void DisconnectWire(LeftWire leftWire)
    {
        mConnectedWires.Remove(leftWire);

        if(mConnectedWires.Count == 1 && mConnectedWires[0].WireColor == WireColor)
        {
            mLightImage.color = Color.white;
            IsConnected = true;
        }
        else
        {
            mLightImage.color = Color.black;
            IsConnected = false;
        }
    }
}
