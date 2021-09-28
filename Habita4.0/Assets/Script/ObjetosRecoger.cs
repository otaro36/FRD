using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Material",menuName ="Reciclaje")]
public class ObjetosRecoger : ScriptableObject
{
    public new string name;
    public int monedas;
    public float peso;
    public MeshFilter objeto;
}
