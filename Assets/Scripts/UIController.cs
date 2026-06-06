using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private Button redirectButton;

    // Importem funció del .jslib
    [DllImport("__Internal")]
    private static extern string GetUrlParameter(string paramName);

    void Start()
    {
        string value = "";

#if UNITY_WEBGL && !UNITY_EDITOR
            value = GetUrlParameter("text");
#else
        //simulem un valor per fer proves
        value = "prova";
#endif

        if (string.IsNullOrEmpty(value))
            value = "(cap paràmetre rebut)";

        displayText.text = value;

        redirectButton.onClick.AddListener(() => {
            Application.OpenURL("https://www.google.com");
        });
    }
}