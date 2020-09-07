using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] vidas;
    public Image imagemVida;

    public void AtualizarVidas(int vidaCorrente) 
    {
        imagemVida.sprite = vidas[vidaCorrente];    
    }

    public void AtualizarScore() { }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
