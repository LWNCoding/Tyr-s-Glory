using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Board : Node2D
{
    private Dictionary<string, Province> provDict;
    private int[] regionControl;
    /// <summary>
    /// Constructor for the Board defined type.
    /// </summary>
    public Board()
    {
        provDict = new Dictionary<string, Province>();
        regionControl = new int[] { -1, -1, -1, -1, -1, -1, -1 }; //NA=0,SA=1,EU=2,AF=3,AS=4,ME=5,OC=6
    }

    public void addProv(string lab, Province one)
    {
        provDict.Add(lab, one);
    }

    public bool canAttack(Unit dude, Province one, Province two)
    {
        int rangee = dude.getRange();
        IEnumerator<Province> iter = one.getAdjacencyEnumerator();

        do
        {
            if (iter.Current == two)
            {
                return true;
            }
            else if (iter.Current.isNeighbor(two) == true)
            {
                return true;
            }
        } while (iter.MoveNext() != false);
        return false;
    }

    public Dictionary<string, Province> getProvDict()
    {
        return provDict;
    }

    public Province getProvince(string label)
    {
        return provDict[label];
    }

    public void updateRegionControl()
    {
        int NAP = -1;
        int SAP = -1;
        int EUP = -1;
        int AFP = -1;
        int ASP = -1;
        int MEP = -1;
        int OCP = -1;
        foreach (Province i in provDict.Values)
        {
            if (i.getRegion() == "NA" && NAP > -2)
            {
                if (NAP == -1)
                {
                    NAP = i.getPlayer().getPlayerID();
                }
                else if (NAP != i.getPlayer().getPlayerID())
                {
                    NAP = -2;
                }
            }
            else if (i.getRegion() == "SA" && SAP > -2)
            {
                if (SAP == -1)
                {
                    SAP = i.getPlayer().getPlayerID();
                }
                else if (SAP != i.getPlayer().getPlayerID())
                {
                    SAP = -2;
                }
            }
            else if (i.getRegion() == "EU" && EUP > -2)
            {
                if (EUP == -1)
                {
                    EUP = i.getPlayer().getPlayerID();
                }
                else if (EUP != i.getPlayer().getPlayerID())
                {
                    EUP = -2;
                }
            }
            else if (i.getRegion() == "AF" && AFP > -2)
            {
                if (AFP == -1)
                {
                    AFP = i.getPlayer().getPlayerID();
                }
                else if (AFP != i.getPlayer().getPlayerID())
                {
                    AFP = -2;
                }
            }
            else if (i.getRegion() == "AS" && ASP > -2)
            {
                if (ASP == -1)
                {
                    ASP = i.getPlayer().getPlayerID();
                }
                else if (ASP != i.getPlayer().getPlayerID())
                {
                    ASP = -2;
                }
            }
            else if (i.getRegion() == "ME" && MEP > -2)
            {
                if (MEP == -1)
                {
                    MEP = i.getPlayer().getPlayerID();
                }
                else if (MEP != i.getPlayer().getPlayerID())
                {
                    MEP = -2;
                }
            }
            else if (i.getRegion() == "OC" && OCP > -2)
            {
                if (OCP == -1)
                {
                    OCP = i.getPlayer().getPlayerID();
                }
                else if (OCP != i.getPlayer().getPlayerID())
                {
                    OCP = -2;
                }
            }
        }

        regionControl[0] = NAP;
        regionControl[1] = SAP;
        regionControl[2] = EUP;
        regionControl[3] = AFP;
        regionControl[4] = ASP;
        regionControl[5] = MEP;
        regionControl[6] = OCP;
    }

    public int[] getRegionControl()
    {
        return regionControl;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
