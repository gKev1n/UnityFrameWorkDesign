using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader : MonoBehaviour
{
    private static readonly int PropertyA = Shader.PropertyToID("PropertyA");

    // Start is called before the first frame update
    void Start()
    {
        var shader = Shader.Find("Master/Toon");
        if (Shader.Find("Master/Toon"))
        {
            Debug.Log("true");
        }
        var material = new Material(shader);
        
        material.SetInt(PropertyA, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
