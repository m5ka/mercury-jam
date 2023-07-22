using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIndicator : MonoBehaviour
{
    public List<Sprite> abilitySprites;

    private Image _image;

    public void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetAbility(int currentAbility)
    {
        _image.sprite = abilitySprites[currentAbility];
    }
}
