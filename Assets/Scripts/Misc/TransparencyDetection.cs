using System.Collections;
using UnityEngine;

public class TransparencyDetection : MonoBehaviour
{
    private const float FULL_NON_TARNCPSRENT = 1.0f;

    [Range(0f, 1f)] 
    [SerializeField] private float transperancyAmount = 0.8f;
    [SerializeField] private float fadeTime = 0.5f;
    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Player>() && collider is CapsuleCollider2D)
        {
            StartCoroutine(FadeRoutine(_spriteRenderer, fadeTime, _spriteRenderer.color.a, transperancyAmount));
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Player>() && collider is CapsuleCollider2D)
        {
            StartCoroutine(FadeRoutine(_spriteRenderer, fadeTime, _spriteRenderer.color.a, FULL_NON_TARNCPSRENT));
        }
    }

    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startTransporencyAmount, float targetTransporencyAmount)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startTransporencyAmount, targetTransporencyAmount, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);

            yield return null;
        }
    }
}
