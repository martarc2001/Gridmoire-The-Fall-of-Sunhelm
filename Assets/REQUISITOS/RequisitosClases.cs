

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RequisitosClases : MonoBehaviour
{
    
}


//-------------------------------------------------------------------
//AREA DE ADMINISTRADORES
[Serializable] public class ListaAdminSerializable { public List<SerializableAdmin> list = new List<SerializableAdmin>(); }

[Serializable]
public class SerializableAdmin
{
    public string nombre;
    public SerializableAdmin() { }
    public SerializableAdmin(string n) { this.nombre = n; }
    override public string ToString()
    {
        return "Nombre: " + nombre + "\n";
    }
}

//-------------------------------------------------------------------
//AREA DE REPORTES
[Serializable] public class ListaReporteSerializable { public List<SerializableReporte> list = new List<SerializableReporte>(); }

[Serializable]
public class SerializableReporte
{
    public int id;
    public string motivo;
    public string comentario;
    public bool perdonado;

    public SerializableReporte() { }
    public SerializableReporte(int i, string m, string c, bool p)
    {
        this.id = i;
        this.motivo = m;
        this.comentario = c;
        this.perdonado = p;
    }
}