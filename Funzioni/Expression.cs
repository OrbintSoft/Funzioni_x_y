using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Funzioni
{
/****************************************/
#region gestionePolinomi
  public class Monomio
    {
        public Monomio(double c, double g)
        {
            coefficiente = c;
            grado = g;
        }
        public double coefficiente;
        public double grado;
        public override string ToString()
        {
            string s = "";
            if (coefficiente != 0) s += coefficiente.ToString();
            if (grado != 0)
            {
                s += "*x";
                if (grado != 1) s += ("^" + grado.ToString());
            }
            return s;
        }
    }
    public class Polinomio
    {
        Monomio[] monomio;
        public Monomio this[int i]
        {
            get
            {
                if (i < monomio.Length)
                    return monomio[i];
                else return null;
            }
            set
            {
                if (i < monomio.Length)
                    monomio[i] = value;
            }
        }
        public Polinomio(string stringa)
        {
            List<Monomio> polinomio = new List<Monomio>();
            int i;
            string coeff = "";
            string grado = "";
            for (i = 0; i <= stringa.Length; i++)
            {
                if ((i == stringa.Length) || (stringa[i] == '-') || (stringa[i] == '+'))
                {
                    if (coeff == "") coeff = "1";
                    else if (coeff == "-") coeff = "-1";
                    if (grado == "") grado = "0";
                    else if (grado == "x") grado = "1";
                    Convert.ToDouble(grado);
                    polinomio.Add(new Monomio(Convert.ToDouble(coeff), Convert.ToDouble(grado)));
                    grado = "";
                    coeff = "";
                    if ((i < stringa.Length) && (stringa[i] == '-')) coeff = "-" + coeff;
                }
                else if (stringa[i] == 'x')
                {
                    grado = "x";
                }
                else if ((stringa[i] == '^') || (stringa[i] == '*') || (stringa[i] == '(') || (stringa[i] == ')'))
                {
                    //
                }
                else if (grado == "")
                {
                    coeff += stringa[i];
                }
                else
                {
                    if (grado == "x") grado = "";
                    grado += stringa[i];
                }
            }
            monomio = polinomio.ToArray();
        }
        public Polinomio(List<Monomio> m)
        {
            monomio = m.ToArray();
        }
        public override string ToString()
        {
            string polinomio = "";
            for (int i = 0; i < monomio.Length; i++)
                polinomio += monomio[i].ToString() + "+";
            polinomio = polinomio.Remove(polinomio.Length - 1);
            return polinomio;
        }
        public int Length
        {
            get
            {
                return monomio.Length;
            }
        }
    }
#endregion
/****************************************/
/****************************************/
    public class Expression
    {
        private static char[] operatori = { '+', '-', '/', '*', '^', 'r', 'l', 's', 'c', 't', 'E' };
        private static char[] cifre = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'i', ',' };
        private static char[] parentesiA = { '(', '[', '{' };
        private static char[] parentesiC = { ')', ']', '}' };
        //private static char[] parentesi = parentesiA+parentesiC;
        private bool cifra(char c)
        {
            foreach (char i in cifre)
            {
                if (i == c) return true;
            }
            return false;
        }
        private bool operazione(char o)
        {
            foreach (char i in operatori)
            {
                if (i == o) return true;
            }
            return false;
        }
        private bool isParentesiA(char p)
        {
            foreach (char i in parentesiA)
            {
                if (i == p) return true;
            }
            return false;
        }
        private bool isParentesiC(char p)
        {
            foreach (char i in parentesiC)
            {
                if (i == p) return true;
            }
            return false;
        }
        /************************************************/
        #region operazioni polinomi
        private Monomio prodotto(Monomio a, Monomio b)
        {
            Monomio r = new Monomio(a.coefficiente * b.coefficiente, a.grado + b.grado);
            return r;
        }
        private Polinomio prodotto(Polinomio a, Polinomio b)
        {
            List<Monomio> polinomio = new List<Monomio>();
            Polinomio p;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    polinomio.Add(prodotto(a[i], b[j]));
                }
            }
            p = new Polinomio(polinomio);
            return p;
        }
        private Polinomio somma(Polinomio a, Polinomio b)
        {
            List<Monomio> polinomio = new List<Monomio>();
            Polinomio p;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i].grado == b[j].grado)
                    {
                        a[i].coefficiente += b[j].coefficiente;
                        b[j].coefficiente = 0;
                    }
                }
            }
            for (int i = 0; i < a.Length; i++) polinomio.Add(a[i]);
            for (int j = 0; j < b.Length; j++) polinomio.Add(b[j]);
            p = new Polinomio(polinomio);
            return p;
        }
        private Polinomio differenza(Polinomio a, Polinomio b)
        {
            List<Monomio> polinomio = new List<Monomio>();
            Polinomio p;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i].grado == b[j].grado)
                    {
                        a[i].coefficiente -= b[j].coefficiente;
                        b[j].coefficiente = 0;
                    }
                }
            }
            for (int i = 0; i < a.Length; i++) polinomio.Add(a[i]);
            for (int j = 0; j < b.Length; j++) polinomio.Add(b[j]);
            p = new Polinomio(polinomio);
            return p;
        }
        public Polinomio integraPolinomio(Polinomio p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p[i].grado += 1;
                p[i].coefficiente /= p[i].grado;
            }
            return p;
        }
        #endregion
        /************************************/
        private string semplificaMoltiplicazioni(int start, string espressione)
        {
            int i = start;
            string before = "";
            string after = "";
            string pol1 = "";
            string pol2 = "";
            if (espressione.IndexOf('(', start) > -1)
            {
                while (espressione[i] != '(')
                {
                    before += espressione[i];
                    i++;
                }
                i++;
                while (espressione[i] != ')')
                {
                    pol1 += espressione[i];
                    i++;
                }
                while ((i < espressione.Length - 3) && (espressione[i + 1] == '*'))
                {
                    i += 3;
                    while (espressione[i] != ')')
                    {
                        pol2 += espressione[i];
                        i++;
                    }
                    pol1 = (prodotto(new Polinomio(pol1), new Polinomio(pol2))).ToString();
                }
                if (i < espressione.Length - 2)
                {
                    i++;
                    after += semplificaMoltiplicazioni(i, espressione);
                }
            }
            else
                for (int n = i; n < espressione.Length; n++)
                {
                    after += espressione[n];
                }
            if (pol1 != "") pol1 = '(' + pol1 + ')';
            return before + pol1 + after;
        }
        private string semplificaAddizioni(int start, string espressione)
        {
            int i = start;
            string before = "";
            string after = "";
            string pol1 = "";
            string pol2 = "";
            if (espressione.IndexOf('(', start) > -1)
            {
                while (espressione[i] != '(')
                {
                    before += espressione[i];
                    i++;
                }
                i++;
                while (espressione[i] != ')')
                {
                    pol1 += espressione[i];
                    i++;
                }
                while ((i < espressione.Length - 3) && (espressione[i + 1] == '*'))
                {
                    i += 3;
                    while (espressione[i] != ')')
                    {
                        pol2 += espressione[i];
                        i++;
                    }
                    pol1 = (prodotto(new Polinomio(pol1), new Polinomio(pol2))).ToString();
                }
                if (i < espressione.Length - 2)
                {
                    i++;
                    after += semplificaMoltiplicazioni(i, espressione);
                }
            }
            else
                for (int n = i; n < espressione.Length; n++)
                {
                    after += espressione[n];
                }
            if (pol1 != "") pol1 = '(' + pol1 + ')';
            return before + pol1 + after;
        }
        private string parentizzaPolinomi(int start, string espressione)
        {
            int i;
            i = espressione.IndexOf('*', start);
            if (i != -1)
            {
                if (espressione[i - 1] != ')')
                {
                    espressione = espressione.Insert(i, ")");
                    int j = i;
                    while ((j > 0) && (!operazione(espressione[j])))
                    {
                        j--;
                    }
                    espressione = espressione.Insert(j + 1, "(");
                }
                i++;
                if (i < espressione.Length)
                {
                    espressione = parentizzaPolinomi(i, espressione);
                }
            }
            return espressione;
        }
        public string semplifica(string espressione)
        {
            espressione = espressione.Replace("(0+", "(");
            espressione = espressione.Replace("+0)", ")");
            espressione = espressione.Replace("-0)", ")");
            espressione = espressione.Replace("(0-", "(-");
            espressione = espressione.Replace("(1*", "(");
            espressione = espressione.Replace(")*1", ")");
            espressione = espressione.Replace("*1)", ")");
            espressione = espressione.Replace("*1+", "+");
            espressione = espressione.Replace("*1-", "-");
            espressione = espressione.Replace("/1)", ")");
            espressione = espressione.Replace("^1)", ")");
            espressione = espressione.Replace("r1)", ")");
            espressione = espressione.Replace("+-", "-");
            espressione = espressione.Replace("--", "+");
            espressione = espressione.Replace("++", "+");
            if (espressione.Contains("x"))
            {
                //espressione = parentizzaPolinomi(0,espressione);
                //espressione = semplificaMoltiplicazioni(0,espressione);
            }
            return espressione;
        }
        private string codifica(string espressione)
        {
            espressione = espressione.Replace("sin", "1s");
            espressione = espressione.Replace("cos", "1c");
            espressione = espressione.Replace("tan", "1t");
            espressione = espressione.Replace(")(", ")*(");
            return espressione;
        }
        /***********************************************/
        #region operazioni tra stringhe numeriche
        private string seno(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) * Math.Sin(Convert.ToDouble(num2))).ToString();
        }
        private string coseno(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) * Math.Cos(Convert.ToDouble(num2))).ToString();
        }
        private string tangente(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) * Math.Tan(Convert.ToDouble(num2))).ToString();
        }
        private string esponenziale(string num1, string num2)
        {
            if ((num1 == "") && (num2 == "")) return "";
            else if (num1 == "") return num2;
            else
            {
                if (num2 == "") num2 = "1";
                return (Convert.ToDouble(num1) * Math.Pow(10, Convert.ToDouble(num2))).ToString();
            }
            //if (num2=="") num2="1";
            //return num1+"E"+num2;
        }
        private string logaritmo(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Math.Exp(Math.Log(Convert.ToDouble(num1), Convert.ToDouble(num2)))).ToString();
        }
        private string radice(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Math.Exp(Math.Log(Convert.ToDouble(num1), Math.E) / Convert.ToDouble(num2))).ToString();
        }
        private string potenza(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Math.Pow(Convert.ToDouble(num1), Convert.ToDouble(num2)).ToString());
        }
        private string prodotto(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
        }
        private string quoziente(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
        }
        private string somma(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
        }
        private string differenza(string num1, string num2)
        {
            if ((num1 == "") && (num2) == "") return "";
            else if (num1 == "") return num2;
            else if (num2 == "") return num1;
            else
                return (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
        }
        #endregion
        /**********************************************/
        /**********************************************/
        #region risolutore
        private string risolviNodo(ref int i, int end, string exp)
        {
            string expressNode = "";
            if ((i > end) || (exp == "")) return "";
            char[] arrayEspress = exp.ToCharArray();
            i++;
            while (!isParentesiC(arrayEspress[i]) && (i <= end))
            {
                if (isParentesiA(arrayEspress[i])) expressNode += risolviNodo(ref i, end, exp);
                else
                {
                    expressNode += arrayEspress[i];
                    i++;
                }
            }
            i++;
            return risolvi(0, expressNode.Length - 1, expressNode);
        }
        private string risolviNodi(int start, int end, string exp)
        {
            string expressNode = "";
            string before = "";
            int i = start;
            char[] arrayEspress = exp.ToCharArray();
            if ((start > end) || (exp == "")) return "";
            while (i < end)
            {
                if (isParentesiA(arrayEspress[i]))
                {
                    expressNode = risolviNodo(ref i, end, exp);
                    before += expressNode;
                }
                if (i < end) before += arrayEspress[i];
                i++;
            }
            return risolvi(start, before.Length - 1, before);
        }
        public string risolvi(int start, int end, string espressione)
        {
            char[] arrayEspress = espressione.ToCharArray();
            int i = end;
            string expressNode = "";
            string after = "";
            if ((start > end) || (end >= arrayEspress.Length) || (start < 0) || (espressione == "")) return "";
            //risolve somma e sottrazione
            if (espressione.Contains("+") | espressione.Contains("-"))
            while (i > 0)
            {
                if (arrayEspress[i] == '+')
                {
                    return somma(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else
                    if ((arrayEspress[i] == '-') && (!operazione(arrayEspress[i - 1])))
                    {
                        return differenza(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                    }
                    else
                        after = arrayEspress[i] + after;
                i--;
            }
            i = end;
            after = "";
            //risolve moltiplicazione e divisione
            if (espressione.Contains("*") | espressione.Contains("/"))
            while (i > 0)
            {
                if (arrayEspress[i] == '*')
                {
                    return prodotto(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else
                    if (arrayEspress[i] == '/')
                    {
                        return quoziente(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                    }
                    else
                        after = arrayEspress[i] + after;
                i--;
            }
            i = end;
            after = "";
            //risolve seno,coseno e tangente
            if (espressione.Contains("s") | espressione.Contains("c") | espressione.Contains("t"))
            while (i > 0)
            {
                if (arrayEspress[i] == 's')
                {
                    return seno(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else if (arrayEspress[i] == 'c')
                {
                    return coseno(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else if (arrayEspress[i] == 't')
                {
                    return tangente(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else
                    after = arrayEspress[i] + after;
                i--;
            }          
            i = end;
            after = "";
            //risolve potenza , radice e logaritmo
            if (espressione.Contains("^") | espressione.Contains("r") | espressione.Contains("l"))
            while (i > 0)
            {
                if (arrayEspress[i] == '^')
                {
                    return potenza(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else
                    if (arrayEspress[i] == 'r')
                    {
                        return radice(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                    }
                    else
                        if (arrayEspress[i] == 'l')
                        {
                            return logaritmo(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                        }
                        else
                            after = arrayEspress[i] + after;
                i--;
            }
            i = end;
            after = "";
            //risolve il formato esponenziale E
            while (i > 0)
            {
                if (arrayEspress[i] == 'E')
                {
                    return esponenziale(risolvi(0, i - 1, espressione), risolvi(0, after.Length - 1, after));
                }
                else
                    after = arrayEspress[i] + after;
                i--;
            }
            for (i = start; i <= end; i++)
            {
                expressNode += arrayEspress[i];
            }
            return expressNode;
        }
        #endregion
        /**********************************************/
        public double risultato(string espressione)
        {
            string e = espressione;
            e = codifica(e);
            e = risolviNodi(0, e.Length, e);
            return Convert.ToDouble(e);
        }
    }
}
