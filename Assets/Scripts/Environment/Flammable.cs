using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{ 
    [SerializeField] bool burning = false;
    [SerializeField] float burningTime = 5f;
    float currentBurnTime;
    SpriteRenderer flameSr;
    Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        currentBurnTime = burningTime;
        flameSr = GetComponent<SpriteRenderer>();
        startColor = flameSr.color;
        GetComponent<Property>().HitByFire.AddListener(StartBurning);
        GetComponent<Property>().HitByIce.AddListener(StopBurning);

    }

    // Update is called once per frame
    void Update()
    {
        if (burning)
        {
            if(currentBurnTime >= 0)
            {
                if((int)currentBurnTime % 2 == 1)
                {
                    flameSr.color = new Color(0.5f, 0f, 0f, 1f);
                }
                if((int)currentBurnTime % 2 == 0)
                {
                    flameSr.color = new Color(0.7f, 0f, 0f, 1f);
                }

                currentBurnTime -= Time.deltaTime;
                if(currentBurnTime <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        } else
        {
            currentBurnTime = burningTime;
            flameSr.color = startColor;
        }
    }

    public void StartBurning()
    {
        burning = true;
    }

    public void StopBurning()
    {
        burning = false;
    }
}
