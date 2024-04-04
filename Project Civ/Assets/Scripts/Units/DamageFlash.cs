using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

/*
Damage Flash Script. Many of these settings are changed within a shader graph.
*/
public class DamageFlash : MonoBehaviour
{
    [SerializeField]
    private Color _flashColor = Color.white;

    private float flashtime;

    private Coroutine DamageFlashCoroutine;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        flashtime = 0.25f;
    }

    private void SetFlashColor()
    {
        sprite.material.SetColor("_FlashColor", _flashColor);
    }

    private void SetFlashAmount(float flashAmount)
    {
        sprite.material.SetFloat("_FlashAmount", flashAmount);
    }

    public void CallDamageFlash()
    {
        DamageFlashCoroutine = StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        //set color
        SetFlashColor();

        //lerp flash amount
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashtime)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedTime / flashtime);
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }
}
