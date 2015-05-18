using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    NetClient client = new NetClient();

	// Use this for initialization
	void Start () 
    {
        client.Connect();
        Debug.Log("Connect...");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            client.SendData("测试一下");
        }
	}
}
