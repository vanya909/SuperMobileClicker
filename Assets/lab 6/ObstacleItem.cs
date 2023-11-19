using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [Range(0, 1)]
    public float currentHealth = 1f;
    public float damage = 0f;
    public Color fullHealthColor = Color.white;
    public Color zeroHealthColor = Color.red;

    public UnityEvent onDestroyObstacle;
    private float maxHealth = 1f;
    private Renderer obstacleRenderer;

    public void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
    }

    [ContextMenu("GetDamage")]
    private void GetDamage2()
    {
        GetDamage(damage);
    }

    public void GetDamage(float value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;
            UpdateColor();

            if (currentHealth <= 0)
            {
                StartCoroutine(DestroyAfterColorChange());
                currentHealth = 0;
            }
        }
    }

    private void UpdateColor()
    {
        Color targetColor = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth);

        StartCoroutine(ChangeColorOverTime(targetColor));
    }

    private IEnumerator ChangeColorOverTime(Color targetColor)
    {
        float elapsedTime = 0f;
        Color startColor = obstacleRenderer.material.color;

        while (elapsedTime < maxHealth)
        {
            obstacleRenderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / maxHealth);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obstacleRenderer.material.color = targetColor;
    }

    private IEnumerator DestroyAfterColorChange()
    {
        yield return StartCoroutine(ChangeColorOverTime(zeroHealthColor));
        onDestroyObstacle.Invoke();
        Destroy(gameObject);
    }
}


