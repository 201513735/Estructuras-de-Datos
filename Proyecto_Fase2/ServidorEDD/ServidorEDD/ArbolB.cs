using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class ArbolB
    {
        HojaB raiz;
        int k;
        int tipo;
        int cantidadAtaques;

        public ArbolB(int k, int tipo)
        {
            Raiz = null;
            this.k = k;
            this.tipo = tipo;
            CantidadAtaques = 0;
        }

        public int CantidadAtaques
        {
            get { return cantidadAtaques; }
            set { cantidadAtaques = value; }
        }

        public void Insertar(int x, int y, String unidadAtacante, int resultado, String unidadDañada, String emisor, String receptor, String fecha, String tiempoRestante, int numero)
        {
            String id="";
            switch (tipo)
            {
                case 1:
                    //COORDENADA X
                    id=x.ToString()+ numero.ToString();
                    break;
                case 2:
                    //COORDENADA Y
                    id=y.ToString()+ numero.ToString();
                    break;
                case 3:
                    //UNIDAD ATACANTE
                    id=unidadAtacante+numero.ToString();
                    break;
                case 4:
                    //RESULTADO
                    id = resultado.ToString()+ numero.ToString();
                    break;
                case 5:
                    //UNIDAD DAÑADA
                    id = unidadDañada + numero.ToString();
                    break;
                case 6:
                    //EMISOR
                    id = emisor + numero.ToString();
                    break;
                case 7:
                    //RECEPTOR
                    id = receptor + numero.ToString();
                    break;
                case 8:
                    //FECHA
                    id = fecha + numero.ToString();
                    break;
                case 9:
                    //TIEMPO
                    id = tiempoRestante + numero.ToString();
                    break;
                case 10:
                    //NUMERO DE ATAQUE
                    id = numero.ToString();
                    break;
            }//fin del swtich

            CantidadAtaques++;

            NodoB nuevo = new NodoB(id, x, y, unidadAtacante, resultado, unidadDañada, emisor, receptor, fecha, tiempoRestante, CantidadAtaques);

            if (Raiz == null)
            {
                Raiz = new HojaB(K);
                Raiz.Insertar(nuevo);
                
            }else //la Raiz no es nula
            {
                HojaB aux = encontrarHoja(Raiz, id);
                aux.Insertar(nuevo);
                romperHoja(aux);
            }
        }

        private void romperHoja(HojaB aux)
        {
            if (aux.Nodos[k - 1] != null)
            {
                int m = k / 2;
                HojaB izq = new HojaB(k);
                HojaB der = new HojaB(k);
                int j = 0;
                for(int i = 0; i < m; i++)
                {
                    izq.Nodos[i] = aux.Nodos[j];
                    if (aux.Nodos[i].Derecha != null)
                    {
                        izq.Nodos[i].Derecha.Padre = izq;
                        izq.Nodos[i].Izquierda.Padre = izq;
                    }
                    j++;
                }
                NodoB nuevo = aux.Nodos[j];
                j++;
                for(int i = 0; i < m; i++)
                {
                    der.Nodos[i] = aux.Nodos[j];
                    if (aux.Nodos[i].Derecha != null)
                    {
                        der.Nodos[i].Derecha.Padre = der;
                        der.Nodos[i].Izquierda.Padre = der;
                    }
                    j++;
                }

                nuevo.Izquierda = izq;
                nuevo.Derecha = der;
                if (aux == Raiz)
                {
                    Raiz = new HojaB(k);
                    Raiz.Nodos[0] = nuevo;
                    izq.Padre = Raiz;
                    der.Padre = Raiz;
                }else
                {
                    izq.Padre = aux.Padre;
                    der.Padre = aux.Padre;

                    j = 0;
                    int i = 0;
                    NodoB[] n = new NodoB[k];
                    while (i < k)
                    {
                        if (aux.Padre.Nodos[j] != null)
                        {
                            if (j < i)
                            {
                                n[i] = aux.Padre.Nodos[j];
                                j++;
                            }else if (String.Compare(nuevo.Id,aux.Padre.Nodos[j].Id)<0)
                            {
                                n[i] = nuevo;
                                aux.Padre.Nodos[j].Izquierda = nuevo.Derecha;
                                if (i > 0)
                                {
                                    n[i - 1].Derecha = nuevo.Izquierda;
                                }
                            }
                            else
                            {
                                n[i] = aux.Padre.Nodos[j];
                                j++;
                            }
                        }else if(i==j)
                        {
                            n[i] = nuevo;
                            n[i - 1].Derecha = nuevo.Izquierda;
                        }
                        else
                        {
                            n[i] = null;
                        }
                        i++;
                    }
                    aux.Padre.Nodos = n;

                    romperHoja(aux.Padre);
                }
            }
        }

        private HojaB encontrarHoja(HojaB h, String id)
        {

            if (h.Nodos[0] != null)
            {
                if (h.Nodos[0].Izquierda != null)
                {
                    int i = 0;
                    for(i = 0; i < k; i++)
                    {
                        if (h.Nodos[i]==null || String.Compare(id, h.Nodos[i].Id) < 0)
                        {
                            break;
                        }
                    }
                    if (i == k )
                    {
                        return encontrarHoja(h.Nodos[i-1].Derecha, id);
                    }else if (h.Nodos[i] == null)
                    {
                        return encontrarHoja(h.Nodos[i - 1].Derecha, id);
                    }
                    else
                    {
                        return encontrarHoja(h.Nodos[i].Izquierda, id);
                    }
                }
                else
                {
                    return h;
                }
            }else
            {
                return h;
            }
        }

        public HojaB Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public int K
        {
            get { return k; }
        }
    }
}