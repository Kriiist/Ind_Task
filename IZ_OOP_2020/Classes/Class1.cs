using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ_OOP_2020.Classes
{
    
    public abstract class repairHandler
    {
        public repairHandler next { get; set; }
        public abstract typeCrash Handle(typeCrash TC, int route, Label logs);
    }

    public class Electric : repairHandler
    {

        public override typeCrash Handle(typeCrash TC, int route, Label logs)
        {
            logs.Text = "";
            logs.Text += $"\n Путь {route}: Электрик выехал для устранения проблемы.";
            if(TC.electric == true)
                logs.Text += $"\n Путь {route}: Электрик устранил проблему.";
            else
                logs.Text += $"\n Путь {route}: Электрик не выявил проблемы.";
            TC.electric = false;

            if (next != null)
                if (TC.mechanic == true || TC.rail == true)
                {
                    logs.Text += $"\n Путь {route}: Пути все ещё неисправны.";
                    TC = next.Handle(TC, route, logs);
                }
            else
                    logs.Text += $"\n Путь {route}: Пути исправны!";
            return TC;
        }
    }

    public class Mechanic : repairHandler
    {

        public override typeCrash Handle(typeCrash TC, int route, Label logs)
        {
            logs.Text += $"\n Путь {route}: Механик выехал для устранения проблемы.";
            if (TC.mechanic == true)
                logs.Text += $"\n Путь {route}: Механик устранил проблему.";
            else
                logs.Text += $"\n Путь {route}: Механик не выявил проблемы.";
            TC.mechanic = false;
            if (next != null)
                if (TC.rail == true)
                {
                    logs.Text += $"\n Путь {route}: Пути все ещё неисправны.";
                    TC = next.Handle(TC, route, logs);
                }
            else
                    logs.Text += $"\n Путь {route}: Пути исправны!";
            return TC;
        }
    }

    public class RailMaster : repairHandler
    {

        public override typeCrash Handle(typeCrash TC, int route, Label logs)
        {
            logs.Text += $"\n Путь {route}: Стрелочник выехал для устранения проблемы.";
            if (TC.rail == true)
                logs.Text += $"\n Путь {route}: Стрелочник устранил проблему.";
            else
                logs.Text += $"\n Путь {route}: Стрелочник не выявил проблемы.";
            TC.rail = false;
            logs.Text += $"\n Путь {route}: Пути исправны!";
            return TC;
        }
    }


    //Фабрики
    public class typeCrash
    {
        public bool electric = false;
        public bool mechanic = false;
        public bool rail = false;
    }

    public class crashInfo
    {
        public typeCrash TC;
        public int route;
        public int LP;

        public crashInfo()
        {
            TC = null;
            route = 0;
            LP = 0;
        }
    }
    public class route1 : LineSys
    {
        ToolTip TT;
        public Trams TR1 = new TramsRoute1();
        public LP LPR1 = new LPRoute1();
        public Persons RP1 = new PersonsRoute1();
        public override void CreateRoute()
        {
            LPRoute1 LPR1 = new LPRoute1();
        }

        public override void HideCrash(int num)
        {
            TT.Hide(LPR1.linePart[num].Pic);
        }

        public override void ShowCrash(int num, typeCrash TC)
        {
            TT = new ToolTip();
            //TT.SetToolTip(LPR1.linePart[num].Pic, "error");
            string error = "";
            if (TC.electric == true)
                error += "поломка электроники ";
            if (TC.mechanic == true)
                error += "поломка механики ";
            if (TC.rail == true)
                error += "поломка путей";
            TT.Show(error, LPR1.linePart[num].Pic);
        }

        public override void LinkRoute(MainForm M)
        {
            string picName = "LPY00";
            for (int i = 0; i < LPR1.countLP; i++)
            {
                picName = picName.Substring(0, picName.Length - 2);
                if (i < 9)
                    picName += "0";
                picName += (i + 1).ToString();

                PictureBox PB = null;
                PB = M.getPic(picName);

                if (PB != null)
                    LPR1.linePart[i].Pic = PB;
                //if (LPR1.linePart[i].Pic != null)
                    //LPR1.linePart[i].Pic.Visible = true;
            }
        }

        public override crashInfo MoveRoute() 
        {
            TramsRoute1 TR1 = new TramsRoute1();
            crashInfo CI = TR1.Move();
            return CI;
        }

        public override typeCrash FixCrash(int num, typeCrash TC, Label logs)
        {
            typeCrash T = RP1.routeFix(TC, num, logs);
            return T;
        }

    }
    public class route2 : LineSys
    {
        ToolTip TT;
        public Trams TR2 = new TramsRoute2();
        public LP LPR2 = new LPRoute2();
        public Persons RP2 = new PersonsRoute2();
        public override void CreateRoute()
        {
            LPRoute2 LPR2 = new LPRoute2();
        }

        public override void HideCrash(int num)
        {
            TT.Hide(LPR2.linePart[num].Pic);
        }
        public override void ShowCrash(int num, typeCrash TC)
        {
            TT = new ToolTip();
            //TT.SetToolTip(LPR2.linePart[num].Pic, "error");
            string error = "";
            if (TC.electric == true)
                error += "поломка электроники ";
            if (TC.mechanic == true)
                error += "поломка механики ";
            if (TC.rail == true)
                error += "поломка путей";
            TT.Show(error, LPR2.linePart[num].Pic);
        }


        public override void LinkRoute(MainForm M)
        {
            string picName = "LPG00";
            for (int i = 0; i < LPR2.countLP; i++)
            {
                picName = picName.Substring(0, picName.Length - 2);
                if (i < 9)
                    picName += "0";
                picName += (i + 1).ToString();

                PictureBox PB = null;
                PB = M.getPic(picName);

                if (PB != null)
                    LPR2.linePart[i].Pic = PB;
                //if (LPR2.linePart[i].Pic != null)
                    //LPR2.linePart[i].Pic.Visible = true;
            }
        }

        public override crashInfo MoveRoute()
        {
            TramsRoute2 TR2 = new TramsRoute2();
            crashInfo CI = TR2.Move();
            return CI;
        }

        public override typeCrash FixCrash(int num, typeCrash TC, Label logs)
        {
            typeCrash T = RP2.routeFix(TC, num, logs);
            return T;
        }

    }
    public class route3 : LineSys
    {
        ToolTip TT;
        public Trams TR3 = new TramsRoute3();
        public LP LPR3 = new LPRoute3();
        public Persons RP3 = new PersonsRoute3();
        public override void CreateRoute()
        {
            LPRoute3 LPR3 = new LPRoute3();
        }

        public override void HideCrash(int num)
        {
            TT.Hide(LPR3.linePart[num].Pic);
        }

        public override void ShowCrash(int num, typeCrash TC)
        {
            TT = new ToolTip();
            //TT.SetToolTip(LPR3.linePart[num].Pic, "error");
            string error = "";
            if (TC.electric == true)
                error += "поломка электроники ";
            if (TC.mechanic == true)
                error += "поломка механики ";
            if (TC.rail == true)
                error += "поломка путей";
            TT.Show(error, LPR3.linePart[num].Pic);
        }

        public override void LinkRoute(MainForm M)
        {
            string picName = "LPB00";
            for (int i = 0; i < LPR3.countLP; i++)
            {
                picName = picName.Substring(0, picName.Length - 2);
                if (i < 9)
                    picName += "0";
                picName += (i + 1).ToString();

                PictureBox PB = null;
                PB = M.getPic(picName);

                if (PB != null)
                    LPR3.linePart[i].Pic = PB;
                //if (LPR3.linePart[i].Pic != null)
                   // LPR3.linePart[i].Pic.Visible = true;
            }
        }

        public override crashInfo MoveRoute()
        {
            TramsRoute3 TR3 = new TramsRoute3();
            crashInfo CI = TR3.Move();
            return CI;
        }


        public override typeCrash FixCrash(int num, typeCrash TC, Label logs)
        {
            typeCrash T = RP3.routeFix(TC, num, logs);
            return T;
        }
    }
    public class route4 : LineSys
    {
        ToolTip TT;
        public Trams TR4 = new TramsRoute4();
        public LP LPR4 = new LPRoute4();
        public Persons RP4 = new PersonsRoute4();
        public override void CreateRoute()
        {
            LPRoute4 LPR4 = new LPRoute4();
        }

        public override void HideCrash(int num)
        {
            TT.Hide(LPR4.linePart[num].Pic);
        }

        public override void ShowCrash(int num, typeCrash TC)
        {
            TT = new ToolTip();
            //TT.SetToolTip(LPR4.linePart[num].Pic, "error");
            string error = "";
            if (TC.electric == true)
                error += "поломка электроники ";
            if (TC.mechanic == true)
                error += "поломка механики ";
            if (TC.rail == true)
                error += "поломка путей";
            TT.Show(error, LPR4.linePart[num].Pic);
        }

        public override void LinkRoute(MainForm M)
        {
            string picName = "LPR00";
            for (int i = 0; i < LPR4.countLP; i++)
            {
                picName = picName.Substring(0, picName.Length - 2);
                if (i < 9)
                    picName += "0";
                picName += (i + 1).ToString();

                PictureBox PB = null;
                PB = M.getPic(picName);

                if (PB != null)
                    LPR4.linePart[i].Pic = PB;
                //if (LPR4.linePart[i].Pic != null)
                    //LPR4.linePart[i].Pic.Visible = true;
            }
        }

        public override crashInfo MoveRoute()
        {
            TramsRoute4 TR4 = new TramsRoute4();
            crashInfo CI = TR4.Move();
            return CI;
        }

        public override typeCrash FixCrash(int num, typeCrash TC, Label logs)
        {
            typeCrash T = RP4.routeFix(TC, num, logs);
            return T;
        }
    }
    public class route5 : LineSys
    {
        ToolTip TT;
        public Trams TR5 = new TramsRoute5();
        public LP LPR5 = new LPRoute5();
        public Persons RP5 = new PersonsRoute5();
        public override void CreateRoute()
        {
            LPRoute5 LPR5 = new LPRoute5();
        }

        public override void HideCrash(int num)
        {
            TT.Hide(LPR5.linePart[num].Pic);
        }

        public override void ShowCrash(int num, typeCrash TC)
        {
            TT = new ToolTip();
            //TT.SetToolTip(LPR5.linePart[num].Pic, "error");
            string error = "";
            if (TC.electric == true)
                error += "поломка электроники ";
            if (TC.mechanic == true)
                error += "поломка механики ";
            if (TC.rail == true)
                error += "поломка путей";
            TT.Show(error, LPR5.linePart[num].Pic);
        }

        public override void LinkRoute(MainForm M)
        {
            string picName = "LPP00";
            for (int i = 0; i < LPR5.countLP; i++)
            {
                picName = picName.Substring(0, picName.Length - 2);
                if (i < 9)
                    picName += "0";
                picName += (i + 1).ToString();

                PictureBox PB = null;
                PB = M.getPic(picName);

                if (PB != null)
                    LPR5.linePart[i].Pic = PB;
                //if (LPR5.linePart[i].Pic != null)
                    //LPR5.linePart[i].Pic.Visible = true;
            }
        }

        public override crashInfo MoveRoute()
        {
            TramsRoute5 TR5 = new TramsRoute5();
            crashInfo CI = TR5.Move();
            return CI;
        }

        public override typeCrash FixCrash(int num, typeCrash TC, Label logs)
        {
            typeCrash T =  RP5.routeFix(TC,num, logs);
            return T;
        }


    }
    //Абстрактные продукты
    public abstract class Trams
    {
        public abstract crashInfo Move();
    }
    public abstract class LP
    {
        public string color;
        public int countLP;
        public LinePart[] linePart;
    }
    public abstract class Persons
    {
        public abstract typeCrash routeFix(typeCrash TC, int route, Label logs);
    }

    //Конкретные продукты
    public class TramsRoute1 : Trams
    {
        public Tram[] tr1;

        public TramsRoute1()
        {
            tr1 = new Tram[6];
            for (int i = 0; i < 6; i++)
            {
                tr1[i] = new Tram();
                tr1[i].OnLine = true;
                tr1[i].LineNum = 1;
            }
            tr1[0].LastPart = 0;
            tr1[1].LastPart = 3;
            tr1[2].LastPart = 6;
            tr1[3].LastPart = 9;
            tr1[4].LastPart = 12;
            tr1[5].LastPart = 15;
        }

        public override crashInfo Move()
        {
            crashInfo CI =  new crashInfo();
            for (int i = 0; i < 6; i++)
            {
                CI.TC = tr1[i].checkCrash();
                if (CI.TC != null)
                {
                    CI.LP = tr1[i].LastPart;
                    CI.route = 1;
                    return CI;
                }
                
                tr1[i].LastPart++;
            }
            return CI;
        }

    }
    public class TramsRoute2 : Trams
    {
        public Tram[] tr2;

        public TramsRoute2()
        {
            tr2 = new Tram[6];
            for (int i = 0; i < 6; i++)
            {
                tr2[i] = new Tram();
                tr2[i].OnLine = true;
                tr2[i].LineNum = 1;
            }
            tr2[0].LastPart = 0;
            tr2[1].LastPart = 3;
            tr2[2].LastPart = 6;
            tr2[3].LastPart = 9;
            tr2[4].LastPart = 12;
            tr2[5].LastPart = 15;
        }

        public override crashInfo Move()
        {
            crashInfo CI = new crashInfo();
            for (int i = 0; i < 6; i++)
            {
                CI.TC = tr2[i].checkCrash();
                if (CI.TC != null)
                {
                    CI.LP = tr2[i].LastPart;
                    CI.route = 2;
                    return CI;
                }
                tr2[i].LastPart++;
            }
            return CI;
        }

    }
    public class TramsRoute3 : Trams
    {
        public Tram[] tr3;

        public TramsRoute3()
        {
            tr3 = new Tram[6];
            for (int i = 0; i < 6; i++)
            {
                tr3[i] = new Tram();
                tr3[i].OnLine = true;
                tr3[i].LineNum = 1;
            }
            tr3[0].LastPart = 0;
            tr3[1].LastPart = 3;
            tr3[2].LastPart = 6;
            tr3[3].LastPart = 9;
            tr3[4].LastPart = 12;
            tr3[5].LastPart = 15;
        }

        public override crashInfo Move()
        {
            crashInfo CI = new crashInfo();
            for (int i = 0; i < 6; i++)
            {
                CI.TC = tr3[i].checkCrash();
                if (CI.TC != null)
                {
                    CI.LP = tr3[i].LastPart;
                    CI.route = 3;
                    return CI;
                }
                tr3[i].LastPart++;
            }
            return CI;
        }

    }
    public class TramsRoute4 : Trams
    {
        public Tram[] tr4;

        public TramsRoute4()
        {
            tr4 = new Tram[6];
            for (int i = 0; i < 6; i++)
            {
                tr4[i] = new Tram();
                tr4[i].OnLine = true;
                tr4[i].LineNum = 1;
            }
            tr4[0].LastPart = 0;
            tr4[1].LastPart = 3;
            tr4[2].LastPart = 6;
            tr4[3].LastPart = 9;
            tr4[4].LastPart = 12;
            tr4[5].LastPart = 15;
        }

        public override crashInfo Move()
        {
            crashInfo CI = new crashInfo();
            for (int i = 0; i < 6; i++)
            {
                CI.TC = tr4[i].checkCrash();
                if (CI.TC != null)
                {
                    CI.LP = tr4[i].LastPart;
                    CI.route = 4;
                    return CI;
                }
                tr4[i].LastPart++;
            }
            return CI;
        }

    }
    public class TramsRoute5 : Trams
    {
        public Tram[] tr5;

        public TramsRoute5()
        {
            tr5 = new Tram[6];
            for (int i = 0; i < 6; i++)
            {
                tr5[i] = new Tram();
                tr5[i].OnLine = true;
                tr5[i].LineNum = 1;
            }
            tr5[0].LastPart = 0;
            tr5[1].LastPart = 3;
            tr5[2].LastPart = 6;
            tr5[3].LastPart = 9;
            tr5[4].LastPart = 12;
            tr5[5].LastPart = 15;
        }

        public override crashInfo Move()
        {
            crashInfo CI = new crashInfo();
            for (int i = 0; i < 6; i++)
            {
                CI.TC = tr5[i].checkCrash();
                if (CI.TC != null)
                {
                    CI.LP = tr5[i].LastPart;
                    CI.route = 5;
                    return CI;
                }
                tr5[i].LastPart++;
            }
            return CI;
        }

    }
    public class LPRoute1 : LP
    {
        
        public LPRoute1()
        {
            color = "желтая";
            countLP = 16;
            linePart = new LinePart[countLP];
            for (int i = 0; i < countLP; i++)
            {
                linePart[i] = new LinePart(i, 1);
            }
        
        }

    }
    public class LPRoute2 : LP
    {
        
        public LPRoute2()
        {
            color = "зеленая";
            countLP = 20;
            linePart = new LinePart[countLP];
            for (int i = 0; i < countLP; i++)
            {
                linePart[i] = new LinePart(i, 2);
            }

        }
    }
    public class LPRoute3 : LP
    {
        
        public LPRoute3()
        {
            color = "синяя";
            countLP = 22;
            linePart = new LinePart[countLP];
            for (int i = 0; i < countLP; i++)
            {
                linePart[i] = new LinePart(i, 3);
            }

        }
    }
    public class LPRoute4 : LP
    {
        
        public LPRoute4()
        {
            color = "красная";
            countLP = 22;
            linePart = new LinePart[countLP];
            for (int i = 0; i < countLP; i++)
            {
                linePart[i] = new LinePart(i, 4);
            }

        }
    }
    public class LPRoute5 : LP
    {
        
        public LPRoute5()
        {
            color = "фиолетовая";
            countLP = 20;
            linePart = new LinePart[countLP];
            for (int i = 0; i < countLP; i++)
            {
                linePart[i] = new LinePart(i, 5);
            }

        }
    }
    public class PersonsRoute1 : Persons
    {
        public override typeCrash routeFix(typeCrash TC, int route, Label logs)
        {
            Electric ER1 = new Electric();
            Mechanic MR1 = new Mechanic();
            RailMaster RR1 = new RailMaster();
            ER1.next = MR1;
            MR1.next = RR1;
            RR1.next = null;

            TC = ER1.Handle(TC, route,logs);
            return TC;
        }  
    }
    public class PersonsRoute2 : Persons
    {
        public override typeCrash routeFix(typeCrash TC, int route, Label logs)
        {
            Electric ER2 = new Electric();
            Mechanic MR2 = new Mechanic();
            RailMaster RR2 = new RailMaster();
            ER2.next = MR2;
            MR2.next = RR2;
            RR2.next = null;

            TC = ER2.Handle(TC, route,logs);
            return TC;
        }

    }
    public class PersonsRoute3 : Persons
    {
        public override typeCrash routeFix(typeCrash TC, int route, Label logs)
        {
            Electric ER3 = new Electric();
            Mechanic MR3 = new Mechanic();
            RailMaster RR3 = new RailMaster();
            ER3.next = MR3;
            MR3.next = RR3;
            RR3.next = null;

            TC = ER3.Handle(TC, route, logs);
            return TC;
        }

    }
    public class PersonsRoute4 : Persons
    {
        public override typeCrash routeFix(typeCrash TC, int route, Label logs)
        {
            Electric ER4 = new Electric();
            Mechanic MR4 = new Mechanic();
            RailMaster RR4 = new RailMaster();
            ER4.next = MR4;
            MR4.next = RR4;
            RR4.next = null;

            TC = ER4.Handle(TC, route, logs);
            return TC;
        }
    }
    public class PersonsRoute5 : Persons
    {
        public override typeCrash routeFix(typeCrash TC, int route, Label logs)
        {
            Electric ER5 = new Electric();
            Mechanic MR5 = new Mechanic();
            RailMaster RR5 = new RailMaster();
            ER5.next = MR5;
            MR5.next = RR5;
            RR5.next = null;

            TC = ER5.Handle(TC, route, logs);
            return TC;
        }
    }

    public abstract class LineSys
    {

        public abstract void CreateRoute();

        public abstract crashInfo MoveRoute();

        public abstract void ShowCrash(int num, typeCrash TC);

        public abstract void HideCrash(int num);

        public abstract void LinkRoute(MainForm M);

        public abstract typeCrash FixCrash(int route, typeCrash TC, Label logs);

        public void Method()
        {
            throw new System.NotImplementedException();
        }
    }


}
