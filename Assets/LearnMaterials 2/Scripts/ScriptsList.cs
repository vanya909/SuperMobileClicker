using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsList : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> _scripts;

    void Start()
    {
        // Добавьте все объекты с компонентом SampleScript в список
        _scripts.AddRange(FindObjectsOfType<SampleScript>());
    }

    [ContextMenu("UseAll")]
    public void UseAll()
    {
        foreach (var script in _scripts)
            script.Use();
    }
}


