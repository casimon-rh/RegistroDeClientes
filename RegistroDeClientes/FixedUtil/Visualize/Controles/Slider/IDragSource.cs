using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualize.Slider
{
    public interface IDragSource
    {
        void StartDrag(DragInfo dragInfo);
    }
}
