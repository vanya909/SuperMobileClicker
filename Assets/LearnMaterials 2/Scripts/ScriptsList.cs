using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsList : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> _scripts;

    public void UseAll()
    {
        foreach (var script in _scripts)
            script.Use();
    }
}
