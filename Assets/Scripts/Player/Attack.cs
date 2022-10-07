using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    #region Variables
    private GameObject cell; //celda en la que está el personaje
    [SerializeField] private AttackType attackType; //tipo de ataque que va a realizar
    [SerializeField] private Player player;

    private GameObject gridManager;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        player = new Player();
    }

    void Start()
    {

        gridManager = GameObject.FindGameObjectWithTag("GridManager");
    }

    private void Update()
    {
        Debug.Log("Ataque: " + player.getAttack());
        Debug.Log("Defensa: " + player.getDefense());
        Debug.Log("HP: " + player.getHp());
    }
    #endregion

    #region Methods
    /// <summary>
    /// Realiza un ataque dependiendo del valor de attackType
    /// </summary>
    public void perfomAttack()
    {
        switch (attackType)
        {
            case AttackType.single:
                oneCellAttack();
                break;
            case AttackType.row:
                rowCellAttack();
                break;
            case AttackType.col:
                colCellAttack();
                break;
            case AttackType.grid:
                gridAttack();
                break;
            case AttackType.heal:
                heal();
                break;
        }
    }
    #endregion

    #region Getters & Setters
    /// <summary>
    /// Setter de la variable attackType
    /// </summary>
    /// <param name="type"></param>
    public void setAttackType(AttackType type) { attackType = type; }

    /// <summary>
    /// Setter de la variable cell
    /// </summary>
    /// <param name="cell"></param>
    public void setCell(GameObject cell) { this.cell = cell; }

    public Player getPlayerClass() { return player; }
    #endregion

    #region Attacks functions
    /// <summary>
    /// Ataque en la celda del personaje. Mira si hay enemigo en ella, y aplica un porcentaje del daño al enemigo
    /// </summary>
    private void oneCellAttack()
    {
        var baseDamage = player.getAttack();
        Debug.Log("Single Attack");
        var enemyInTheCell = cell.GetComponent<CellController>();

        if (enemyInTheCell.isEnemyInCell() != null)
        {
            var enemy = enemyInTheCell.isEnemyInCell().GetComponent<EnemyController>();
            var percentDamage = Random.Range(0.75f, 1);
            enemy.takeDamage(baseDamage * percentDamage);
        }
    }

    /// <summary>
    /// Ataque en fila. Comprueba si en las celdas de la fila de la celda del personaje hay enemigos.
    /// Les aplica un porcentaje del daño a los enemigos.
    /// </summary>
    private void rowCellAttack()
    {
        var baseDamage = player.getAttack();
        var rowCells = gridManager.GetComponent<GridManager>().returnRow(cell);

        for(int i = 0; i < rowCells.Length; i++)
        {
            var enemyInTheCell = rowCells[i].GetComponent<CellController>();
            if (enemyInTheCell.isEnemyInCell() != null)
            {
                var enemy = enemyInTheCell.isEnemyInCell().GetComponent<EnemyController>();
                Debug.Log("Row Attack");
                var percentDamage = Random.Range(0.45f, 0.7f);
                enemy.takeDamage(baseDamage * percentDamage);
            }
        }
    }

    /// <summary>
    /// /// Ataque en columna. Comprueba si en las celdas de la columna de la celda del personaje hay enemigos.
    /// Les aplica un porcentaje del daño a los enemigos.
    /// </summary>
    private void colCellAttack()
    {
        var baseDamage = player.getAttack();
        var colCells = gridManager.GetComponent<GridManager>().returnCol(cell);

        for (int i = 0; i < colCells.Length; i++)
        {
            var enemyInTheCell = colCells[i].GetComponent<CellController>();
            if (enemyInTheCell.isEnemyInCell() != null)
            {
                var enemy = enemyInTheCell.isEnemyInCell().GetComponent<EnemyController>();
                Debug.Log("Col Attack");
                var percentDamage = Random.Range(0.45f, 0.7f);
                enemy.takeDamage(baseDamage * percentDamage);
            }
        }
    }

    /// <summary>
    /// Ataque a todo el grid. Comprueba si hay enemigo en cada una de las casillas.
    /// Aplica un porcentaje de daño a cada enemigo.
    /// </summary>
    private void gridAttack()
    {
        var baseDamage = player.getAttack();
        var grid = gridManager.GetComponent<GridManager>().returnGrid();

        foreach(GameObject cell in grid)
        {
            var script = cell.GetComponent<CellController>();
            if (script.isEnemyInCell() != null)
            {
                var enemy = script.isEnemyInCell().GetComponent<EnemyController>();
                Debug.Log("Grid Attack");
                var percentDamage = Random.Range(0.15f, 0.35f);
                enemy.takeDamage(baseDamage * percentDamage);
            }
        }
    }

    /// <summary>
    /// Función para curar vida a todos los aliados
    /// </summary>
    private void heal()
    {
        var grid = gridManager.GetComponent<GridManager>().returnGrid();

        foreach (GameObject cell in grid)
        {
            var script = cell.GetComponent<CellController>();
            //comprobar si tiene aliado
            if(script.isAllyInCell() != null)
            {
                var ally = script.isAllyInCell().GetComponent<Attack>();
                var percentHeal = Random.Range(0.15f, 0.35f);
                ally.getPlayerClass().heal(player.getAttack() * percentHeal);
            }
            //si lo tiene sumar vida
        }
    }
    #endregion
}

/// <summary>
/// Los tipos diferentes de ataques que hay
/// </summary>
public enum AttackType
{
    single,
    row,
    col,
    grid,
    heal
}
