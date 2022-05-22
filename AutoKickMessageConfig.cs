using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AKM;
public class AutoKickMessageConfig : IRocketPluginConfiguration
{
    [XmlArrayItem("Steam64")]
    public ulong[] Whitelist = Array.Empty<ulong>();
    public void LoadDefaults()
    {
        Whitelist = new ulong[1] { 76561198267927009 };
    }
}
