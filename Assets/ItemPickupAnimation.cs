using System.Collections;
using UnityEngine;

public class ItemPickupAnimation : MonoBehaviour
{
    [SerializeField] private float animationTime;
    [SerializeField] private float animationSpeed;
    [SerializeField] private AnimationCurve animationCurve;

    void Awake()
    {
        GetComponent<ItemPickup>().OnItemPickup.AddListener(StartAnimation);
    }

    private void StartAnimation(Transform target)
    {
        StartCoroutine(AnimationCoroutine(target));
    }

    private IEnumerator AnimationCoroutine(Transform target)
    {
        float time = 0;
        while (time < animationTime)
        {
            float percentage = time / animationTime;
            float speed = animationSpeed * animationCurve.Evaluate(percentage);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.localScale = Vector3.one * (1 - percentage);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}