using UnityEngine;

public class ColorButton : MonoBehaviour
{
    private ColorMixing colorMixingScript;

    private void Start()
    {
        // ColorMixing scriptine eriþim saðla
        colorMixingScript = FindObjectOfType<ColorMixing>();
    }

    private void OnMouseDown()
    {
        // Fare tuþuna basýldýðýnda çalýþacak kodlar
        if (colorMixingScript != null)
        {
            // Örnek bir fonksiyon çaðrýsý, bu fonksiyonu ColorMixing scriptinizde tanýmlamalýsýnýz
            colorMixingScript.OnButtonPressed(gameObject.tag);
        }
    }

    private void OnMouseUp()
    {
        // Fare tuþundan el çekildiðinde çalýþacak kodlar
        if (colorMixingScript != null)
        {
            // Örnek bir fonksiyon çaðrýsý, bu fonksiyonu ColorMixing scriptinizde tanýmlamalýsýnýz
            colorMixingScript.OnButtonReleased(gameObject.tag);
        }
    }
}