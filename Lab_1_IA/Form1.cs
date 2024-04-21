using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_1_IA
{
    public partial class Form1 : Form
    {
        Dictionary<int, string> Essences;
        Dictionary<int, Rel> Relations;
        List<BZ> bz = new List<BZ>();

        public Form1()
        {
            InitializeComponent();
        }

        private void onLoadForm(object sender, EventArgs e)
        {
            Essences = new Dictionary<int, string>();
            Relations = new Dictionary<int, Rel>();

            int i = 0;
            string s;
            StreamReader f = new StreamReader("../../../Resurs/Knowledge_base.txt");
            while ((s = f.ReadLine()) != null)
            {
                if (s == "#1")
                {
                    i = 1;
                    continue;
                }
                if (s == "#2")
                {
                    i = 2;
                    continue;
                }
                if (s == "#3")
                {
                    i = 3;
                    continue;
                }
                
                if (i == 1)
                {
                    Essences_text.Text += s + '\n';

                    string str = "";
                    int key = 0;
                    for(int a = 0; a<s.Length; a++)
                    {
                        if (s[a] == ':')
                        {
                            key = System.Convert.ToInt32(str);
                            str = "";
                        }
                        else
                        {
                            str += s[a];
                        }
                    }
                    Essences.Add(key, str);
                }
                if (i == 2)
                {
                    Relation_text.Text += s + '\n';

                    int key = 0;
                    int b = 0;
                    string str = "";
                    string relation = "";
                    bool number = true;
                    for(int a = 0; a<s.Length; a++)
                    {
                        if(s[a] == ':')
                        {
                            if (number)
                            {
                                key = System.Convert.ToInt32(str);
                                str = "";
                                number = false;
                            }
                            else
                            {
                                relation = str;
                                str = "";
                            }
                        }
                        else
                        {
                            str += s[a];
                        }
                    }
                    if(relation != "")
                    {
                        b = System.Convert.ToInt32(str);
                        Relations.Add(key, new Rel(relation, b));
                    }
                    else
                    {
                        Relations.Add(key, new Rel(str, b));
                    }
                }
                if (i == 3)
                {
                    Knowledge_text.Text += s + '\n';

                    int a = 0;
                    int b = 0;
                    int c = 0;

                    string str = "";
                    bool number = true;
                    for(int j = 0; j<s.Length; j++)
                    {
                        if(s[j] != ':')
                            str += s[j];
                        else
                        {
                            if(number)
                            {
                                a = System.Convert.ToInt32(str);
                                number = false;
                                str = "";
                            }
                            else
                            {
                                b = System.Convert.ToInt32(str);
                                str = "";
                            }
                        }
                    }
                    c = System.Convert.ToInt32(str);
                    bz.Add(new BZ(a, b, c));
                }
            }
            foreach(var rel in Relations)
            {
                Answer_text.Text += rel.Key + " " + rel.Value.relation + " " + rel.Value.b + '\n';
            }
        }

        private void onAnswer(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            int c = 0;

            bool n_1 = false;
            bool n_2 = false;
            bool n_3 = false;

            if(num_1.Text != "?")
            {
                a = System.Convert.ToInt32(num_1.Text);
                n_1 = true;
            }
            if(num_2.Text != "?")
            {
                b = System.Convert.ToInt32(num_2.Text);
                n_2 = true;
            }
            if(num_3.Text != "?")
            {
                c = System.Convert.ToInt32(num_3.Text);
                n_3 = true;
            }


            if(n_1 && n_2 && n_3)
            {
                Answer_text.Text = AnswerABC(a, b, c);
            }
            if(!n_1 && !n_2 && !n_3)
            {
                Answer_text.Text = Answer();
            }

            if(!n_1 && n_2 && n_3)
            {
                Answer_text.Text = AnswerBC(b, c);
            }

            if(n_1 && n_2 && !n_3)
            {
                Answer_text.Text = AnswerAB(a, b);
            }

            if(n_1 && !n_2 && !n_3){
                Answer_text.Text = AnswerA(a);
            }
            if (!n_1 && !n_2 && n_3)
            {
                Answer_text.Text = AnswerC(c);
            }
            
        }

        public string AnswerC(int c)
        {
            string answer = "";

            foreach(var e in Essences)
            {
                bool f = true;
                foreach(var basa in bz)
                {
                        string str = isPresent(e.Key, basa.b, c);
                        if (str != "" && f)
                        {
                        f = false;
                            answer += e.Value + " " + str;
                        }
                }
            }

            return answer;
        }

        public string AnswerA(int a)
        {
            string answer = "";

            foreach(var basa in bz){
                if(a == basa.a)
                {
                    string str = isPresent(a, basa.b, basa.c);
                    if(str != "")
                    {
                        answer += Essences[a] + " " + str;
                    }
                }
            }

            return answer;
        }

        public string AnswerAB(int a, int b)
        {
            string answer = "";

            foreach(var e in Essences)
            {
                string str = isPresent(a, b, e.Key);
                if(str != "")
                {
                    answer += Essences[a] + " " + str;
                }
            }

            return answer;
        }

        public string AnswerBC(int b, int c)
        {
            string answer = "";

            foreach(var e in Essences)
            {
                string str = isPresent(e.Key, b, c);
                if(str != "")
                {
                    answer += e.Value + " " + str;
                }
            }

            return answer;
        }

        public string AnswerABC(int a, int b, int c)
        {
            string answer = "";

            if(isPresent(a,b,c) == "")
            {
                answer = "false";
            }
            else
            {
                answer = "true";
            }

            return answer;
        }

        public string Answer()
        {
            string answer = "";

            foreach(var e in Essences)
            {
                foreach(var basa in bz)
                {
                    if(e.Key == basa.a)
                    {
                        string str = isPresent(e.Key, basa.b, basa.c);
                        if (str != "")
                        {
                            answer += e.Value + " " + str;
                        }
                    }
                }
            }
            return answer;
        }

        public string isPresent(int a, int b, int c)
        {
            string answer = "";
            foreach(var basa in bz)
            {
                if(a == basa.a && Relations[basa.b].b == 1)
                {
                    answer += isPresent(basa.c, b, c);
                }
                if(a == basa.a && b == basa.b && c == basa.c)
                {
                    answer += Relations[b].relation + " " + Essences[c] + '\n';
                }
            }

            return answer;
        }
    }

    public struct BZ
    {
        public int a, b, c;
        public BZ(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public struct Rel
    {
        public string relation;
        public int b;
        public Rel(string str, int b)
        {
            this.relation = str;
            this.b = b;
        }
    }
}
