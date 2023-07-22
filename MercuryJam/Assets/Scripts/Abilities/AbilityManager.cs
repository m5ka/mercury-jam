using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities;
    public int currentAbility;
    
    public Transform abilityLocation;
    public AbilityIndicator abilityIndicator;
    
    public Animator playerAnimator;
    public Transform playerTransform;
    
    public float abilityDelay = 0.4f;

    private bool _delayStarted = false;
    private float _cooldown;
    private float _cooldownElapsed;
    
    private IEnumerator SpawnAbility()
    {
        yield return new WaitForSeconds(abilityDelay);
        var ability = Instantiate(abilities[currentAbility], transform).GetComponent<Ability>();
        ability.Initiate(abilityLocation.position, playerTransform.forward);
        _cooldown = ability.cooldown;
        _delayStarted = false;
    }

    public void Update()
    {
        if (_delayStarted)
        {
            playerAnimator.SetBool("IsHitting", false);
            return;
        }
        
        if (_cooldown > 0f)
        {
            _cooldownElapsed += Time.deltaTime;
            if (_cooldownElapsed > _cooldown)
                _cooldown = 0f;

            return;
        }

        if (Input.GetButtonDown("Shoot"))
        {
            playerAnimator.SetBool("IsHitting", true);
            _delayStarted = true;
            _cooldownElapsed = 0f;
            StartCoroutine(SpawnAbility());
        }
    }
}
