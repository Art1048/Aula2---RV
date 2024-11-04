using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJumpTrapController : MonoBehaviour
{
    public float targetScaleY = 2.0f; // A escala alvo no eixo Y
    public float duration = 2.0f; // Duração para alcançar a escala alvo
    private Vector3 initialScale; // Armazena a escala inicial

    void Start()
    {
        // Armazena a escala inicial do objeto
        initialScale = transform.localScale;

        // Inicia a coroutine após 3 segundos
        StartCoroutine(ScaleUpCoroutine());
    }

    private IEnumerator ScaleUpCoroutine()
    {
        // Aguarda 3 segundos
        yield return new WaitForSeconds(3.0f);

        float elapsedTime = 0f; // Tempo decorrido
        Vector3 targetScale = new Vector3(initialScale.x, targetScaleY, initialScale.z); // Escala alvo

        // Enquanto o tempo decorrido for menor que a duração
        while (elapsedTime < duration)
        {
            // Aumenta a escala com base no tempo
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime; // Aumenta o tempo decorrido
            yield return null; // Aguarda até o próximo frame
        }

        // Garante que a escala final seja exatamente a escala alvo
        transform.localScale = targetScale;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource somMorte = GetComponent<AudioSource>();
            Destroy(other.gameObject);
            somMorte.Play();
            
        }

    }
}
