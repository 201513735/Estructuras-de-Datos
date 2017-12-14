#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <time.h>
#include <stdlib.h>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    srand(time(NULL));
    this->avionesLlegada=new ColaAviones();
    this->avionesMantenimiento=new ColaAviones();
    this->pasajeros=new ColaPasajeros();
    this->escritorios=new ListaEscritorios();
    this->maletas=new ListaMaletas();
    this->mantenimiento=new ListaMantenimiento();
    this->avionArribo=NULL;

    ui->botonSiguiente->hide();
    ui->botonImagen->hide();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_botonIniciar_clicked()
{
    this->cantidadAviones=ui->textAviones->text().toInt();
    this->cantidadEscritorios=ui->textEscritorios->text().toInt();
    this->cantidadEstaciones=ui->textMantenimiento->text().toInt();
    this->turnos=ui->textTurnos->text().toInt();
    this->iniciarSimulacion();
}

void MainWindow::iniciarSimulacion()
{
    this->turnoActual=0;
    ui->botonImagen->show();
    ui->botonSiguiente->show();
    ui->botonIniciar->hide();
    this->desabordaje=NULL;
    //INSERTANDO LAS ESTACIONES DE MANTENIMIENTO
    for(int i=0;i<this->cantidadEstaciones;i++)
    {
        this->mantenimiento->Insertar(i+1);
    }

    //INSERTANDO LOS ESCRITORIOS DE RESGISTRO
    char * id;
    char  letra;
    int ascii;
    for(int i=0;i<this->cantidadEscritorios;i++)
    {
        ascii=rand()%26+65;
        letra=ascii;
        id=new char[1];
        id[0]=letra;
        this->escritorios->Insertar(id);
    }

    this->cambiarTurno();
    this->consola();
    this->generarGrafo();
}

void MainWindow::cambiarTurno()
{
    this->turnoActual++;
    NodoPasajero * pa;

    //COMPROBACION DEL DESABORDAJE
    if(this->desabordaje!=NULL){
        this->desabordaje->desabordaje--;
        if(this->desabordaje->desabordaje<=0)
        {

            for(int i=0; i<this->desabordaje->pasajeros;i++)//INGRESO DE LOS PASAJEROS A LA COLA DE ESPERA
            {
                pa=new NodoPasajero();
                this->pasajeros->Insertar(pa);
                for(int j=0;j<pa->maletas;j++)//INGRESO DE LAS MALETAS A LA LISTA CIRCULAR
                {
                    this->maletas->Insertar();
                }
            }
            this->avionesMantenimiento->Insertar(this->desabordaje);//PASO DEL AVION A MANTENIMIENTO

            this->desabordaje=this->avionesLlegada->Sacar();
        }
    }else{
        NodoAvion * av=this->avionesLlegada->Sacar();
        if(av!=NULL)
        {
            this->desabordaje=av;
        }
    }

    pa=this->pasajeros->cabeza;


    //LLEGADA DEL NUEVO AVION
    if(this->cantidadAviones>0)
    {
        this->avionArribo=new NodoAvion();
        this->avionesLlegada->Insertar(this->avionArribo);
        this->cantidadAviones--;
    }else{
        this->avionArribo=NULL;
    }

    //INGRESANDO PASAJEROS A LAS COLAS DE LOS ESCRITORIOS
    NodoEscritorio * es=this->escritorios->cabeza;
    while(es!=NULL){
        while(es->cantidad<10){
            pa=this->pasajeros->Sacar();
            if(pa!=NULL){
                es->cola->Insertar(pa);
                es->cantidad++;
            }else{
                break;
            }
        }
        es=es->siguiente;
    }

    //REVISANDO ESCRITORIOS
    es=this->escritorios->cabeza;
    while(es!=NULL){
        if(es->cliente!=NULL){
            es->cliente->registro--;
            if(es->cliente->registro<=0){
                for(int i=0;i<es->cliente->maletas;i++){
                    //SACANDO LAS MALETAS DE LA LISTA
                    this->maletas->Eliminar();
                }
                es->pila=new Pila();
                es->cliente=es->cola->Sacar();
                if(es->cliente!=NULL){
                    es->cantidad--;
                    for(int i=0;i<es->cliente->documentos;i++){
                        es->pila->Insertar(i+1);
                    }
                }
            }
        }else{
            es->cliente=es->cola->Sacar();
            if(es->cliente!=NULL){
                es->cantidad--;
                for(int i=0;i<es->cliente->documentos;i++){
                    es->pila->Insertar(i+1);
                }
            }
        }
        es=es->siguiente;
    }

    //REVISANDO ESTACIONES DE MANTENIMIENTO
    NodoMantenimiento * ma=this->mantenimiento->cabeza;
    while(ma!=NULL){
        if(ma->avion!=NULL){
            ma->avion->mantenimiento--;
            if(ma->avion->mantenimiento<=0){
                ma->avion=this->avionesMantenimiento->Sacar();
            }
        }else{
            ma->avion=this->avionesMantenimiento->Sacar();
        }
        ma=ma->siguiente;
    }


}

