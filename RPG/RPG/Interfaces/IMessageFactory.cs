using RPG.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Interfaces
{
    public interface IMessageFactory
    {
        IMessageService Create(bool isFile = false);
    }
}
