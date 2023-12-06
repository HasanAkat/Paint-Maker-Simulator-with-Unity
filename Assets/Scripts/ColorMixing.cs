using UnityEngine;

public class ColorMixing : MonoBehaviour
{
    private Renderer objRenderer;
    private Color currentColor; // Þu anki obje rengi
    private bool isButtonPressed = false; // Buton basýlý durumu
    private string currentButtonTag; // Þu an basýlý olan butonun etiketi
    private bool isFirstClick = true; // Ýlk týklama kontrol bayraðý

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
        // Baþlangýçta objenin rengini almak yerine, varsayýlan bir renk atayabiliriz.
        // Bu örnekte, beyaz rengi varsayýlan olarak kullanalým.
        currentColor = Color.white;
    }

    private void Update()
    {
        // Eðer buton basýlýysa, MixColor fonksiyonunu çaðýr
        if (isButtonPressed)
        {
            // Renk karýþtýrma iþlemi burada gerçekleþtiriliyor
            MixColor(); // Örnek bir fonksiyon çaðrýsý
        }
    }

    public void OnButtonPressed(string buttonTag)
    {
        isButtonPressed = true;
        currentButtonTag = buttonTag;

        // Ýlk týklama ise, rengi güncelle
        if (isFirstClick)
        {
            
            currentColor = GetColorBasedOnButtonTag(currentButtonTag);
            isFirstClick = false; // Ýlk týklama gerçekleþti, bayraðý deðiþtir
        }

    }

    public void OnButtonReleased(string buttonTag)
    {
        isButtonPressed = false;
    }
    private void MixColor()
    {
        Color colorToAdd = GetColorBasedOnButtonTag(currentButtonTag);
        float mixSpeed = 0.0001f; // Renk karýþým hýzý, isteðe baðlý olarak deðiþtirilebilir
        Color newColor = MixColors(currentColor, colorToAdd, mixSpeed);
        objRenderer.material.color = newColor;
        currentColor = newColor; // Rengi güncelle
    }

    private Color GetColorBasedOnButtonTag(string buttonTag)
    {
        // Buton etiketlerine göre renkleri döndür
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
                return Color.white; // Varsayýlan renk
        }
    }

    private Color MixColors(Color color1, Color color2, float mixSpeed)
    {
        // Renk karýþýmýný yap
        float t = Mathf.PingPong(Time.time * mixSpeed, 1f); // PingPong fonksiyonu, renk karýþýmýný daha yavaþ yapmak için kullanýlýr

        float r = Mathf.Lerp(color1.r, color2.r, t);
        float g = Mathf.Lerp(color1.g, color2.g, t);
        float b = Mathf.Lerp(color1.b, color2.b, t);

        return new Color(r, g, b);
    }
}