void MainWindow::on_botonSiguiente_clicked()
{
    if(this->turnoActual<this->turnos){
        this->cambiarTurno();
        this->generarGrafo();
        this->consola();
    }else{
       ui->textConsola->setHtml("terminado");
       ui->botonImagen->hide();
        ui->botonSiguiente->hide();
        ui->botonIniciar->show();
    }
}

void MainWindow::generarGrafo(){
    this->contenido=(char*)malloc(100000);
    char * c=(char*)malloc(sizeof(char*));

    strcpy(contenido,"digraph Grafo{ \n subgraph Llegada{\n label=\"Cola de Llegada\";\n");
    NodoAvion * av=this->avionesLlegada->cabeza;
    if(av!=NULL){
        int i=1;
        while(av!=NULL){
            strcat(contenido,"llegada");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Avion ");
            itoa(av->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"\"];\n");
            i++;
            av=av->siguiente;
        }

        av=this->avionesLlegada->cabeza;
        i=1;
        while(av->siguiente!=NULL){
            strcat(contenido,"llegada");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"->llegada");
            itoa(i+1,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n llegada");
            itoa(i+1,c,10);
            strcat(contenido,c);
            strcat(contenido,"->llegada");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            av=av->siguiente;
            i++;
        }
    }

    strcat(contenido,"}\n subgraph Desabordaje{\n label=\"Avion en Desabordaje\";\n node[shape=box];{\n desabordaje[label=\"");
    if(this->desabordaje==NULL){
        strcat(contenido,"Ninguno\"];\n");
    }else{
        strcat(contenido,"Avion: ");
        itoa(this->desabordaje->id,c,10);
        strcat(contenido,c);
        strcat(contenido,"\n Turnos: ");
        itoa(this->desabordaje->desabordaje,c,10);
        strcat(contenido,c);
        strcat(contenido,"\n Pasajeros: ");
        itoa(this->desabordaje->pasajeros,c,10);
        strcat(contenido,c);
        strcat(contenido,"\"];\n");
    }

    strcat(contenido,"}\n }\n subgraph Equipaje{\n label=\"Equipaje\";\n");
    NodoMaleta * ma=this->maletas->cabeza;
    if(ma!=NULL){
//        strcat(contenido,"node[shape=box];{\n");
        strcat(contenido,"maleta");
        itoa(ma->id,c,10);
        strcat(contenido,c);
        strcat(contenido,"[label=\"Maleta ");
        strcat(contenido,c);
        strcat(contenido,"\"];\n");
        ma=ma->siguiente;
        while(ma!=this->maletas->cabeza){
            strcat(contenido,"maleta");
            itoa(ma->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Maleta ");
            strcat(contenido,c);
            strcat(contenido,"\"];\n");
            ma=ma->siguiente;
        }
//        strcat(contenido,"}\n");

        ma=this->maletas->cabeza;
        strcat(contenido,"maleta");
        itoa(ma->id,c,10);
        strcat(contenido,c);
        strcat(contenido,"->maleta");
        itoa(ma->siguiente->id,c,10);
        strcat(contenido,c);
        strcat(contenido,";\n maleta");
        itoa(ma->id,c,10);
        strcat(contenido,c);
        strcat(contenido,"->maleta");
        itoa(ma->anterior->id,c,10);
        strcat(contenido,c);
        strcat(contenido,";\n");
        ma=ma->siguiente;
        while(ma!=this->maletas->cabeza){
            strcat(contenido,"maleta");
            itoa(ma->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"->maleta");
            itoa(ma->siguiente->id,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n maleta");
            itoa(ma->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"->maleta");
            itoa(ma->anterior->id,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            ma=ma->siguiente;
        }

    }

    strcat(contenido,"}\n subgraph Mantenimiento{\n label=\"Mantenimiento\";\n");
    strcat(contenido,"rankdir=UD;\n node[shape=box, color=blue];\n {rank=same;\n ");
    NodoMantenimiento * man=this->mantenimiento->cabeza;
    if(man!=NULL){
        int i=1;
        while(man!=NULL){
            strcat(contenido,"estacion");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Estacion ");
            strcat(contenido,c);
            strcat(contenido,"\n Avion: ");
            if(man->avion==NULL){
                strcat(contenido,"ninguno\n Estado: Libre\n Turnos: 0 \"]; \n");
            }else{
                itoa(man->avion->id,c,10);
                strcat(contenido,c);
                strcat(contenido,"\n Estado: Ocupado\n Turnos: ");
                itoa(man->avion->mantenimiento,c,10);
                strcat(contenido,c);
                strcat(contenido,"\"]; \n");
            }
            i++;
            man=man->siguiente;
        }
    }
    strcat(contenido,"}\n");
    man=this->mantenimiento->cabeza;
    if(man!=NULL){
        int i=1;
        while(man->siguiente!=NULL){
            strcat(contenido,"estacion");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"->estacion");
            itoa(i+1,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            i++;
            man=man->siguiente;
        }
    }
    av=this->avionesMantenimiento->cabeza;
    if(av!=NULL){
        int i=1;
        while(av!=NULL){
            strcat(contenido,"avion");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Avion ");
            itoa(av->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"\"];\n");
            i++;
            av=av->siguiente;
        }

        av=this->avionesMantenimiento->cabeza;
        i=1;
        while(av->siguiente!=NULL){
            strcat(contenido,"avion");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,"->avion");
            itoa(i+1,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n avion");
            itoa(i+1,c,10);
            strcat(contenido,c);
            strcat(contenido,"->avion");
            itoa(i,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            av=av->siguiente;
            i++;
        }
    }


    strcat(contenido,"}\n subgraph Escritorios{\n label=\"Escritorios de Registro\";\n rankdir=UD;\n node[shape=box, color=blue];\n");
    NodoEscritorio * esc=this->escritorios->cabeza;
    NodoPasajero * pa;
    int j;
    NodoPila * pi;
    while(esc!=NULL){
        strcat(contenido,"{rank=same;\n escritorio");
        strcat(contenido,esc->id);
        strcat(contenido,"[label=\"Escritorio: ");
        strcat(contenido,esc->id);
        if(esc->cliente==NULL){
            strcat(contenido,"\n Cliente: ninguno\n Estado: libre\n Documentos: 0\n Turnos: 0\"];\n");
        }else{
            strcat(contenido,"\n Cliente: ");
            itoa(esc->cliente->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"\n Estado: ocupado\n Documentos: ");
            itoa(esc->cliente->documentos,c,10);
            strcat(contenido,c);
            strcat(contenido,"\n Turnos: ");
            itoa(esc->cliente->registro,c,10);
            strcat(contenido,c);
            strcat(contenido,"\"];\n");
        }
        j=1;
        pa=esc->cola->cabeza;
        while(pa!=NULL){
            strcat(contenido,"escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"cola");
            itoa(j,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Pasajero ");
            itoa(pa->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"\"];\n");

            pa=pa->siguiente;
            j++;
        }

        pi=esc->pila->cabeza;
        while(pi!=NULL){
            strcat(contenido,"escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"pila");
            itoa(pi->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"[label=\"Documento ");
            itoa(pi->id,c,10);
            strcat(contenido,c);
            strcat(contenido,"\"];\n");

            pi=pi->siguiente;
        }

        strcat(contenido,"}\n");
        esc=esc->siguiente;
    }
    //CONEXIONES DE LOS ESCRITORIOS
    esc=this->escritorios->cabeza;
    while(esc!=NULL){
        j=1;
        if(esc->siguiente!=NULL){
            strcat(contenido,"escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"->escritorio");
            strcat(contenido,esc->siguiente->id);
            strcat(contenido,";\n escritorio");
            strcat(contenido,esc->siguiente->id);
            strcat(contenido,"->escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,";\n");
        }
        pa=esc->cola->cabeza;
        if(pa!=NULL){
            strcat(contenido,"escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"->escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"cola");
            itoa(j,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            while(pa->siguiente!=NULL){
                strcat(contenido,"escritorio");
                strcat(contenido,esc->id);
                strcat(contenido,"cola");
                itoa(j,c,10);
                strcat(contenido,c);
                strcat(contenido,"->escritorio");
                strcat(contenido,esc->id);
                strcat(contenido,"cola");
                itoa(j+1,c,10);
                strcat(contenido,c);
                strcat(contenido,";\n");

                j++;
                pa=pa->siguiente;
            }
        }

        pi=esc->pila->cabeza;
        if(pi!=NULL){
            strcat(contenido,"escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"->escritorio");
            strcat(contenido,esc->id);
            strcat(contenido,"pila");
            itoa(pi->id,c,10);
            strcat(contenido,c);
            strcat(contenido,";\n");
            while(pi->siguiente!=NULL){
                strcat(contenido,"escritorio");
                strcat(contenido,esc->id);
                strcat(contenido,"pila");
                itoa(pi->id,c,10);
                strcat(contenido,c);
                strcat(contenido,"->escritorio");
                strcat(contenido,esc->id);
                strcat(contenido,"pila");
                itoa(pi->siguiente->id,c,10);
                strcat(contenido,c);
                strcat(contenido,";\n");

                pi=pi->siguiente;
            }
        }
        esc=esc->siguiente;
    }

    strcat(contenido,"}\n");

    strcat(contenido,"}");

    FILE * archivo=fopen("C:\\Users\\crist\\Desktop\\grafo.dot","w");
    fputs(contenido,archivo);
    fclose(archivo);
    system("dot C:\\Users\\crist\\Desktop\\grafo.dot -Tpng -o C:\\Users\\crist\\Desktop\\grafo.png");
    QString path("C:\\Users\\crist\\Desktop\\grafo.png");
    QPixmap pix(path);
    QIcon icon(pix);
    ui->botonImagen->setIcon(icon);
}

void MainWindow::consola(){
    char * consola=(char*)malloc(10000);

    char * c=(char*)malloc(sizeof(char*));
    itoa(this->turnoActual,c,10);

    strcpy(consola,"####Turno ");
    strcat(consola,c);
    strcat(consola,"####<br/>");
    if(this->avionArribo!=NULL){
        itoa(this->avionArribo->id,c,10);
        strcat(consola,"Arribo el avion: ");
        strcat(consola,c);
    }else{
        strcat(consola,"Arribo el avion: Ninguno");
    }

    if(this->desabordaje!=NULL){
        itoa(this->desabordaje->id,c,10);
        strcat(consola,"<br/> Avion desabordando: ");
        strcat(consola,c);
    }else{
        strcat(consola,"<br/> Desabordando: Ninguno");
    }

    strcat(consola,"<br/> ---Escritorios---<br/> ");
    NodoEscritorio * es=this->escritorios->cabeza;
    while(es!=NULL){
        strcat(consola,"Escritorio ");
        strcat(consola,es->id);
        strcat(consola,": <br/>");
        if(es->cliente!=NULL){
            strcat(consola,"   Pasajero: ");
            itoa(es->cliente->id,c,10);
            strcat(consola,c);
            strcat(consola,"<br/>   Turnos: ");
            itoa(es->cliente->registro,c,10);
            strcat(consola,c);
            strcat(consola,"<br/>   Documentos: ");
            itoa(es->cliente->documentos,c,10);
            strcat(consola,c);
            strcat(consola," <br/>");
        }else{
            strcat(consola,"   Pasajero: ninguno <br/>   Turnos: 0 <br/>   Documentos: 0 <br/>");
        }
        es=es->siguiente;
    }

    strcat(consola,"------------<br/>");
    strcat(consola,"---Mantenimiento---<br/>");
    NodoMantenimiento * ma=this->mantenimiento->cabeza;
    while(ma!=NULL){
        strcat(consola,"Estacion ");
        itoa(ma->id,c,10);
        strcat(consola,c);
        strcat(consola,": <br/>");
        if(ma->avion!=NULL){
            strcat(consola,"   Avion: ");
            itoa(ma->avion->id,c,10);
            strcat(consola,c);
            strcat(consola,"<br/>   Turnos: ");
            itoa(ma->avion->mantenimiento,c,10);
            strcat(consola,c);
            strcat(consola," <br/>");
        }else{
            strcat(consola,"   Avion: ninguno <br/>   Turnos: 0 <br/>");
        }
        ma=ma->siguiente;
    }

    strcat(consola,"------------<br/>");
    strcat(consola,"Turnos restantes: ");
    itoa(this->turnos-this->turnoActual,c,10);
    strcat(consola,c);
    strcat(consola,"<br/> ***Fin de Turno***");

    ui->textConsola->setHtml(consola);

}
