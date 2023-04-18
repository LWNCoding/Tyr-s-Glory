using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Board : Node2D
{
    private Dictionary<int, Province> provDict;
    private int[] regionControl;
    /// <summary>
    /// Constructor for the Board defined type.
    /// </summary>
    public Board()
    {
        provDict = new Dictionary<int, Province>();
        regionControl = new int[] { -1, -1, -1, -1, -1, -1, -1 }; //NA=0,SA=1,EU=2,AF=3,AS=4,ME=5,OC=6
    }

    public void connect()
    {
        foreach (int i in provDict.Keys)
        {
            switch (i)
            {
                case 1:
                    provDict[i].addEdge(provDict[2]);
                    provDict[i].addEdge(provDict[5]);
                    provDict[i].setRegion("NA");
                    break;
                case 2:
                    provDict[i].addEdge(provDict[1]);
                    provDict[i].addEdge(provDict[3]);
                    provDict[i].addEdge(provDict[5]);
                    provDict[i].addEdge(provDict[6]);
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].setRegion("NA");
                    break;
                case 3:
                    provDict[i].addEdge(provDict[2]);
                    provDict[i].addEdge(provDict[4]);
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].addEdge(provDict[8]);
                    provDict[i].setRegion("NA");
                    break;
                case 4:
                    provDict[i].addEdge(provDict[3]);
                    provDict[i].addEdge(provDict[25]);
                    provDict[i].setRegion("NA");
                    break;
                case 5:
                    provDict[i].addEdge(provDict[1]);
                    provDict[i].addEdge(provDict[2]);
                    provDict[i].addEdge(provDict[6]);
                    provDict[i].addEdge(provDict[9]);
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].setRegion("NA");
                    break;
                case 6:
                    provDict[i].addEdge(provDict[2]);
                    provDict[i].addEdge(provDict[5]);
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].setRegion("NA");
                    break;
                case 7:
                    provDict[i].addEdge(provDict[2]);
                    provDict[i].addEdge(provDict[3]);
                    provDict[i].addEdge(provDict[6]);
                    provDict[i].addEdge(provDict[8]);
                    provDict[i].addEdge(provDict[11]);
                    provDict[i].setRegion("NA");
                    break;
                case 8:
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].addEdge(provDict[11]);
                    provDict[i].setRegion("NA");
                    break;
                case 9:
                    provDict[i].addEdge(provDict[5]);
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].addEdge(provDict[12]);
                    provDict[i].addEdge(provDict[13]);
                    provDict[i].setRegion("NA");
                    break;
                case 10:
                    provDict[i].addEdge(provDict[5]);
                    provDict[i].addEdge(provDict[6]);
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].addEdge(provDict[9]);
                    provDict[i].addEdge(provDict[11]);
                    provDict[i].addEdge(provDict[13]);
                    provDict[i].addEdge(provDict[14]);
                    provDict[i].setRegion("NA");
                    break;
                case 11:
                    provDict[i].addEdge(provDict[7]);
                    provDict[i].addEdge(provDict[8]);
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].addEdge(provDict[14]);
                    provDict[i].setRegion("NA");
                    break;
                case 12:
                    provDict[i].addEdge(provDict[9]);
                    provDict[i].addEdge(provDict[13]);
                    provDict[i].addEdge(provDict[16]);
                    provDict[i].setRegion("NA");
                    break;
                case 13:
                    provDict[i].addEdge(provDict[9]);
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].addEdge(provDict[12]);
                    provDict[i].addEdge(provDict[14]);
                    provDict[i].addEdge(provDict[16]);
                    provDict[i].setRegion("NA");
                    break;
                case 14:
                    provDict[i].addEdge(provDict[10]);
                    provDict[i].addEdge(provDict[11]);
                    provDict[i].addEdge(provDict[13]);
                    provDict[i].addEdge(provDict[15]);
                    provDict[i].addEdge(provDict[16]);
                    provDict[i].setRegion("NA");
                    break;
                case 15:
                    provDict[i].addEdge(provDict[14]);
                    provDict[i].addEdge(provDict[20]);
                    provDict[i].setRegion("NA");
                    break;
                case 16:
                    provDict[i].addEdge(provDict[12]);
                    provDict[i].addEdge(provDict[13]);
                    provDict[i].addEdge(provDict[14]);
                    provDict[i].addEdge(provDict[17]);
                    provDict[i].setRegion("NA");
                    break;
                case 17:
                    provDict[i].addEdge(provDict[16]);
                    provDict[i].addEdge(provDict[18]);
                    provDict[i].setRegion("NA");
                    break;
                case 18:
                    provDict[i].addEdge(provDict[17]);
                    provDict[i].addEdge(provDict[19]);
                    provDict[i].setRegion("NA");
                    break;
                case 19:
                    provDict[i].addEdge(provDict[18]);
                    provDict[i].addEdge(provDict[20]);
                    provDict[i].addEdge(provDict[21]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].setRegion("SA");
                    break;
                case 20:
                    provDict[i].addEdge(provDict[15]);
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[75]);
                    provDict[i].setRegion("SA");
                    break;
                case 21:
                    provDict[i].addEdge(provDict[19]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[23]);
                    provDict[i].setRegion("SA");
                    break;
                case 22:
                    provDict[i].addEdge(provDict[19]);
                    provDict[i].addEdge(provDict[20]);
                    provDict[i].addEdge(provDict[21]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[23]);
                    provDict[i].addEdge(provDict[75]);
                    provDict[i].setRegion("SA");
                    break;
                case 23:
                    provDict[i].addEdge(provDict[21]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[24]);
                    provDict[i].setRegion("SA");
                    break;
                case 24:
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[23]);
                    provDict[i].addEdge(provDict[75]);
                    provDict[i].setRegion("SA");
                    break;
                case 25:
                    provDict[i].addEdge(provDict[4]);
                    provDict[i].addEdge(provDict[28]);
                    provDict[i].setRegion("EU");
                    break;
                case 26:
                    provDict[i].addEdge(provDict[27]);
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].setRegion("EU");
                    break;
                case 27:
                    provDict[i].addEdge(provDict[26]);
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[30]);
                    provDict[i].setRegion("EU");
                    break;
                case 28:
                    provDict[i].addEdge(provDict[25]);
                    provDict[i].addEdge(provDict[32]);
                    provDict[i].setRegion("EU");
                    break;
                case 29:
                    provDict[i].addEdge(provDict[27]);
                    provDict[i].addEdge(provDict[30]);
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].addEdge(provDict[44]);
                    provDict[i].addEdge(provDict[45]);
                    provDict[i].setRegion("EU");
                    break;
                case 30:
                    provDict[i].addEdge(provDict[27]);
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].setRegion("EU");
                    break;
                case 31:
                    provDict[i].addEdge(provDict[26]);
                    provDict[i].addEdge(provDict[30]);
                    provDict[i].addEdge(provDict[32]);
                    provDict[i].addEdge(provDict[34]);
                    provDict[i].addEdge(provDict[35]);
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].setRegion("EU");
                    break;
                case 32:
                    provDict[i].addEdge(provDict[28]);
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].addEdge(provDict[33]);
                    provDict[i].addEdge(provDict[34]);
                    provDict[i].setRegion("EU");
                    break;
                case 33:
                    provDict[i].addEdge(provDict[32]);
                    provDict[i].addEdge(provDict[65]);
                    provDict[i].setRegion("EU");
                    break;
                case 34:
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].addEdge(provDict[32]);
                    provDict[i].addEdge(provDict[35]);
                    provDict[i].addEdge(provDict[37]);
                    provDict[i].setRegion("EU");
                    break;
                case 35:
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].addEdge(provDict[34]);
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].addEdge(provDict[37]);
                    provDict[i].setRegion("EU");
                    break;
                case 36:
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[30]);
                    provDict[i].addEdge(provDict[31]);
                    provDict[i].addEdge(provDict[35]);
                    provDict[i].addEdge(provDict[37]);
                    provDict[i].addEdge(provDict[43]);
                    provDict[i].setRegion("EU");
                    break;
                case 37:
                    provDict[i].addEdge(provDict[34]);
                    provDict[i].addEdge(provDict[35]);
                    provDict[i].addEdge(provDict[39]);
                    provDict[i].setRegion("EU");
                    break;
                case 38:
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].addEdge(provDict[39]);
                    provDict[i].addEdge(provDict[41]);
                    provDict[i].setRegion("EU");
                    break;
                case 39:
                    provDict[i].addEdge(provDict[37]);
                    provDict[i].addEdge(provDict[38]);
                    provDict[i].addEdge(provDict[40]);
                    provDict[i].addEdge(provDict[41]);
                    provDict[i].setRegion("AS");
                    break;
                case 40:
                    provDict[i].addEdge(provDict[39]);
                    provDict[i].addEdge(provDict[41]);
                    provDict[i].addEdge(provDict[67]);
                    provDict[i].setRegion("AS");
                    break;
                case 41:
                    provDict[i].addEdge(provDict[38]);
                    provDict[i].addEdge(provDict[39]);
                    provDict[i].addEdge(provDict[40]);
                    provDict[i].addEdge(provDict[42]);
                    provDict[i].addEdge(provDict[43]);
                    provDict[i].setRegion("AS");
                    break;
                case 42:
                    provDict[i].addEdge(provDict[41]);
                    provDict[i].addEdge(provDict[43]);
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].addEdge(provDict[53]);
                    provDict[i].setRegion("AS");
                    break;
                case 43:
                    provDict[i].addEdge(provDict[41]);
                    provDict[i].addEdge(provDict[42]);
                    provDict[i].addEdge(provDict[44]);
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].setRegion("AS");
                    break;
                case 44:
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[36]);
                    provDict[i].addEdge(provDict[43]);
                    provDict[i].addEdge(provDict[45]);
                    provDict[i].addEdge(provDict[46]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].setRegion("AS");
                    break;
                case 45:
                    provDict[i].addEdge(provDict[29]);
                    provDict[i].addEdge(provDict[44]);
                    provDict[i].addEdge(provDict[46]);
                    provDict[i].setRegion("AS");
                    break;
                case 46:
                    provDict[i].addEdge(provDict[44]);
                    provDict[i].addEdge(provDict[45]);
                    provDict[i].addEdge(provDict[47]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].setRegion("AS");
                    break;
                case 47:
                    provDict[i].addEdge(provDict[46]);
                    provDict[i].addEdge(provDict[48]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].setRegion("AS");
                    break;
                case 48:
                    provDict[i].addEdge(provDict[47]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].addEdge(provDict[50]);
                    provDict[i].setRegion("AS");
                    break;
                case 49:
                    provDict[i].addEdge(provDict[44]);
                    provDict[i].addEdge(provDict[46]);
                    provDict[i].addEdge(provDict[47]);
                    provDict[i].addEdge(provDict[48]);
                    provDict[i].addEdge(provDict[50]);
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].addEdge(provDict[55]);
                    provDict[i].setRegion("AS");
                    break;
                case 50:
                    provDict[i].addEdge(provDict[48]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].addEdge(provDict[51]);
                    provDict[i].addEdge(provDict[55]);
                    provDict[i].setRegion("AS");
                    break;
                case 51:
                    provDict[i].addEdge(provDict[50]);
                    provDict[i].setRegion("AS");
                    break;
                case 52:
                    provDict[i].addEdge(provDict[42]);
                    provDict[i].addEdge(provDict[43]);
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].addEdge(provDict[53]);
                    provDict[i].addEdge(provDict[54]);
                    provDict[i].addEdge(provDict[55]);
                    provDict[i].setRegion("AS");
                    break;
                case 53:
                    provDict[i].addEdge(provDict[42]);
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].addEdge(provDict[54]);
                    provDict[i].setRegion("AS");
                    break;
                case 54:
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].addEdge(provDict[53]);
                    provDict[i].addEdge(provDict[55]);
                    provDict[i].addEdge(provDict[56]);
                    provDict[i].setRegion("AS");
                    break;
                case 55:
                    provDict[i].addEdge(provDict[49]);
                    provDict[i].addEdge(provDict[50]);
                    provDict[i].addEdge(provDict[52]);
                    provDict[i].addEdge(provDict[54]);
                    provDict[i].addEdge(provDict[56]);
                    provDict[i].setRegion("AS");
                    break;
                case 56:
                    provDict[i].addEdge(provDict[54]);
                    provDict[i].addEdge(provDict[55]);
                    provDict[i].addEdge(provDict[57]);
                    provDict[i].setRegion("AS");
                    break;
                case 57:
                    provDict[i].addEdge(provDict[56]);
                    provDict[i].addEdge(provDict[58]);
                    provDict[i].setRegion("OC");
                    break;
                case 58:
                    provDict[i].addEdge(provDict[56]);
                    provDict[i].addEdge(provDict[59]);
                    provDict[i].addEdge(provDict[60]);
                    provDict[i].setRegion("OC");
                    break;
                case 59:
                    provDict[i].addEdge(provDict[58]);
                    provDict[i].setRegion("OC");
                    break;
                case 60:
                    provDict[i].addEdge(provDict[58]);
                    provDict[i].addEdge(provDict[62]);
                    provDict[i].setRegion("OC");
                    break;
                case 61:
                    provDict[i].addEdge(provDict[62]);
                    provDict[i].addEdge(provDict[63]);
                    provDict[i].setRegion("OC");
                    break;
                case 62:
                    provDict[i].addEdge(provDict[60]);
                    provDict[i].addEdge(provDict[61]);
                    provDict[i].addEdge(provDict[63]);
                    provDict[i].setRegion("OC");
                    break;
                case 63:
                    provDict[i].addEdge(provDict[61]);
                    provDict[i].addEdge(provDict[62]);
                    provDict[i].addEdge(provDict[64]);
                    provDict[i].setRegion("OC");
                    break;
                case 64:
                    provDict[i].addEdge(provDict[63]);
                    provDict[i].setRegion("OC");
                    break;
                case 65:
                    provDict[i].addEdge(provDict[33]);
                    provDict[i].addEdge(provDict[66]);
                    provDict[i].addEdge(provDict[68]);
                    provDict[i].setRegion("AF");
                    break;
                case 66:
                    provDict[i].addEdge(provDict[65]);
                    provDict[i].addEdge(provDict[67]);
                    provDict[i].addEdge(provDict[69]);
                    provDict[i].setRegion("AF");
                    break;
                case 67:
                    provDict[i].addEdge(provDict[40]);
                    provDict[i].addEdge(provDict[66]);
                    provDict[i].addEdge(provDict[70]);
                    provDict[i].setRegion("AF");
                    break;
                case 68:
                    provDict[i].addEdge(provDict[65]);
                    provDict[i].addEdge(provDict[69]);
                    provDict[i].addEdge(provDict[71]);
                    provDict[i].addEdge(provDict[75]);
                    provDict[i].setRegion("AF");
                    break;
                case 69:
                    provDict[i].addEdge(provDict[66]);
                    provDict[i].addEdge(provDict[68]);
                    provDict[i].addEdge(provDict[70]);
                    provDict[i].addEdge(provDict[71]);
                    provDict[i].setRegion("AF");
                    break;
                case 70:
                    provDict[i].addEdge(provDict[67]);
                    provDict[i].addEdge(provDict[69]);
                    provDict[i].addEdge(provDict[71]);
                    provDict[i].addEdge(provDict[73]);
                    provDict[i].setRegion("AF");
                    break;
                case 71:
                    provDict[i].addEdge(provDict[68]);
                    provDict[i].addEdge(provDict[69]);
                    provDict[i].addEdge(provDict[70]);
                    provDict[i].addEdge(provDict[72]);
                    provDict[i].addEdge(provDict[73]);
                    provDict[i].setRegion("AF");
                    break;
                case 72:
                    provDict[i].addEdge(provDict[71]);
                    provDict[i].addEdge(provDict[73]);
                    provDict[i].setRegion("AF");
                    break;
                case 73:
                    provDict[i].addEdge(provDict[70]);
                    provDict[i].addEdge(provDict[71]);
                    provDict[i].addEdge(provDict[72]);
                    provDict[i].addEdge(provDict[74]);
                    provDict[i].setRegion("AF");
                    break;
                case 74:
                    provDict[i].addEdge(provDict[73]);
                    provDict[i].setRegion("AF");
                    break;
                case 75:
                    provDict[i].addEdge(provDict[20]);
                    provDict[i].addEdge(provDict[22]);
                    provDict[i].addEdge(provDict[24]);
                    provDict[i].addEdge(provDict[68]);
                    provDict[i].setRegion("SA");
                    break;
            }
        }
    }

    public void addProv(int lab, Province one)
    {
        provDict.Add(lab, one);
    }

    public bool canAttack(Unit dude, Province one, Province two)
    {   if(dude.attacked()){
            one = getProvince(one.getnewLab());
            two = getProvince(two.getnewLab());
            IEnumerator<Province> iter = one.getAdj().GetEnumerator(); //System.Collections.Generic.IEnumerator<Province>
            while (iter.MoveNext() != false) 
            {
                
                if (iter.Current.Equals(two))
                {
                    return true;
                }
                else if (iter.Current.isNeighbor(two) == true)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Dictionary<int, Province> getProvDict()
    {
        return provDict;
    }

    public Province getProvince(int label)
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
