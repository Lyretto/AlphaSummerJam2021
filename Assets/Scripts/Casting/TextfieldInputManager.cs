using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextfieldInputManager : MonoBehaviour
{

    TextField tf;
    InputField iF;

    int maxLetters = 50;
    // Start is called before the first frame update
    void Start()
    {
        iF = GetComponent<InputField>();
        iF.onEndEdit.AddListener(delegate { CheckFinalInput(iF); });
        iF.onValueChanged.AddListener(delegate { CheckInput(iF); });
        iF.ActivateInputField();
    }

    public void CheckFinalInput(InputField iF)
    {
        string possibleSpell = iF.text;
        Debug.Log("Try to cast Spell named: " + possibleSpell);
        SpellManager.Instance.TryCastSpell(possibleSpell);
    }

    public void CheckInput(InputField iF)
    {
        Debug.Log(maxLetters);
        if (iF.text.Length >= SpellManager.Instance.letters + 1)
        {
            Debug.Log("Remove last letter from : "+ iF.text);
            iF.text = iF.text.Remove(iF.text.Length-1);
        }
        SpellManager.Instance.UpdateLettersLeft(iF.text.Length);
    }
}
