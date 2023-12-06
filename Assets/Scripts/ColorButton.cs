using UnityEngine;

public class ColorButton : MonoBehaviour
{
    private ColorMixing colorMixingScript;

    private void Start()
    {
        // ColorMixing scriptine eri�im sa�la
        colorMixingScript = FindObjectOfType<ColorMixing>();
    }

    private void OnMouseDown()
    {
        // Fare tu�una bas�ld���nda �al��acak kodlar
        if (colorMixingScript != null)
        {
            // �rnek bir fonksiyon �a�r�s�, bu fonksiyonu ColorMixing scriptinizde tan�mlamal�s�n�z
            colorMixingScript.OnButtonPressed(gameObject.tag);
        }
    }

    private void OnMouseUp()
    {
        // Fare tu�undan el �ekildi�inde �al��acak kodlar
        if (colorMixingScript != null)
        {
            // �rnek bir fonksiyon �a�r�s�, bu fonksiyonu ColorMixing scriptinizde tan�mlamal�s�n�z
            colorMixingScript.OnButtonReleased(gameObject.tag);
        }
    }
}