﻿namespace ConsoleApp7.Interface
{
    public interface IDisplayingAttackResults
    {
        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink);
        
        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink);
    }
}