//Balzarotti Stefano
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;

namespace Funzioni
{
/*************************************/
#region Oggetto Punto
    [Serializable]
    public class Punto
    {
        public Single x, y;
        private int width=1;
        private int height=1;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Single X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public Single Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Color colore = Color.Yellow;
        public Color Colore
        {
            get
            {
                return colore;
            }
            set
            {
                colore = value;
            }
        }
        public void setWidth(int value)
        {
            if (value>=1)
            width = value;
        }
        public void setHeight(int value)
        {
            if (value >= 1)
            height = value;
        }
        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height;
        }

    }
    public class ComparaPunti : IComparer<Punto>
    {
        public int Compare(Punto a, Punto b)
        {
            if (a.x > b.x) return -1;
            else if (a.x == b.x) return 0;
            else return 1;
        }
        public int CompareTo(Punto a)
        {
            return 0;
        }
    }
#endregion
/*************************************/
/*************************************/
#region Oggetto Funzione
    [Serializable]
	public class Funzione
	{
	  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	  public string polinomio;
	  public Single minX;
	  public Single maxX;
	  public string Polinomio
	    {
		  get
		    {
			  return polinomio;
			}
		   set
		     {
			   polinomio=value;
			 }
		}
      public Single MinX
      {
          get
          {
              return minX;
          }
          set
          {
              minX = value;
          }
      }
      public Single MaxX
      {
          get
          {
              return maxX;
          }
          set
          {
              maxX = value;
          }
      }
    }
