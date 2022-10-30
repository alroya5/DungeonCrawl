using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState { START,PLAYERTURN,ENEMYTURN,WON,LOST}
public class Battlesystem : MonoBehaviour
{
    public GameObject playerprefab;
    public GameObject enemyprefab;
    public GameObject orcoprefab;
    public GameObject tiendago;
    public GameObject botonTienda;
    public GameObject[] characters;
   
    bool iHit; 

    public GameObject enemyGo, playerGO;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public TextMeshProUGUI dialogText,rounds,coinsText,levelText;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHud playerHud, enemyHud;

    public int goblinCounter=0;
    public int coins = 0,coinsEarned=0;
    public  int levels=0;
    public int bombs = 0;
    public int venenousKnife = 0;
    public Button knifeButton, bombButton;


    public BattleState state;
   
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }
    private void Update()
    {
        if (bombs > 0)
        {
            bombButton.interactable = true;
        }
        else
        {
            bombButton.interactable = false;

        }
        if (venenousKnife > 0)
        {
            knifeButton.interactable = true;
        }
        else
        {
            knifeButton.interactable = false;
        }
    }
    IEnumerator SetUpBattle()
    {
        coinsText.text = "Coins: " + coins;
        playerGO = Instantiate(characters[Valores.Instance.spriteRaza], playerBattleStation);
        playerUnit= playerGO.GetComponent<Unit>();
        //var spritePlayer=playerGO.GetComponentInChildren<SpriteRenderer>();
        //spritePlayer.sprite = sprites[Valores.Instance.spriteRaza];
        print(Valores.Instance.spriteRaza);


        enemyGo =Instantiate(enemyprefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        dialogText.text =  enemyUnit.unitName + " appears, what \nshould you do now?";
        rounds.text = "round: " + (goblinCounter+1);
        levelText.text = "level: " + (levels + 1);

        playerHud.SetHud(playerUnit);
        enemyHud.SetHud(enemyUnit );

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    IEnumerator PlayerAttack()
    {
        if (!iHit)
        {
            bool isDead = enemyUnit.TakeDamage(playerUnit.dmg);
            enemyHud.SetHp(enemyUnit.currentHp);
            dialogText.text = "The attack is successful!";
            iHit = true;
            yield return new WaitForSeconds(2f);
            if (isDead&&enemyUnit.tag=="orc")
            {
                state = BattleState.WON;
                EndLevel();
            }
            else if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }

        }
        

    }
    IEnumerator knifeAttack()
    {
        yield return new WaitForSeconds(1f);
    }
    IEnumerator EnemyTurn()
    {
        iHit = false;
        dialogText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead=playerUnit.TakeDamage(enemyUnit.dmg );

        playerHud.SetHp(playerUnit.currentHp);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void OtherEnemy()
    {
        if (goblinCounter > 3)
        {
            enemyGo = Instantiate(orcoprefab, enemyBattleStation);
            enemyUnit = enemyGo.GetComponent<Unit>();
           
          
            
        }
        else
        {
            enemyGo = Instantiate(enemyprefab, enemyBattleStation);
            enemyUnit = enemyGo.GetComponent<Unit>();
        }
        
        dialogText.text = enemyUnit.unitName + " appears, what \nshould you do now?";
        enemyHud.SetHud(enemyUnit);
    }
    
    void EndBattle()
    {
        iHit = false;
        if (state == BattleState.WON)
        {
            coinsEarned = 20;
            dialogText.text = "You won the battle!\nyou won "+coinsEarned;
            coins += coinsEarned;
            coinsText.text = "Coins: " + coins;
            
            goblinCounter += 1;
            rounds.text = "round: " + (goblinCounter + 1);
            levelText.text = "level: " + (levels + 1);
            Destroy(enemyGo.gameObject);
            OtherEnemy();
            

            state = BattleState.PLAYERTURN;
            PlayerTurn();

        }
        else if (state == BattleState.LOST)
        {
            dialogText.text = "You died";
            levels = 0;
        }
    }

    void PlayerTurn()
    {

        dialogText.text = "Chose an action: ";
    }
    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(70);
        playerHud.SetHp(playerUnit.currentHp);
        dialogText.text = "Potion used";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
            
        else
        {
            StartCoroutine(PlayerAttack());
        }
       
    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        else
        StartCoroutine(PlayerHeal());
    }
    void EndLevel()
    {
        iHit = false;
        if (state == BattleState.WON)
        {
            coinsEarned = 100;          
            dialogText.text = "You won the battle!\nyou won " + coinsEarned+" coins";
            coins += coinsEarned;
            coinsText.text = "Coins: " + coins;
            tiendago.gameObject.SetActive(true);
            botonTienda.gameObject.SetActive(true);
            levels += 1;
            goblinCounter = 0;
            rounds.text = "round: " + (goblinCounter + 1);
            levelText.text = "level: " + (levels + 1);
            coinsText.text = "Coins: " + coins;
            Destroy(enemyGo.gameObject);
            OtherEnemy();
            state = BattleState.PLAYERTURN;
            PlayerTurn();

        }

    }
    public void UseBomb()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        else
        {
            StartCoroutine(PlayerAttack());
        }
    }
    public void UseKnife()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        else
        {
            StartCoroutine(PlayerAttack());
        }

    }
   


}
