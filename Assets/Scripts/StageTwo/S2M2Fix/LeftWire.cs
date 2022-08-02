using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftWire : MonoBehaviour
{
    // 와이어 컬러 열거형 타입 이용한 프로퍼티 선언하고 색 입힘
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    [SerializeField] 
    private List<Image> mWireImages;

    [SerializeField]
    private Image mLightImage;

    [SerializeField]
    private RightWire mConnectedWire;

    [SerializeField]
    private RectTransform mWireBody;

    //private LeftWire mSelectedWire;

    [SerializeField]
    //private float offset = 15f;

    private Canvas mGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mGameCanvas = FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        } 
    }

    // LeftWire가 자체적으로 처리해야되는 코드를 함수로 따로 뺌
    public void SetTarget(Vector3 targetPosition, float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
                 targetPosition - transform.position);
        float distance = Vector2.Distance(mWireBody.transform.position, targetPosition) - offset;
        mWireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        // 게임 해상도 달라질 때마다 변경되는 캠버스 크기 때문에 distance 일치하지 않는 문제 해결 위해
        // 캠버스 크기를 가져와서 distance에 역수 곱해줌
        mWireBody.sizeDelta = new Vector2(distance * (1 / mGameCanvas.transform.localScale.x), mWireBody.sizeDelta.y);
    }

    // reset 타깃 함수 - 와이어의 위치와 각도 원상복구
    public void ResetTarget()
    {
        mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
        mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y);
    }
    
    // 매개변수로 받은 값 따라 색 바뀌도록
    public void SetWireColor(EWireColor wireColor)
    {
        WireColor = wireColor;
        Color color = Color.black;
        switch(WireColor)
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

        foreach(var image in mWireImages)
        {
            image.color = color;
        }
    }

    // 정확히 연결되면 맞음 불 들어오는거
    public void ConnectWire(RightWire rightWire)
    {
        // 연결된 와이어가 비어있지 않고 매개변수로 받은 오른쪽 와이어가 현재 연결된 와이어가 아니라면
        // 와이어 연결을 끝으로 어찌고
        if (mConnectedWire != null && mConnectedWire != rightWire)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }
        
        mConnectedWire = rightWire;
        if(mConnectedWire.WireColor == WireColor)
        {
            mLightImage.color = Color.white; // 이거 바꿔야될지도 초록이라던가 흰 white도 있다 소문자!!!!
            IsConnected = true;
        }
    }

    // 전선 끊어졌을 때 상태 원래대로 되돌리는
    public void DisconnectWire()
    {
        if(mConnectedWire != null)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }
        mLightImage.color = Color.black; // 불 꺼져있을 땐 블랙, 켜져있을 땐 화이트 설명은 gray, yellow로되어있었음
        IsConnected = false;
    }
}
