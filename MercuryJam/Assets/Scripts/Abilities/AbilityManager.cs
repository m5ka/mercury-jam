using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

[HideMonoScript]
public class AbilityManager : MonoBehaviour
{
    [BoxGroup("Abilities")] public List<Ability> abilities;
    [BoxGroup("Abilities"), LabelText("Current")] public int currentAbility;
    
    [BoxGroup("Ability config"), LabelText("Location")] public Transform abilityLocation;
    [BoxGroup("Ability config"), LabelText("Indicator")] public AbilityIndicator abilityIndicator;
    [BoxGroup("Ability config"), LabelText("Delay")] public float abilityDelay = 0.4f;
    
    [BoxGroup("Player"), LabelText("Animator")] public Animator playerAnimator;
    [BoxGroup("Player"), LabelText("Rotation")] public Transform playerRotation;

    private Vector3 _forward;
    private bool _delayStarted;
    private float _cooldown;
    private float _cooldownElapsed;
    
    private IEnumerator SpawnAbility()
    {
        yield return new WaitForSeconds(abilityDelay);
        var ability = Instantiate(abilities[currentAbility]);
        ability.Initiate(abilityLocation.position, _forward);
        _cooldown = ability.cooldown;
        _delayStarted = false;
    }

    public void Update()
    {
        if (Player.CurrentPlayer is null || Player.CurrentPlayer.Dead)
            return;
        
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
            _forward = playerRotation.forward;
            _delayStarted = true;
            _cooldownElapsed = 0f;
            StartCoroutine(SpawnAbility());
        }
    }
}
