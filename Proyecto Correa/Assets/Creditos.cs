using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    private TMP_Text _text; 
    
    public IEnumerator Credits()
    {
        // 2. Fade in del texto
        _text.text = "PROYECTO CORREA";

        // 3. Mantener el texto en pantalla
        yield return new WaitForSeconds(5);

        _text.text = "";

        // 4. Fade out del texto
        yield return new WaitForSeconds(2);

        // 5. Espera antes de hacer el fade out del fondo
        _text.text = "DISEÑADO POR TODOS Y DESARROLLADO POR JAVIER TIRADO Y JAIME VICENTE";

        // 6. Fade out del fondo
        yield return new WaitForSeconds(5);

        _text.text = "";

        // 7. Activar medidores
        yield return new WaitForSeconds(2);

        _text.text = "CASI TODO EL ARTE POR LUIS PARRES";
        
        
        yield return new WaitForSeconds(5);

        _text.text = "";

        // 7. Activar medidores
        yield return new WaitForSeconds(2);

        _text.text = "AGRADECIMIENTOS A ANDY";

        yield return new WaitForSeconds(5);

        _text.text = "";
        
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene(0);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
