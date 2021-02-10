using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class TileListEntity : ScriptableObject
{
  public  List<Panel> tileList = new List<Panel>();



}

[Serializable]
public class Panel
{
    public Sprite sprite;
    public  List<string> words = new List<string>();


}