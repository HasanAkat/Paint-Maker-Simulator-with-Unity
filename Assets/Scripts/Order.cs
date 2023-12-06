using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public GameObject paintObject;
    public GameObject orderObject;
    public Text scoreText;

    private int totalScore = 0; // Toplam skoru tutmak i�in de�i�ken

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeColor);

        // �lk oyun ba�lad���nda totalScore de�erini text'e yaz
        UpdateScoreText();

        // Oyun ba�lad���nda ilk renk de�i�imini yap
        ChangeColor();
    }

    private void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        orderObject.GetComponent<Renderer>().material.color = randomColor;

        // Yeni puan� hesapla ve toplam skora ekle
        int similarityScore = ColorSimilarity(orderObject.GetComponent<Renderer>().material.color, paintObject.GetComponent<Renderer>().material.color);
        totalScore += similarityScore;

        // Toplam skoru g�ncelle ve text'e yaz
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Skor metnini g�ncelle
        scoreText.text = "Score: " + totalScore.ToString();
    }

    private int ColorSimilarity(Color color1, Color color2)
    {
        // Renklerin hex kodlar�n� al
        string hexColor1 = ColorUtility.ToHtmlStringRGB(color1);
        string hexColor2 = ColorUtility.ToHtmlStringRGB(color2);

        // Hex kodlar�n� int'e d�n��t�r
        int intColor1 = int.Parse(hexColor1, System.Globalization.NumberStyles.HexNumber);
        int intColor2 = int.Parse(hexColor2, System.Globalization.NumberStyles.HexNumber);

        // Fark� al
        int difference = Mathf.Abs(intColor1 - intColor2);
        Debug.Log("Difference: " + difference);

        // Farka g�re puanlama yap
        if (difference < 1000000)
        {
            return 100;
        }
        else if (difference < 2500000)
        {
            return 75;
        }
        else if (difference < 4000000)
        {
            return 50;
        }
        else if (difference < 5500000)
        {
            return 25;
        }
        else
        {
            return 0;
        }
    }
}
