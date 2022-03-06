using System;
using System.Collections;
using System.Collections.Generic;

namespace military.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public ICollection<IPrivate> Privates { get; set; }
    }
}
