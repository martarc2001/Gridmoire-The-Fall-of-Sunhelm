using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelDataHandler : MonoBehaviour
{
    private SerializableLevel nivel;

    // GETTERS & SETTERS

    public SerializableLevel GetNivel() { return this.nivel; }
    public void SetNivel(SerializableLevel nivel) { this.nivel = nivel; }

    // METODOS

    public List<int> GetEnemigos() { return this.nivel.enemigos; }

    public List<int> GetTipoAtaque() { return nivel.tipoAtaque; }
    public int GetMundo() { return this.nivel.mundo; }
    public int GetID() { return this.nivel.id; }
    public int GetXp() { return this.nivel.xp; }
    public int GetMonedas() { return this.nivel.monedas; }
    public int GetHistoria() { return this.nivel.historia; }

    public List<int> GetCeldasX() { return nivel.celdaX; }
    public List<int> GetCeldasY() { return nivel.celdaY; }
}
