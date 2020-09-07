using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] vidas;
    public Image imagemVida;

    public Text PontosTexto;

    public int Pontos;

    public void AtualizarVidas(int vidaCorrente) 
    {
        imagemVida.sprite = vidas[vidaCorrente];    
    }

    public void AtualizarScore() 
    {
        Pontos += 10;
        PontosTexto.text = $"Pontos:{Pontos}";
    }


}
