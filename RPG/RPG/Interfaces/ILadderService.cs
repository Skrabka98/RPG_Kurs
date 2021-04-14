using RPG.Champions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Interfaces
{
    public interface ILadderService
    {
        void LadderSystem(int count);
        void AddToLadder(Champion champion);
    }
}
