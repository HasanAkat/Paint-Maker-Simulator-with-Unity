using UnityEngine;

public class ColorMixing : MonoBehaviour
{
    private Renderer objRenderer;
    private Color currentColor; // �u anki obje rengi
    private bool isButtonPressed = false; // Buton bas�l� durumu
    private string currentButtonTag; // �u an bas�l� olan butonun etiketi
    private bool isFirstClick = true; // �lk t�klama kontrol bayra��

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        // Ba�lang��ta objenin rengini almak yerine, varsay�lan bir renk atayabiliriz.
        // Bu �rnekte, beyaz rengi varsay�lan olarak kullanal�m.
        currentColor = Color.white;
    }

    private void Update()
    {
        // E�er buton bas�l�ysa, MixColor fonksiyonunu �a��r
        if (isButtonPressed)
        {
            // Renk kar��t�rma i�lemi burada ger�ekle�tiriliyor
            MixColor(); // �rnek bir fonksiyon �a�r�s�
        }
    }

    public void OnButtonPressed(string buttonTag)
    {
        isButtonPressed = true;
        currentButtonTag = buttonTag;

        // �lk t�klama ise, rengi g�ncelle
        if (isFirstClick)
        {
            
            currentColor = GetColorBasedOnButtonTag(currentButtonTag);
            isFirstClick = false; // �lk t�klama ger�ekle�ti, bayra�� de�i�tir
        }

    }

    public void OnButtonReleased(string buttonTag)
    {
        isButtonPressed = false;
    }
    private void MixColor()
    {
        Color colorToAdd = GetColorBasedOnButtonTag(currentButtonTag);
        float mixSpeed = 0.0001f; // Renk kar���m h�z�, iste�e ba�l� olarak de�i�tirilebilir
        Color newColor = MixColors(currentColor, colorToAdd, mixSpeed);
        objRenderer.material.color = newColor;
        currentColor = newColor; // Rengi g�ncelle
    }

    private Color GetColorBasedOnButtonTag(string buttonTag)
    {
        // Buton etiketlerine g�re renkleri d�nd�r
        switch (buttonTag)
        {
            case "RedButton":
                return Color.red;
            case "YellowButton":
                return Color.yellow;
            case "GreenButton":
                return Color.green;
            case "BlueButton":
                return Color.blue;
            case "WhiteButton":
                return Color.white;
            case "BlackButton":
                return Color.black;
            default:
                return Color.white; // Varsay�lan renk
        }
    }

    private Color MixColors(Color color1, Color color2, float mixSpeed)
    {
        // Renk kar���m�n� yap
        float t = Mathf.PingPong(Time.time * mixSpeed, 1f); // PingPong fonksiyonu, renk kar���m�n� daha yava� yapmak i�in kullan�l�r

        float r = Mathf.Lerp(color1.r, color2.r, t);
        float g = Mathf.Lerp(color1.g, color2.g, t);
        float b = Mathf.Lerp(color1.b, color2.b, t);

        return new Color(r, g, b);
    }
}
