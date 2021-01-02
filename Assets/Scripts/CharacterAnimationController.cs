using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
	private Animator p1Animator;
	private Animator p2Animator;

	public void InitializePlayers(GameObject p1, GameObject p2)
	{
		p1Animator = p1.GetComponent<Animator>();
		p2Animator = p2.GetComponent<Animator>();
	}

	public void SetP1Idle()
    {
		p1Animator.SetInteger("battle", 0);
	}

	public void SetP2Idle()
	{
		p2Animator.SetInteger("battle", 0);
	}

	public void SetP1CombatIdle()
	{
		p1Animator.SetInteger("battle", 1);
		p1Animator.SetBool("armed", true);
	}

	public void SetP2CombatIdle()
	{
		p2Animator.SetInteger("battle", 1);
		p2Animator.SetBool("armed", true);
	}

	public void StartP1Running()
    {
		p1Animator.SetInteger("moving", 1);
	}

	public void StartP2Running()
	{
		p2Animator.SetInteger("moving", 1);
	}

	public void StopP1Running()
    {
		p1Animator.SetInteger("moving", 0);
	}

	public void StopP2Running()
	{
		p2Animator.SetInteger("moving", 0);
	}

	public void P1Attack1()
    {
		p1Animator.SetInteger("moving", 2);
	}

	public void P2Attack1()
	{
		p2Animator.SetInteger("moving", 2);
	}

	public void P1Attack2()
	{
		p1Animator.SetInteger("moving", 3);
	}

	public void P2Attack2()
	{
		p2Animator.SetInteger("moving", 3);
	}

	public void P1Attack3()
	{
		p1Animator.SetInteger("moving", 6);
	}

	public void P2Attack3()
	{
		p2Animator.SetInteger("moving", 6);
	}

	public void P1Roar()
    {
		p1Animator.SetInteger("moving", 7);
	}

	public void P2Roar()
	{
		p2Animator.SetInteger("moving", 7);
	}

	public void P1Die()
    {
		p1Animator.SetInteger("moving", 14);
		StartCoroutine(SwitchAnimationAfterDeath());
	}

	public void P2Die()
	{
		p2Animator.SetInteger("moving", 14);
		StartCoroutine(SwitchAnimationAfterDeath());
	}

	IEnumerator SwitchAnimationAfterDeath()
    {
		yield return new WaitForSeconds(0.5f);
		StopP1Running();
		StopP2Running();
    }

	public void P1RandomAttack()
    {
		int choice = Random.Range(1, 3);

		switch (choice)
        {
			case 1:
				P1Attack1();
				break;
			case 2:
				P1Attack2();
				break;
			case 3:
				P1Attack3();
				break;
			default:
				break;

		}
    }

	public void P2RandomAttack()
	{
		int choice = Random.Range(1, 3);

		switch (choice)
		{
			case 1:
				P2Attack1();
				break;
			case 2:
				P2Attack2();
				break;
			case 3:
				P2Attack3();
				break;
			default:
				break;

		}
	}
}
