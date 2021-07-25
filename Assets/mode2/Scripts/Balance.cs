using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Balance
{



    public static class Magics
    {

        public static List<Magic> AllMagics = new List<Magic>{

new Magic{

    Name= "Pequena Chama",
    Level=1,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Attack, MagicType.Buff},
    Description= "Cria uma chama que pode ser arremessada, causando dano nos inimigos"
},
new Magic{

    Name= "Soco de fogo",
    Level=2,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Attack, MagicType.Buff},
    Description= "Envolve seu punho em chamas, aumentando o dano de ataque"
},
new Magic{

    Name= "Lança-chama",
    Level=3,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Attack},
    Description= "Usando a pequena chama, se cria uma labareda de fogo que queima os inimigos"
},
new Magic{

    Name= "Bola de eletricidade",
    Level=1,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric},
    Type= new List<MagicType>{MagicType.Attack},
    Description= "Cria uma pequena esfera elétrica que pode ser arremessada,causando dano nos inimigos"
},
new Magic{

    Name= "Estocada elétrica",
    Level=2,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric},
    Type= new List<MagicType>{MagicType.Attack},
    Description= "Envolve sua mão em eletricidade para dar uma estocada no inimigo"
},
new Magic{

    Name= "Manto estático",
    Level=3,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric},
    Type= new List<MagicType>{MagicType.Buff,MagicType.Defensive},
    Description= "Envolve seu corpo em eletricidade, aumentando sua velocidade e defesa"
},
new Magic{

    Name= "Chama elétrica",
    Level=1,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric, MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Attack},
    Description= "Cria uma chama azul coberta de eletricidade"
},
new Magic{

    Name= "Palmada de luz",
    Level=2,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric, MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Buff,MagicType.Attack},
    Description= "Envolve o braço em chamas azuis eletrificadas para dar uma palmada no inimigo"
},

new Magic{

    Name= "Barreira de luz",
    Level=3,
    Mana=10,
    Element= new List<MagicElement>{ MagicElement.Eletric, MagicElement.Fire},
    Type= new List<MagicType>{MagicType.Buff,MagicType.Attack, MagicType.Defensive},
    Description= "Envolve o corpo inteiro em um manto de luz que pode ser expelido em forma de raio"
},
};

        internal static List<Magic> GetAllMagics()
        {
            return AllMagics;
        }
        internal static List<Magic> FindMagicsByType(MagicType type)
        {
            List<Magic> magics = GetAllMagics();
            return magics.FindAll(((Magic magic) => magic.Type.Contains(type)));
        }
        internal static List<Magic> FindMagicsByElement(MagicElement element)
        {
            List<Magic> magics = GetAllMagics();
            return magics.FindAll(((Magic magic) => magic.Element.Contains(element)));
        }

        internal static List<Magic> FindMagicsByLevel(int lv)
        {
            List<Magic> magics = GetAllMagics();
            return magics.FindAll(((Magic magic) => magic.Level == lv));
        }

        internal static Magic FindMagicByElementAndLevel(MagicElement element, int level)
        {
            List<Magic> magics = GetAllMagics();
            return magics.Find(((Magic magic) => magic.Element.Contains(element) && magic.Level == level));
        }

         internal static Magic FindMixedMagicByElementAndLevel(MagicElement element1, MagicElement element2, int level)
        {
            List<Magic> magics = GetAllMagics();
            return magics.Find(((Magic magic) =>magic.Element.Count>=2&&magic.Element.Contains(element1)&& magic.Element.Contains(element2) && magic.Level == level));
        }

        public static int FindMagicIndex(string name)
        {
            List<Magic> magics = GetAllMagics();
            return magics.FindIndex(((Magic magic) => magic.Name == name));
        }
        public static Magic FindMagicByIndex(int i)
        {
            List<Magic> magics = GetAllMagics();
            return magics[i];
        }
        public static Magic FindMagicByName(string name)
        {
            List<Magic> magics = GetAllMagics();
            return magics.Find(((Magic magic) => magic.Name == name));
        }


    }
}