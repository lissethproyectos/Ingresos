using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

public class Menus
{

    private string _NombreMenu;
    public string NombreMenu
    {
        get { return _NombreMenu; }
        set { _NombreMenu = value; }
    }

    private string _UsuarioNombre;
    public string UsuarioNombre
    {
        get { return _UsuarioNombre; }
        set { _UsuarioNombre = value; }
    }

    private string _Clave;
    public string Clave
    {
        get { return _Clave; }
        set { _Clave = value; }
    }
    private string _Usuario;
    public string Usuario
    {
        get { return _Usuario; }
        set { _Usuario = value; }
    }

    private int _Grupo;
    public int Grupo
    {
        get { return _Grupo; }
        set { _Grupo = value; }
    }

    private string _Ejercicio;
    public string Ejercicio
    {
        get { return _Ejercicio; }
        set { _Ejercicio = value; }
    }

    private int _Id;
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }

    private int _Id_Padre;
    public int Id_Padre
    {
        get { return _Id_Padre; }
        set { _Id_Padre = value; }
    }

    private string _Padre;
    public string Padre
    {
        get { return _Padre; }
        set { _Padre = value; }
    }

    private string _Descripcion;
    public string Descripcion
    {
        get { return _Descripcion; }
        set { _Descripcion = value; }
    }

    private string _Navigate_Url;
    public string Navigate_Url
    {
        get { return _Navigate_Url; }
        set { _Navigate_Url = value; }
    }

}
