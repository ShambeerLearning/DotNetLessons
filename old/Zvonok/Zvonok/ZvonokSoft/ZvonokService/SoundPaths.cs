using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShambersMicroServicesMultiSoft.Support
{
    internal class SoundPaths
    {
        static string[] Paths =
        {
            @".\sounds\zvonok.wav",
            @".\sounds\sirena.wav"
        };
        public string GetPaths(int i)
        {
            return Paths[i];
        }
    }
}
