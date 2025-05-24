using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RuntimeObjectDestroyer : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void DestroyObjects()
    {
        string objectName = "Возобновить"; // Имя объекта
        GameObject[] targets = GameObject.FindObjectsOfType<GameObject>()
            .Where(obj => obj.name == objectName)
            .ToArray();

        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }
}