using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using System.Net.Sockets;
using System.Text;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using System.Xml.Schema;

public class DataReceiver : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public Vector3[] pose;
        public Vector3[] left;
        public Vector3[] right;
    }
    [System.Serializable]
    public class DataList
    {
        public Data[] data;
    }

    private static DataReceiver instance = null;
    public static DataReceiver Instance
    {
        get
        {
            if (instance == null)
                return null;

            else
                return instance;
        }
    }

    // 서버의 IP 주소와 포트 번호 설정
    string serverIP = "127.0.0.1"; // 서버의 실제 IP 주소로 대체
    int serverPort = 25001; // 파이썬 서버와 동일한 포트 번호

    // 데이터를 받을 버퍼 설정
    byte[] buffer = new byte[102400];
    int bytesRead;

    NetworkStream stream;
    TcpClient client;
    string dataReceived;
    private DataList m_dataList = new DataList();

    [Range(1, 20)]
    public float resize_z = 15;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        // 서버에 연결
        client = new TcpClient(serverIP, serverPort);
        stream = client.GetStream();
    }
    // Update is called once per frame
    private void Update()
    {
        Load();
        preprocessing();
    }

    void OnDestroy()
    {
        stream.Close();
        client.Close();
    }

    private void Load()
    {
        //dataReceived = null;
        bytesRead = stream.Read(buffer, 0, buffer.Length);
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if (dataReceived.Length < 1)
            Debug.Log("Received data is too short. pleaes check data. (Load)");

        //Debug.Log(dataReceived);
        else
            m_dataList = JsonUtility.FromJson<DataList>(dataReceived);
    }

    public void preprocessing()
    {
        foreach (var item in m_dataList.data)
        {
            for (int i = 0; i < item.pose.Length; ++i)
                item.pose[i] = new Vector3(item.pose[i].x * 10, -item.pose[i].y * 10, -item.pose[i].z * resize_z);

            //for (int i = 0; i < item.face.Length; ++i)
            //    item.face[i] = new Vector3(item.face[i].x * 10, -item.face[i].y * 10, -item.face[i].z * resize_z);

            if (item.left.Length > 0)
            {
                item.left[0].z = 0; // 0번의 실제 z 값이 매우 이상함, -52 처럼 멀리 떨어져있음

                for (int i = 0; i < item.left.Length; ++i)
                    item.left[i] = new Vector3(item.left[i].x * 10, -item.left[i].y * 10, -item.left[i].z * resize_z);
            }

            if (item.right.Length > 0)
            {
                item.right[0].z = 0;

                for (int i = 0; i < item.right.Length; ++i)
                    item.right[i] = new Vector3(item.right[i].x * 10, -item.right[i].y * 10, -item.right[i].z * resize_z);
            }

        }
    }

    public int getDataLength()
    {
        return m_dataList.data.GetLength(0);
    }

    public Vector3[] getPose(int idx)
    {
        return m_dataList.data[idx].pose;
    }
    public Vector3[] getLeft(int idx)
    {
        return m_dataList.data[idx].left;
    }

    public Vector3[] getRight(int idx)
    {
        return m_dataList.data[idx].right;
    }
    //public List<Vector3> preprocessingPose()
    //{
    //    List<Vector3> ret = new List<Vector3>();
    //    for (int i = 0; i < data.pose.Length; ++i)
    //        ret.Add(new Vector3(data.pose[i].x * 10, -data.pose[i].y * 10, -data.pose[i].z * resize_z));

    //    return ret;
    //}

    //public List<Vector3> preprocessingFace()
    //{
    //    List<Vector3> ret = new List<Vector3>();
    //    for (int i = 0; i < data.face.Length; ++i)
    //        ret.Add(new Vector3(data.face[i].x * 10, -data.face[i].y * 10, -data.face[i].z * resize_z));

    //    return ret;
    //}
    //public List<Vector3> preprocessingLeft()
    //{
    //    List<Vector3> ret = new List<Vector3>();
    //    for (int i = 0; i < data.left.Length; ++i)
    //        ret.Add(new Vector3(data.left[i].x * 10, -data.left[i].y * 10, -data.left[i].z * resize_z));

    //    return ret;
    //}
    //public List<Vector3> preprocessingRight()
    //{
    //    List<Vector3> ret = new List<Vector3>();
    //    for (int i = 0; i < data.right.Length; ++i)
    //        ret.Add(new Vector3(data.right[i].x * 10, -data.right[i].y * 10, -data.right[i].z * resize_z));

    //    return ret;
    //}
}
