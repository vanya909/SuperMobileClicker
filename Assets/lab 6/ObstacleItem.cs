using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue = 1f;
    public UnityEvent onDestroyObstacle;

    public void GetDamage(float value)
    {
        // Реализация GetDamage
    }

    private void UpdateColor()
    {
        // Реализация изменения цвета с плавным переходом
    }
}

