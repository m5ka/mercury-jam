using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public class AbilityManager : MonoBehaviour
{
    [BoxGroup("Abilities")] public List<Ability> abilities;
    [BoxGroup("Abilities"), LabelText("Current")] public int currentAbility;
    
    [BoxGroup("Ability config"), LabelText("Location")] public Transform abilityLocation;
    [BoxGroup("Ability config"), LabelText("Indicator")] public AbilityIndicator abilityIndicator;
    [BoxGroup("Ability config"), LabelText("Delay")] public float abilityDelay = 0.4f;
    
    [BoxGroup("Player"), LabelText("Animator")] public Animator playerAnimator;
    [BoxGroup("Player"), LabelText("Transform")] public Transform playerTransform;

    private Vector3 _forward;
    private bool _delayStarted = false;
    private float _cooldown;
    private float _cooldownElapsed;
    
    private IEnumerator SpawnAbility()
    {
        yield return new WaitForSeconds(abilityDelay);
        var ability = Instantiate(abilities[currentAbility], transform);
        ability.Initiate(abilityLocation.position, _forward);
        _cooldown = ability.cooldown;
        _delayStarted = false;
    }

    public void Update()
    {
        if (_delayStarted)
            return;

        if (_cooldown > 0f)
        {
            playerAnimator.SetBool("IsHitting", false);
            _cooldownElapsed += Time.deltaTime;
            if (_cooldownElapsed > _cooldown)
                _cooldown = 0f;

            return;
        }

        if (Input.GetButtonDown("Shoot"))
        {
            playerAnimator.SetBool("IsHitting", true);
            _forward = playerTransform.forward;
            _delayStarted = true;
            _cooldownElapsed = 0f;
            StartCoroutine(SpawnAbility());
        }
    }
}
