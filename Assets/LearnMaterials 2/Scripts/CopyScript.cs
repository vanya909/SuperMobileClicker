using System.Collections;
using UnityEngine;

public class CopyScript : SampleScript
{
    [SerializeField, Min(0)]
    public int count;

    [SerializeField, Min(0)]
    public int step;

    [ContextMenu("Copy")]
    public override void Use()
    {
        StartCoroutine(CopyTarget());
    }

    private IEnumerator CopyTarget()
    {
        var currentObject = gameObject;

        while (count > 0)
        {
            var copy = Instantiate(currentObject);
            copy.transform.Translate(Vector3.forward * step);
            count--;
            currentObject = copy;
            yield return null;
        }
    }
}
