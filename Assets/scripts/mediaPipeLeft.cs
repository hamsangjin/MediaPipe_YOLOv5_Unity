using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediaPipeLeft : MonoBehaviour
{
    private List<Vector3> right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        right = new List<Vector3>(DataReceiver.Instance.getRight(0));
        right[0] = new Vector3(right[0].x, right[0].y, 0);
        for (int i = 0; i < right.Count; i++)
        {
            transform.GetChild(i).localPosition = right[i] * 2;
        }

    }
}
