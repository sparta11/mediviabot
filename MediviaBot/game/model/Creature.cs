using MediviaBot.game.repository;
using MediviaBot.player;
using MediviaBot.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediviaBot.game.model
{
    class Creature
    {
        public Creature(int id, string name, int xPos, int yPos, int zPos, int hpPc)
        {
            Id = id;
            Name = name;
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;
            HpPc = hpPc;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }
        public int HpPc { get; set; }
        public int Speed { get; set; }
        public Location Location
        {
            get
            {
                return new Location(XPos, YPos, ZPos);
            }
        }

        public bool IsNpc()
        {
            if (this.Speed == 110)
                return true;

            return false;
        }

        public bool IsSelf()
        {
            return PlayerImpl.Instance.Id() == this.Id;
        }

        public bool IsMonster()
        {
            return MonsterList.List.FindMonster(this.Name);
        }

        public bool IsPlayer()
        {
            if (!IsMonster() && !IsSelf() && !IsNpc())
                return true;

            return false;
        }

        internal void PrintInfo()
        {
            Console.WriteLine("|------------------ " + Name + " ------------------|");
            Console.WriteLine("| ID: " + Id);
            Console.WriteLine("| X: " + XPos);
            Console.WriteLine("| Y: " + YPos);
            Console.WriteLine("| Z: " + ZPos);
            Console.WriteLine("| HpPc: " + HpPc);
            Console.WriteLine("| Npc: " + IsNpc());
            Console.WriteLine("| Player: " + IsPlayer());
            Console.WriteLine("| Monster: " + IsMonster());
            Console.WriteLine("| Selft: " + IsSelf());
        }
    }
}
//uint32 m_id;
//std::string m_name;
//uint8 m_healthPercent;
//Otc::Direction m_direction;
//Outfit m_outfit;
//Light m_light;
//int m_speed;
//double m_baseSpeed;
//uint8 m_skull;
//uint8 m_shield;
//uint8 m_emblem;
//uint8 m_icon;
//TexturePtr m_skullTexture;
//TexturePtr m_shieldTexture;
//TexturePtr m_emblemTexture;
//TexturePtr m_iconTexture;
//stdext::boolean<true> m_showShieldTexture;
//stdext::boolean<false> m_shieldBlink;
//stdext::boolean<false> m_passable;
//Color m_timedSquareColor;
//Color m_staticSquareColor;
//stdext::boolean<false> m_showTimedSquare;
//stdext::boolean<false> m_showStaticSquare;
//stdext::boolean<true> m_removed;
//CachedText m_nameCache;
//Color m_informationColor;
//Color m_outfitColor;
//ScheduledEventPtr m_outfitColorUpdateEvent;
//Timer m_outfitColorTimer;