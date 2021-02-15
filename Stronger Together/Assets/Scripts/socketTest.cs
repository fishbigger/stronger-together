using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Sockets;

public class socketTest : MonoBehaviour
{
    public string ip = "127.0.0.1";
    public int port = 65432;
    private Socket client;

    void Start()
    {
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ip, port);

        //byte[] recv = client.Receive();

        
    }

    string positionToString(Transform pos)
    {
        float x = pos.position.x;
        float y = pos.position.y;
        float z = pos.position.z;

        string strX = x.ToString();
        string strY = y.ToString();
        string strZ = z.ToString();

        return strX + '_' + strY + '_' + strX;
    }

    public void sendPos(Transform transform)
    {
        client.Send(System.Text.Encoding.UTF8.GetBytes(positionToString(transform)));

        Debug.Log(positionToString(transform));
    }

    void OnApplicationQuit()
    {
        client.Send(System.Text.Encoding.UTF8.GetBytes("DISCONNECTED"));
    }
}