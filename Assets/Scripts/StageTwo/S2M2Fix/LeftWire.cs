using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftWire : MonoBehaviour
{
    // ���̾� �÷� ������ Ÿ�� �̿��� ������Ƽ �����ϰ� �� ����
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
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        } 
    }

    // LeftWire�� ��ü������ ó���ؾߵǴ� �ڵ带 �Լ��� ���� ��
    public void SetTarget(Vector3 targetPosition, float offset)
    {
        float angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
                 targetPosition - transform.position);
        float distance = Vector2.Distance(mWireBody.transform.position, targetPosition) - offset;
        mWireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        // ���� �ػ� �޶��� ������ ����Ǵ� ķ���� ũ�� ������ distance ��ġ���� �ʴ� ���� �ذ� ����
        // ķ���� ũ�⸦ �����ͼ� distance�� ���� ������
        mWireBody.sizeDelta = new Vector2(distance * (1 / mGameCanvas.transform.localScale.x), mWireBody.sizeDelta.y);
    }

    // reset Ÿ�� �Լ� - ���̾��� ��ġ�� ���� ���󺹱�
    public void ResetTarget()
    {
        mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
        mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y);
    }
    
    // �Ű������� ���� �� ���� �� �ٲ��
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

    // ��Ȯ�� ����Ǹ� ���� �� �����°�
    public void ConnectWire(RightWire rightWire)
    {
        // ����� ���̾ ������� �ʰ� �Ű������� ���� ������ ���̾ ���� ����� ���̾ �ƴ϶��
        // ���̾� ������ ������ �����
        if (mConnectedWire != null && mConnectedWire != rightWire)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }
        
        mConnectedWire = rightWire;
        if(mConnectedWire.WireColor == WireColor)
        {
            mLightImage.color = Color.white; // �̰� �ٲ�ߵ����� �ʷ��̶���� �� white�� �ִ� �ҹ���!!!!
            IsConnected = true;
        }
    }

    // ���� �������� �� ���� ������� �ǵ�����
    public void DisconnectWire()
    {
        if(mConnectedWire != null)
        {
            mConnectedWire.DisconnectWire(this);
            mConnectedWire = null;
        }
        mLightImage.color = Color.black; // �� �������� �� ��, �������� �� ȭ��Ʈ ������ gray, yellow�εǾ��־���
        IsConnected = false;
    }
}
