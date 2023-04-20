using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public void ActivateStatusEffect(GameObject target, StatusEffect statusEffect)
    {
        StartCoroutine(Activate(target, statusEffect));
    }

    IEnumerator Activate(GameObject target, StatusEffect statusEffect)
    {
        if (target.gameObject.tag == "Player") //Player scenario
        {
            PlayerClass player = target.GetComponent<PlayerClass>();

            if (!player.immuneStatusEffects.Contains(statusEffect._name)) //Checks for immunity
            {
                statusEffect.active = true;
                player.activeStatusEffects.Add(statusEffect); //In case we need to check what status effects are currently active
                StartCoroutine(Timer(statusEffect));
            }

            while (statusEffect.active)
            {
                if (statusEffect.stun)
                {} //Implement stun here

                for (int i = 0; i < statusEffect.duration / statusEffect.healthTickTime; i++)
                {
                    player.playerStats.currentHealth += statusEffect.healthDifference;
                    yield return new WaitForSeconds(statusEffect.healthTickTime);
                }
            }

            //Remove stun here

            player.activeStatusEffects.Remove(statusEffect); //Remove the status effect from active after time duration has passed
        }

        else
        {
            //Enemy scenario later
        }
    }

    IEnumerator Timer(StatusEffect statusEffect)
    {
        yield return new WaitForSeconds(statusEffect.duration);
        statusEffect.active = false;
    }
}
