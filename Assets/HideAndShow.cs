using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HideAndShow : MonoBehaviour
{
    List<GameObject> gameObjects = new List<GameObject>();    
    List<int> gameObjectIDs = new List<int>();    
    // Start is called before the first frame update
    void Start()
    {
        gameObjects.Add(GameObject.Find("model1"));
        gameObjects.Add(GameObject.Find("model2"));
        gameObjects.Add(GameObject.Find("model3"));
        gameObjects.Add(GameObject.Find("model4"));

        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].GetComponent<HumanBodyBone>().ID = i;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        for (int i=0; i<gameObjects.Count; i++)
        {
            if ( i < DataReceiver.Instance.getDataLength())
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
