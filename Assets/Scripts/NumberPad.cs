using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private GameObject keycard;
    
    private static string PASSWORD = "7639";
    private static int NUM_KEYS = 4;
    
    private static TextMeshProUGUI _codeText;
    private static GameObject _keycard;
    private static int _numOfKeyPressed;
    private static string _enteredCode;
    private static bool _isCorrect;
    private static SleepCoroutine _sleepCoroutine;

    void Start()
    {
        _codeText = codeText;
        _keycard = keycard;
        keycard.SetActive(false);
        _numOfKeyPressed = 0;
        _enteredCode = "";
        _sleepCoroutine = gameObject.AddComponent<SleepCoroutine>();
    }

    public static void KeyPressed(string code)
    {
        if (_isCorrect) return;
        
        _codeText.text += "*";
        _enteredCode += code;
        _numOfKeyPressed++;
        
        Debug.Log("# of digits: " + _numOfKeyPressed);
        Debug.Log("Entered Code: " + _enteredCode);

        if (_numOfKeyPressed < NUM_KEYS) return;
        
        Debug.Log("PASSED INITIAL INSPECTION");
        if (!_enteredCode.Equals(PASSWORD))
        {
            Debug.Log("INCORRECT");
            _codeText.text = "INCORRECT";
            _sleepCoroutine.SleepAndReset(0.5f, _codeText);
            
            _enteredCode = "";
            _numOfKeyPressed = 0;
        }
        else
        {
            Debug.Log("CORRECT");
            _isCorrect = true;
            _codeText.text = "CORRECT";
            _keycard.SetActive(true);
        }
    }

    private static IEnumerator Sleep()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
