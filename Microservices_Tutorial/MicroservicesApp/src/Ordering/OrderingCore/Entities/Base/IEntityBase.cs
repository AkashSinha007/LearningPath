using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingCore.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
