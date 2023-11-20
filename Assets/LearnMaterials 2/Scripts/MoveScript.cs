using System.Collections;
using UnityEngine;

public class MoveScript : SampleScript
{
    [SerializeField]
    private Vector3 _destination;

    [SerializeField, Min(0)]
    private float _speed;

    [ContextMenu("Move")]
    public override void Use()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(transform.position, _destination);

        while (Vector3.Distance(transform.position, _destination) > 0)
        {
            float distCovered = (Time.time - startTime) * _speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, _destination, fracJourney);
            yield return null;
        }
    }
}
