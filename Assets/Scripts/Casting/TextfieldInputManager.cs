using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TextfieldInputManager : MonoBehaviour
{

    TextField tf;
    InputField iF;

    int maxLetters = 5;
    // Start is called before the first frame update
    void Start()
    {
        iF = GetComponent<InputField>();
        iF.characterLimit = 5; //TODO CHECK PLAYER MAXINPUT
        iF.onEndEdit.AddListener(delegate { CheckFinalInput(iF); });
        iF.onValueChanged.AddListener(delegate { CheckInput(iF); });
    }

    public void CheckFinalInput(InputField iF)
    {
        string possibleSpell = iF.text;
        Debug.Log("Try to cast Spell named: " + possibleSpell);
        SpellManager.Instance.TryCastSpell(possibleSpell);
    }

    public void CheckInput(InputField iF)
    {
        if (iF.text.Length <= maxLetters + 1)
            maxLetters -= iF.text.Length;

        SpellManager.Instance.UpdateLettersLeft(iF.text.Length);
    }
}
