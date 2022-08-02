using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    // ���̾� �÷� ������ Ÿ�� �̿��� ������Ƽ �����ϰ� �� ����
    public EWireColor WireColor { get; private set; }

    public bool IsConnected { get; private set; }

    // �������� �Ѿ�� ���� ���� �߰�
    //public int PlusNext;

    [SerializeField]
    private List<Image> mWireImages;

    [SerializeField]
    private Image mLightImage;

    [SerializeField]
    private List<LeftWire> mConnectedWires = new List<LeftWire>();

    private void Update()
    {
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
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

    // ���� ���� �Լ�
    // right ���̾ �������� ���� ���� �����ϱ� ������ �� ������ ���� �ʿ�
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
