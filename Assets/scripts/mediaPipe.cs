using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class mediaPipe : MonoBehaviour
{
    public bool modifyPosition;
    [Range(1, 20)] public float resize_z;

    public List<Vector3> pose;
    private List<Vector3> lawPos;

    // Start is called before the first frame update
    void Start()
    {
        //lawPos = new List<Vector3>();
        //FileStream f = new FileStream("Assets/mediaPipe_output.txt", FileMode.Open);
        //StreamReader fileStreamReader = new StreamReader(f);
        //for (int i = 0; i < 33; i++)
        //{
        //    string line = fileStreamReader.ReadLine();
        //    string[] words = line.Split(',');
        //    float x, y, z;
        //    x = float.Parse(words[0].Substring(0, 7));
        //    y = float.Parse(words[1].Substring(0, 7));
        //    z = float.Parse(words[2].Substring(0, 7));
        //    //z = float.Parse(words[2][..7]);
        //    lawPos.Add(new Vector3(x, y, z));

        //}

        //pos = new List<Vector3>(new Vector3[33]);

        //transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //for (int i = 0; i < pos.Count; i++)
        //{
        //    transform.GetChild(i).localPosition = new Vector3(lawPos[i].x * 10, -lawPos[i].y * 10, -lawPos[i].z * resize_z) * 5;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //DataReceiver.Instance.Load();
        //for (int i = 0; i < pos.Count; i++)
        //{
        //    if (!modifyPosition)
        //        transform.GetChild(i).localPosition = new Vector3(lawPos[i].x * 10, -lawPos[i].y * 10, -lawPos[i].z * resize_z) * 5;

        //    pos[i] = transform.GetChild(i).localPosition;
        //}
    }

    private void LateUpdate()
    {
        //pose = new List<Vector3>(DataReceiver.Instance.getPose());
        
        //for (int i=0; i <pose.Count; i++)
        //{
        //    transform.GetChild(i).localPosition = pose[i];

        //}
    }
}
