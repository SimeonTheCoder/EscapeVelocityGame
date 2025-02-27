using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<string> keys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.keys = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey(string key)
    {
        this.keys.Add(key);
    }

    public bool CheckKey(string toFind)
    {
        return this.keys.Contains(toFind);
    }
}
