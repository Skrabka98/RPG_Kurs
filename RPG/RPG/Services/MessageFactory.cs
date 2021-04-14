using RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Services
{
    class MessageFactory : IMessageFactory
    {
        private readonly IEnumerable<IMessageService> _services;
        private IMessageService _current;
        public MessageFactory(IEnumerable<IMessageService> services)
        {
            _services = services;
        }
        public IMessageService Create(bool isFile = false)
        {
            if(_current == null)
            {
                _current = isFile ? _services.Last() : _services.First();
            }
            return _current;
        }
    }
}
