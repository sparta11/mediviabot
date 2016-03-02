using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.addresses
{
    interface CreatureAddress
    {

        uint GetCreatureStartAddress();
        uint GetCreatureListSizeAddress();
        uint GetNextCreatureAddress();

        uint GetXPositionAddress();
        uint GetYPositionAddress();
        uint GetZPositionAddress();

        uint GetIdAddress();
        uint GetNameAddress();
        
        uint GetHpPercentageAddress();
        uint GetCreatureOffset();


    }
}
