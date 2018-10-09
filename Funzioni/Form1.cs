using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Funzioni
{
    public partial class MainForm : Form
    {
        Boolean showCoordLabel = false;
        List<Double> zValue;
        public MainForm()
        {
            InitializeComponent();
        }
        Color HeighToColor(Double  value,Double  min, Double  max)
        {
            value += Math.Abs(min);
            Double  range =((max - min) / (256 * 3));
            int red=0;
            int green=0;
            int blue=255;
            while ((blue > 0) && (value > 0))
            {
                value -= range;
                blue--;
                green++;
            }
            while ((green > 0) && (value > 0))
            {
                value-= range;
                green--;
                red++;
            }
            while ((green < red) && (value > 0))
            {
                value -= range;
                green++;
            }
            return Color.FromArgb(red,green,blue);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MinXTextBox.Text = Convert.ToString(grafico.minX);
                MaxXTextBox.Text = Convert.ToString(grafico.maxX);
                MinYTextBox.Text = Convert.ToString(grafico.minY);
                MaxYTextBox.Text = Convert.ToString(grafico.maxY);
                PassoXTextBox.Text = Convert.ToString(grafico.passo);
                PassoYTextBox.Text = Convert.ToString(grafico.passo);
                FunzioneTextBox.Text = funzione;
                grafico.rePaint = true;
            }
            catch
            {
            }
        }

        private double derivataParziale(string funzione,bool x,Punto p)
        {
            Double delta=0.0000000000001;
            Expression e = new Expression();
            if (x)
            {
                funzione = "((" + funzione.Replace("x", "(x+" + delta.ToString() + ")") + ")-(" + funzione + "))/(" + delta.ToString()+")";
            }
            else
            {
                funzione = "((" + funzione.Replace("y", "(y+" + delta.ToString() + ")") + ")-(" + funzione + "))/(" + delta.ToString()+")";
            }
            funzione = funzione.Replace("x", p.x.ToString());
            funzione = funzione.Replace("y", p.y.ToString());
            return e.risultato(funzione);
        }
        private double derivataParziale(string funzione, bool x, float x0,float y0)
        {
            Punto p=new Punto();
            p.x=x0;
            p.y=y0;
            return derivataParziale(funzione, x, p);
        }

        private Double Hessiano(string f, Punto p, out char tipo)
        {
            Expression e = new Expression();
            double fxx = 0;
            double fxy = 0;
            double fyy = 0;
            string fx=f;
            string fy=f;
            double deltax = 0.0000000000001;
            double deltay = 0.0000000000001;
            fx = ("((" + f.Replace("x", "(x+" + deltax.ToString()+")") + ")-(" + f + "))/(" + deltax.ToString() + ")");
            fy = ("((" + f.Replace("y", "(y+" + deltay.ToString()+")") + ")-(" + f + "))/(" + deltay.ToString() + ")");
            fxx = e.risultato(("((" + fx.Replace("x", (p.x + deltax).ToString()) + ")-(" + fx.Replace("x", p.x.ToString()) + "))/(" + deltax.ToString() + ")").Replace("y", p.y.ToString()));
            fxy = e.risultato(("((" + fx.Replace("y", (p.y + deltay).ToString()) + ")-(" + fx.Replace("y", p.y.ToString()) + "))/(" + deltay.ToString() + ")").Replace("x", p.x.ToString()));
            fyy = e.risultato(("((" + fy.Replace("y", (p.y + deltay).ToString()) + ")-(" + fy.Replace("y", p.y.ToString()) + "))/(" + deltay.ToString() + ")").Replace("x", p.x.ToString()));
            double h = fxx * fyy - fxy * fxy;
            if ((h > 0) && (fxx > 0)) tipo = '+';
            else if ((h > 0) && (fxy > 0)) tipo = '-';
            else if (h < 0) tipo = 's';
            else tipo = '?';
            return h;
        }
        private Boolean tendeAN(Double numero,Double N,Double tolleranza)
        {
            if ((numero>N-tolleranza)&&(numero<N+tolleranza))return true;
            else return false;
        }
        private void DisegnaButton_Click(object sender, EventArgs e)
        {
            
            Single xv, yv;
            double z;
            Expression ex = new Expression();
            Punto zp;
            List<Punto> ListaPunti = new List<Punto>();
            zValue=new List<Double>(); 
            string zs;
            Double minZ=0.0;
            Double maxZ = 0.0;
            MinimiComboBox.Items.Clear();
            MassimiComboBox.Items.Clear();
            SellaComboBox.Items.Clear();
            if ((PassoX>0)&&(PassoY>0))
                for (xv = grafico.minX; xv < grafico.maxX; xv+=PassoX)
                {
                    for (yv = grafico.minY; yv < grafico.maxY; yv+=PassoY)
                    {
                        zs = FunzioneTextBox.Text;
                        try
                        {
                            zs=zs.Replace("x", xv.ToString());
                            zs=zs.Replace("y", yv.ToString());
                            z=ex.risultato(zs);
                            zValue.Add(z);
                            zp = new Punto();
                            zp.x = xv;
                            zp.y = yv;
                            zp.setWidth((int)(PassoX * grafico.settore(true))+1);
                            zp.setHeight((int)(PassoY * grafico.settore(false))+1);
                            zp.colore = HeighToColor(z, minZ, maxZ);
                            ListaPunti.Add(zp);
                            if ((xv == grafico.minX) && (yv == grafico.minY))
                            {
                                minZ = maxZ =z;
                            }
                            else
                            {
                                if (z < minZ) minZ = z;
                                if (z > maxZ) maxZ = z;
                            }
                        }
                        catch
                        {
                            z = 0;
                        }
                    }
                    zp = new Punto();
                }
            
            grafico.punti = ListaPunti.ToArray();
            Double[] zArray=zValue.ToArray();
            char t;
            int PuntiColonna=(int)((grafico.maxY - grafico.minY)/PassoY);
            for (int i = 0; i < grafico.punti.Length; i++)
            {
                if (tendeAN(zArray[i],minZ,PassoY))
                {
                    i = i;
                }
                if (tendeAN(derivataParziale(FunzioneTextBox.Text, true, grafico.punti[i]),0,PassoX) && tendeAN(derivataParziale(FunzioneTextBox.Text, false, grafico.punti[i]),0,PassoY))
                {
                    grafico.punti[i].colore = Color.Purple;
                    if (Hessiano(FunzioneTextBox.Text, grafico.punti[i],out t) < 0)
                    {
                        SellaComboBox.Items.Add(grafico.punti[i].x.ToString() + "," + grafico.punti[i].y.ToString());
                    }
                    else if (t == '+') MassimiComboBox.Items.Add(grafico.punti[i].x.ToString() + "," + grafico.punti[i].y.ToString());
                    else if (t == '-') MinimiComboBox.Items.Add(grafico.punti[i].x.ToString() + "," + grafico.punti[i].y.ToString());
                }
                else
                {
                    
                }
            }

            MinZTextBox.Text = minZ.ToString();
            MaxZTextBox.Text = maxZ.ToString();
            grafico.Repaint();
        }
        private void MinXTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grafico.minX = Convert.ToInt16(MinXTextBox.Text.Replace(".", ","));
                grafico.Repaint();
            }
            catch
            { }
        }

        private void MaxXTextBox_TextChanged(object sender, EventArgs e)
        {
          try
          {
              grafico.maxX = Convert.ToInt16(MaxXTextBox.Text.Replace(".", ","));
            grafico.Repaint();
          }
          catch
          { }
        }

        private void MinYTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
              grafico.minY = Convert.ToInt16(MinYTextBox.Text.Replace(".",","));
              grafico.Repaint();
            }
            catch
            { }
        }

        private void MaxYTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grafico.maxY = Convert.ToInt16(MaxYTextBox.Text.Replace(".", ","));
              grafico.Repaint();
            }
            catch
            { }
        }

        private void FunzioneTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void PassoXTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PassoX = Convert.ToSingle(PassoXTextBox.Text.Replace(".", ","));
            }
            catch
            {
                PassoX = 0;
            }
        }

        private void PassoYTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PassoY = Convert.ToSingle(PassoYTextBox.Text.Replace(".", ","));
            }
            catch
            {
                PassoY = 0;
            }
        }

        private void RangeColoriPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = RangeColoriPanel.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            for (int i = 0; i < RangeColoriPanel.Width; i++)
            {
                pen.Color = HeighToColor(i, 0, RangeColoriPanel.Width);
                graphics.DrawLine(pen, i, 0, i, RangeColoriPanel.Height);
            }
        }

        private void grafico_MouseHover(object sender, EventArgs e)
        {
            showCoordLabel = true;      
        }

        private void grafico_MouseEnter(object sender, EventArgs e)
        {
            CoordinateLabel.Visible = true;
        }

        private void grafico_MouseLeave(object sender, EventArgs e)
        {
            CoordinateLabel.Visible = false;
            showCoordLabel = false;
        }

        private void grafico_MouseMove(object sender, MouseEventArgs e)
        {
            String zText = "";
            if (showCoordLabel)
            {
                int x = e.X;
                int y = e.Y;
                int PuntiRiga=(int)((grafico.maxX - grafico.minX)/PassoX);
                String xText= "X:"+Convert.ToString((x - grafico.origine().X) / grafico.settore(true));
                String yText=" Y:"+Convert.ToString(((grafico.Height-y) - grafico.origine().Y) / grafico.settore(false));
               /* if ((zValue != null) && (zValue.Count > 0))
                {
                    try
                    {
                        zText = " Z:" + Convert.ToString(zValue.ToArray()[PuntiRiga * ((int)((grafico.Height - y) / grafico.settore(false)) - 1) + ((int)(x / grafico.settore(true)))]);
                    }
                    catch 
                    {
                        zText="";
                    }
                    
               }*/
                CoordinateLabel.Text = xText + "," + yText+ "," + zText; 
            }
        }
        struct Derivate
        {
            public double x0;
            public double y0;
            public double dx;
            public double dy;
        }

        private void PuntiStazionariButton_Click(object sender, EventArgs e)
        {
            Single xv, yv;
            double zx;
            double zy;
            Punto zp;
            List<Derivate> derivate=new List<Derivate>();
            Derivate derivata;
            try
            {
                PassoX = Convert.ToSingle(PassoXTextBox.Text);
                PassoY = Convert.ToSingle(PassoYTextBox.Text);
            }
            catch 
            {
                PassoX = 0;
                PassoY = 0;
            }
            int r=0;
            int c=0;
            List<Punto> ListaPunti = new List<Punto>();
            zValue = new List<Double>();
            string zs;
            Double zxOld = 0.0;
            Double zyOld = 0.0;
            if ((PassoX > 0) && (PassoY > 0))
                for (xv = grafico.minX; xv < grafico.maxX; xv += PassoX)
                {
                    c++;
                    r = 0;
                    for (yv = grafico.minY; yv < grafico.maxY; yv += PassoY)
                    {
                        r++;
                        zs = FunzioneTextBox.Text;
                        try
                        {
                            zy = derivataParziale(zs, true, xv, yv);
                            if ((zy <= 0 && zyOld >= 0) || zy >= 0 && zyOld <= 0)
                            {
                                zx = derivataParziale(zs, true, xv, yv);
                                derivata = new Derivate();
                                derivata.x0 = xv;
                                derivata.y0 = yv;
                                derivata.dx = zx;
                                derivata.dy = zy;
                                derivate.Add(derivata);
                            }
                            zyOld = zy;
                        }
                        catch
                        {
                            zx = 0;
                            zy = 0;
                        }
                    }
                }
            foreach (Derivate d in derivate)
            {
                if ((d.dx <= 0 && zxOld >= 0) || d.dx >= 0 && zxOld <= 0)
                {
                    zp = new Punto();
                    zp.Colore = Color.Purple;
                    zp.x = (float)d.x0;
                    zp.y = (float)d.y0;
                    zp.setHeight((int)(PassoX * grafico.settore(true)) + 1);
                    zp.setWidth((int)(PassoY * grafico.settore(false)) + 1);
                    ListaPunti.Add(zp);
                }
              zxOld = d.dx;
            }
            ListaPunti.InsertRange(0, grafico.punti);
            grafico.punti = ListaPunti.ToArray();
            grafico.Repaint();
        }







    }
}