#endregion
/*************************************/
/*************************************/
#region Oggetto Grafico
    public class Grafico : Panel
    {
    /*************************************/
    #region Proprietà Grafico
        public Single minX = -100;
        public Single MinX
        {
            get
            {
                return minX;
            }
            set
            {
                minX = value;
            }
        }
        public Single maxX = 100;
        public Single MaxX
        {
            get
            {
                return maxX;
            }
            set
            {
                maxX = value;
            }
        }
        public Single minY = -100;
        public Single MinY
        {
            get
            {
                return minY;
            }
            set
            {
                minY = value;
            }
        }
        public Single maxY = 100;
        public Single MaxY
        {
            get
            {
                return maxY;
            }
            set
            {
                maxY = value;
            }
        }
        public Single passo = 30;
        public Single Passo
        {
            get
            {
                return passo;
            }
            set
            {
                passo = value;
            }
        }
        public Funzione[] funzioni = new Funzione[0];
        public Funzione[] Funzioni
        {
            get
            {
                return funzioni;
            }

            set
            {
                funzioni = value;
            }
        }
        public Punto[] punti=new Punto[0];
        public Punto[] Punti
        {
            get
            {
                return punti;
            }
            set
            {
                punti = value;
            }
        }
        public int precisione = 5;
        public int Precisione
        {
            get
            {
                return precisione;
            }
            set
            {
                precisione = value;
            }
        }
        public Color coloreEtichetta = Color.White;
        public Color ColoreEtichetta
        {
            get
            {
                return coloreEtichetta;
            }
            set
            {
                coloreEtichetta = value;
            }
        }
#endregion
    /*************************************/
        public Boolean PaintInEsecuzione=false;
        public Boolean rePaint = true;
        public Grafico()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
            this.Paint += new PaintEventHandler(onPaint);
            this.UpdateStyles();
        }
        public override void Refresh()
        {
            //if (rePaint)
                base.Refresh();

        }
        public void Repaint()
        {
          rePaint = true;         
          Refresh();
          rePaint = false;
        }
        public Single settore(Single size, Single min, Single max)
        {
            return size / (max - min);
        }
        public Single settore(bool x)
        {
            if (x) return ClientSize.Width / (maxX - minX);
            else return ClientSize.Height / (maxY - minY);
        }
        public Point origine()
        {
            Point p = new Point();
            p.X = (int)(-minX * settore(ClientSize.Width, minX, maxX));
            p.Y = (int)(maxY * settore(ClientSize.Height, minY, maxY));
            return p;
        }
        private void disegnaPunti(Graphics graphics, Pen pen)
        {
            if (punti!=null)
            foreach (Punto p in punti)
            {
                
                Brush solid = new SolidBrush(p.colore);
                graphics.FillRectangle(solid, origine().X + p.x * settore(true), (origine().Y - p.y * settore(false)), p.getWidth(), p.getHeight());
            }
        }
        private void disegnaAsseX(Graphics graphics, Pen pen)
        {
            int y;
            y = (int)(Math.Abs(minY) * settore(false));
            graphics.DrawLine(pen, 0, (ClientSize.Height - y), ClientSize.Width, (ClientSize.Height - y));
            graphics.DrawLine(pen, ClientSize.Width, ClientSize.Height - y, ClientSize.Width - 5, ClientSize.Height - y + 5);
            graphics.DrawLine(pen, ClientSize.Width, ClientSize.Height - y, ClientSize.Width - 5, ClientSize.Height - y - 5);
            graphics.DrawString("X", new Font("ArialBlack",8), new SolidBrush(coloreEtichetta), ClientSize.Width - 15, ClientSize.Height - y + 5);
        }
        private void disegnaAsseY(Graphics graphics, Pen pen)
        {
            int x;
            x = (int)(Math.Abs(minX) * settore(true));
            graphics.DrawLine(pen, x, 0, x, ClientSize.Height);
            graphics.DrawLine(pen, x, 0, x + 5, 5);
            graphics.DrawLine(pen, x, 0, x - 5, 5);
            graphics.DrawString("Y", new Font("ArialBlack", 8), new SolidBrush(coloreEtichetta), x + 10, 5);
            graphics.DrawString("Z", new Font("ArialBlack", 8), new SolidBrush(coloreEtichetta), origine().X, origine().Y);
        }
        private void onPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //if (!PaintInEsecuzione&&rePaint)
            {
                PaintInEsecuzione = true;
                Graphics graphics = CreateGraphics();
                Pen pen = new Pen(Color.Blue , 1);
                pen.Width = 2;
                //disegnaFunzione(graphics, pen);
                disegnaPunti(graphics, pen);
                pen.Color = Color.Red;
                if (maxX - minX > maxX) disegnaAsseY(graphics, pen);
                if (maxY - minY > maxY) disegnaAsseX(graphics, pen);
                //System.Threading.Thread.Sleep(1000);
                PaintInEsecuzione = false;                
            }
        }
        public Punto[] ordinaPunti()
        {
            List<Punto> listaPunti = new List<Punto>(punti);
            listaPunti.Sort(new ComparaPunti());
            return listaPunti.ToArray();
        }
        public List<Punto> ordinaPunti(List<Punto> punti)
        {
            List<Punto> listaPunti = new List<Punto>(punti);
            listaPunti.Sort(new ComparaPunti());
            return punti;
        }
        private void disegnaFunzione(Graphics graphics, Pen pen)
        {
            Single passo = (maxX - minX) / (precisione*ClientSize.Width);
            double fx, xv;
            long x,y;
            Expression espressione = new Expression();
            if (funzioni != null)
            {
                for (int i = 0; i < funzioni.Length; i++)
                {
                    string polinomio = funzioni[i].polinomio;
                    for (xv = funzioni[i].minX; xv <= funzioni[i].maxX; xv += passo)
                    {
                        try
                        {
                            fx = espressione.risultato(polinomio.Replace("x", Convert.ToString(xv)));
                        }
                        catch
                        {
                            fx = 0;
                            xv = funzioni[i].maxX;
                        }
                        try
                        {
                            if ((fx > minY) && (fx < maxY))
                            {
                                y = Convert.ToInt64(origine().Y - fx * settore(false));
                                x = Convert.ToInt64(origine().X + xv * settore(true));
                                graphics.DrawEllipse(pen, x, y, 1, 1);
                            }
                        }
                        catch
                        {
                           //
                        }
                    }
                }
            }
        }
    }
#endregion
/*************************************/
}

