using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour {

    public static DebugText instance;
    public TextMesh Mesh;
    public string text="";
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        Mesh.text = text;
    }
}
