using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneLog : MonoBehaviour
{

    static SceneLog()
    {
        print("created !!!");
    }
}
