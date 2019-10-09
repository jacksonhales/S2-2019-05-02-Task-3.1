
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using SwinGameSDK;
/// <summary>
/// The AIEasyPlayer is a type of player. It will randomly fire at tiles,
/// without changing behaviour if it hits something.
/// </summary>
public class AIEasyPlayer : AIPlayer
{
    /// <summary>
    /// Private enumarator for AI states. currently there are two states,
    /// the AI can be searching for a ship, or if it has found a ship it will
    /// target the same ship
    /// </summary>
    public AIEasyPlayer(BattleShipsGame controller) : base(controller)
    {
    }
    /// <summary>
    /// GenerateCoordinates should generate random shooting coordinates
    /// only when it has not found a ship, or has destroyed a ship and 
    /// needs new shooting coordinates
    /// </summary>
    /// <param name="row">the generated row</param>
    /// <param name="column">the generated column</param>
    protected override void GenerateCoords(ref int row, ref int column)
    {
        do
        {
            SearchCoords(ref row, ref column);
        } while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
        /// while inside the grid and not a sea tile do the search
    }

    /// <summary>
    /// ProcessShot is able to process each shot that is made and call the right methods belonging
    /// to that shot. For example, if its a miss = do nothing, if it's a hit = process that hit location
    /// </summary>
    /// <param name="row">the row that was shot at</param>
    /// <param name="col">the column that was shot at</param>
    /// <param name="result">the result from that hit</param>
    protected override void ProcessShot(int row, int col, AttackResult result)
    {
        // switch (result.Value)
        // {
        //     case ResultOfAttack.Miss:
        //         _CurrentTarget = null;
        //         break;
        //     case ResultOfAttack.Hit:
        //         ProcessHit(row, col);
        //         break;
        //     case ResultOfAttack.Destroyed:
        //         ProcessDestroy(row, col, result.Ship);
        //         break;
        //     case ResultOfAttack.ShotAlready:
        //         throw new ApplicationException("Error in AI");
        // }

        // if (_Targets.Count == 0)
        //     _CurrentState = AIStates.Searching;
    }

    /// <summary>
    /// SearchCoords will randomly generate shots within the grid as long as its not hit 
    /// that tile already, this is the primary function of the Easy level AI.
    /// </summary>
    private void SearchCoords(ref int row, ref int column)
    {
        row = _Random.Next(0, EnemyGrid.Height);
        column = _Random.Next(0, EnemyGrid.Width);
    }

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
