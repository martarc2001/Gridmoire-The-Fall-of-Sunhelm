using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    #region Variables
    private GameObject cell; //celda en la que está el personaje
    [SerializeField] private AttackType attackType; //tipo de ataque que va a realizar
    private float baseDamage; //daño base de los ataques

    private GameObject gridManager;
    #endregion

    #region Unity Methods
    
    void Start()
    {
        baseDamage = 1;

        gridManager = GameObject.FindGameObjectWithTag("GridManager");
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
    #endregion

    #region Attacks functions
    /// <summary>
    /// Ataque en la celda del personaje. Mira si hay enemigo en ella, y aplica un porcentaje del daño al enemigo
    /// </summary>
    private void oneCellAttack()
    {
        Debug.Log("Single Attack");
        var enemyInTheCell = cell.GetComponent<EnemyController>();

        if (enemyInTheCell.hasEnemy)
        {
            var percentDamage = Random.Range(0.75f, 1);
            enemyInTheCell.takeDamage(baseDamage * percentDamage);
        }
    }

    /// <summary>
    /// Ataque en fila. Comprueba si en las celdas de la fila de la celda del personaje hay enemigos.
    /// Les aplica un porcentaje del daño a los enemigos.
    /// </summary>
    private void rowCellAttack()
    {
        
        var rowCells = gridManager.GetComponent<GridManager>().returnRow(cell);

        for(int i = 0; i < rowCells.Length; i++)
        {
            var enemyInTheCell = rowCells[i].GetComponent<EnemyController>();
            if (enemyInTheCell.hasEnemy)
            {
                Debug.Log("Row Attack");
                var percentDamage = Random.Range(0.45f, 0.7f);
                enemyInTheCell.takeDamage(baseDamage * percentDamage);
            }
        }
    }

    /// <summary>
    /// /// Ataque en columna. Comprueba si en las celdas de la columna de la celda del personaje hay enemigos.
    /// Les aplica un porcentaje del daño a los enemigos.
    /// </summary>
    private void colCellAttack()
    {
        var colCells = gridManager.GetComponent<GridManager>().returnCol(cell);

        for (int i = 0; i < colCells.Length; i++)
        {
            var enemyInTheCell = colCells[i].GetComponent<EnemyController>();
            if (enemyInTheCell.hasEnemy)
            {
                Debug.Log("Col Attack");
                var percentDamage = Random.Range(0.45f, 0.7f);
                enemyInTheCell.takeDamage(baseDamage * percentDamage);
            }
        }
    }

    /// <summary>
    /// Ataque a todo el grid. Comprueba si hay enemigo en cada una de las casillas.
    /// Aplica un porcentaje de daño a cada enemigo.
    /// </summary>
    private void gridAttack()
    {
        var grid = gridManager.GetComponent<GridManager>().returnGrid();

        foreach(GameObject cell in grid)
        {
            var script = cell.GetComponent<EnemyController>();
            if (script.hasEnemy)
            {
                Debug.Log("Grid Attack");
                var percentDamage = Random.Range(0.15f, 0.35f);
                script.takeDamage(baseDamage * percentDamage);
            }
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
    grid
}
