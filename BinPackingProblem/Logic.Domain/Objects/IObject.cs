using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
    public abstract class Object
    {
        public IFigure Size { get; set; }

        public virtual void Resize(IFigure newSize)
        {
            Size = newSize;
        }
    }
}
