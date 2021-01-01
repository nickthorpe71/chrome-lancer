using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private enum EndState {P1WIN, P2WIN, DRAW};
    private EndState finalVerdict;

    private float actionStartTime;
    private float player1Time;
    private float player2Time;
    private float actionTime;

    private bool canInput;

    public Text overheadText;
    public Text player1TimeDisplay;
    public Text player2TimeDisplay;
    public GameObject toMainButton;

    public GameObject player1;
    public GameObject player2;

    private CharacterMovement characterMovement;
    private CharacterAnimationController charAnimController;
    

    void Start()
    {
        actionTime = Random.Range(0.05f, 12f);
        player2Time = Mathf.Round(Random.Range(0.05f, 1f) * 100); // This will eventualy depend on the level of the AI

        characterMovement = GetComponent<CharacterMovement>();
        characterMovement.initializePlayers(player1, player2);

        charAnimController = GetComponent<CharacterAnimationController>();
        charAnimController.InitializePlayers(player1, player2);

        StartCoroutine(WaitThenCountdown());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canInput)
        {
            canInput = false;
            // if player presses before action timer starts then restart match / default
            player1Time = Mathf.Round((Time.timeSinceLevelLoad - actionStartTime) * 100f);
            StartCoroutine(PostButtonPress());
        }
    }

    IEnumerator WaitThenCountdown()
    {
        charAnimController.SetP1Idle();
        charAnimController.SetP2Idle();

        yield return new WaitForSeconds(3);
        overheadText.text = "3";

        yield return new WaitForSeconds(1);
        overheadText.text = "2";

        yield return new WaitForSeconds(1);
        overheadText.text = "1";

        yield return new WaitForSeconds(1);
        charAnimController.SetP1CombatIdle();
        charAnimController.SetP2CombatIdle();
        overheadText.text = "";

        yield return new WaitForSeconds(actionTime);
        overheadText.text = "!";
        canInput = true;
        characterMovement.MoveToEndPosition();
        charAnimController.StartP1Running();
        charAnimController.StartP2Running();
        actionStartTime = Time.timeSinceLevelLoad;

        yield return new WaitForSeconds(1);
        characterMovement.StopMovement();
        charAnimController.StopP1Running();
        charAnimController.StopP2Running();
        charAnimController.SetP1CombatIdle();
        charAnimController.SetP2CombatIdle();

    }

    IEnumerator PostButtonPress()
    {
        OnButtonPress();

        yield return new WaitForSeconds(3);
        PlayEndAnimations();

        yield return new WaitForSeconds(0.2f);
        PlayEndAnimations();
        charAnimController.StopP1Running();
        charAnimController.StopP2Running();

        yield return new WaitForSeconds(1);
        DisplayFinalResults();
    }

    void OnButtonPress()
    {
        if (player1Time == player2Time)
        {
            finalVerdict = EndState.DRAW;
        }
        else if (player1Time < player2Time)
            finalVerdict = EndState.P1WIN;
        else
            finalVerdict = EndState.P2WIN;

        overheadText.text = "";
    }

    void DisplayFinalResults()
    {
        player1TimeDisplay.text = "P1 " + player1Time.ToString();
        player2TimeDisplay.text = "P2 " + player2Time.ToString();

        if (finalVerdict == EndState.P1WIN)
            overheadText.text = "Player 1 wins";
        else if(finalVerdict == EndState.P2WIN)
            overheadText.text = "Player 2 wins";
        else
            overheadText.text = "DRAW";

        toMainButton.SetActive(true);
    }

    void PlayEndAnimations()
    {
        if (finalVerdict == EndState.P1WIN)
        {
            charAnimController.P1Roar();
            charAnimController.P2Die();
        }
        else if (finalVerdict == EndState.P2WIN)
        {
            charAnimController.P2Roar();
            charAnimController.P1Die();
        }
        else
        {
            charAnimController.P1Roar();
            charAnimController.P2Roar();
        }
    }

}

// STORY
// first fight other centaur to become chieftan
// then fight other clan chiefs to defend or to gain more land