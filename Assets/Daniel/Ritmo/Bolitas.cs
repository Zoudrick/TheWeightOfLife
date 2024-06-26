using UnityEngine;
using System.Collections;

public class Bolitas : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // Duración del fade-in
    public Vector3 initialScale = new Vector3(0.5f, 0.5f, 0.5f); // Tamaño inicial del objeto
    public Vector3 targetScale = new Vector3(1f, 1f, 1f); // Tamaño final del objeto

    private SpriteRenderer spriteRenderer;

    public float velocidadBolita;

    private void Update()
    {
        transform.Translate(Vector3.left * velocidadBolita);
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = initialScale; // Comienza con el tamaño inicial
        if (spriteRenderer != null)
        {
            StartCoroutine(FadeInAndScale());
        }
    }

    private IEnumerator FadeInAndScale()
    {
        float elapsedTime = 0f;
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0f; // Comienza con transparencia total
        spriteRenderer.color = spriteColor;

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeInDuration);

            // Fade-in
            spriteColor.a = t;
            spriteRenderer.color = spriteColor;

            // Scaling
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            yield return null;
        }

        // Asegúrate de que el sprite esté completamente opaco al final del fade-in
        spriteColor.a = 1f;
        spriteRenderer.color = spriteColor;

        // Asegúrate de que el objeto esté en su tamaño final
        transform.localScale = targetScale;
    }
}