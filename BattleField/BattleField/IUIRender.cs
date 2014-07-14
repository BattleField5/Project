using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IUiRender
    {
        void WriteLine(string text);
        void Write(string text);
    }
}
