using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITest : MonoBehaviour
{
    public Slider _slider;
    public Toggle _toggle;
    public TMP_InputField _inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = _slider.value;
        GetComponent<AudioSource>().enabled = _toggle.isOn;
    }

    public void displayText()
    {
        Debug.Log(_inputField.text);
    }
}
