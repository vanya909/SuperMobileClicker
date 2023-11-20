﻿using System.Collections;
using UnityEngine;

public class RotateScript : SampleScript
{
    [SerializeField]
    public Vector3 rotationAngles = new Vector3(0f, 0f, 0f);


    [Range(0, 60)]
    public float time = 10f;

    [ContextMenu("Rotate")]
    public override void Use()
    {
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        float currentTime = 0;
        Quaternion start = transform.rotation;
        Quaternion target = start * Quaternion.Euler(rotationAngles);

        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(start, target, currentTime / (time - 1));
            yield return null;
        }

    }
}
