using RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Interfaces
{
    interface IMessageFactory
    {
        IMessageService Create(bool isFile = false);
    }
}
