using UnityEngine;

public class ControladorPorta : MonoBehaviour
{
    private bool estaAberta = false;

    // Referência à posição do player
    public Transform cameraDoJogo; 

    // Referência ao botão
    public Transform botaoDaParede; 

    void Update()
    {
        // Validação de segurança para evitar exceções de referência nula
        if (cameraDoJogo == null || botaoDaParede == null) return;

        // Cálculo da distância entre o player e o botão
        float distancia = Vector3.Distance(cameraDoJogo.position, botaoDaParede.position);

        // Se o player chegar a menos de 2 metros do botão, a porta abre sozinha
        if (distancia < 2.0f && estaAberta == false)
        {
            transform.Translate(2.5f, 0f, 0f); // Move a porta para o lado, liberando a passagem
            estaAberta = true;
            Debug.Log("Porta Aberta");
        }
        // Se o player afastar mais de 3.5 metros do botão, a porta fecha
        else if (distancia > 3.5f && estaAberta == true)
        {
            transform.Translate(-2.5f, 0f, 0f); // Move a porta para a posição inicial, bloqueando a passagem
            estaAberta = false;
            Debug.Log("Porta Fechada");
        }
    }
}