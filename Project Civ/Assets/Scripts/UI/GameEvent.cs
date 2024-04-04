using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Defines Game Events for event system. Just a bunch of constant strings that make calling listeners and broadcasts easier. 
public static class GameEvent
{
    public const string ENEMY_SOL_DEATH = "ENEMY_SOL_DEATH"; 
    public const string WAVE_SPAWN = "WAVE_SPAWN"; 
    public const string SOLDIER_BOUGHT = "SOLDIER_BOUGHT";
    public const string ARTY_BOUGHT = "ARTY_BOUGHT"; 
    public const string MACHINE_GUNNER_BOUGHT = "MACHINE_GUNNER_BOUGHT"; 
    public const string SAND_HEALTH = "SAND_HEALTH"; 
    public const string GAME_OVER = "GAME_OVER"; 
}
