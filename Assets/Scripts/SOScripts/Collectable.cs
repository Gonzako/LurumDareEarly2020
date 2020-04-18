using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Collectable", menuName ="Collectables/New Collectable")]
public class Collectable : ScriptableObject
{
   public Sprite _collectableSprite;
   public string _name;
}
