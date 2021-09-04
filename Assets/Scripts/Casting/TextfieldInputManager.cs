using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextfieldInputManager : MonoBehaviour
{
    InputField iF;

    void Awake()
    {
        iF = GetComponent<InputField>();
        iF.onEndEdit.AddListener(delegate { CheckFinalInput(); });
        iF.onValueChanged.AddListener(delegate { CheckInput(); });
    }

    private void OnEnable()
    {
        iF.text = "";
    }

    private void Update()
    {
        iF.ActivateInputField();
    }


    public void CheckFinalInput()
    {
        string possibleSpell = iF.text;
        SpellManager.Instance.TryCastSpell(possibleSpell);
    }

    public void CheckInput()
    {
        iF.text = iF.text.ToUpper();
        if (iF.text.Length >= SpellManager.Instance.letters + 1)
        {
            Debug.Log("Remove last letter from : "+ iF.text);
            iF.text = iF.text.Remove(iF.text.Length-1);
        }
        SpellManager.Instance.UpdateLettersLeft(iF.text.Length);
    }
}
