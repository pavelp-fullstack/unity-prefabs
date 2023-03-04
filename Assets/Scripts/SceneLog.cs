using UnityEditor;
using UnityEngine;
using System;

[InitializeOnLoad]
public class SceneLog : MonoBehaviour
{

    static SceneLog()
    {
        print("created !!!");
    }
}
