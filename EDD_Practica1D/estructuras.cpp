#include "estructuras.h"
#include <stdlib.h>
#include <string.h>

NodoAvion::NodoAvion()
{
    this->id=1+rand()%1000;
    this->tipo=1+rand()%3;
    switch(this->tipo)
    {
        case 1: //AVION PEQUEÑO
            this->pasajeros=rand()%6+5;
            this->desabordaje=1;
            this->mantenimiento=rand()%3+1;
            break;
        case 2: //AVION MEDIANO
            this->pasajeros=rand()%11+15;
            this->desabordaje=2;
            this->mantenimiento=rand()%3+2;
            break;
        case 3: //AVION GRANDE
            this->pasajeros=rand()%11+30;
            this->desabordaje=3;
            this->mantenimiento=rand()%4+3;
            break;
        default:
            break;
    }
    this->siguiente=NULL;
    this->anterior=NULL;
}

NodoPasajero::NodoPasajero()
{
   this->id=1+rand()%2000;
   this->maletas=rand()%4+1;
   this->documentos=rand()%10+1;
   this->registro=rand()%3+1;
   this->siguiente=NULL;
}

ColaAviones::ColaAviones()
{
    this->cabeza=NULL;
}

void ColaAviones::Insertar(NodoAvion * nuevo)
{
    if(this->cabeza==NULL)
    {
        this->cabeza=nuevo;
    }else
    {
        NodoAvion * aux=this->cabeza;
        while(aux->siguiente!=NULL){
            aux=aux->siguiente;
        }
        nuevo->anterior=aux;
        aux->siguiente=nuevo;
    }
}

NodoAvion * ColaAviones::Sacar(){
    if(this->cabeza!=NULL){
        NodoAvion * aux=this->cabeza;
        this->cabeza=this->cabeza->siguiente;
        if(this->cabeza!=NULL){
            this->cabeza->anterior=NULL;
        }
        aux->siguiente=NULL;
        aux->anterior=NULL;
        return aux;
    }else{
        return NULL;
    }
}

ColaPasajeros::ColaPasajeros()
{
    this->cabeza=NULL;
}

void ColaPasajeros::Insertar(NodoPasajero *nuevo){
    if(this->cabeza==NULL)
    {
        this->cabeza=nuevo;
    }else
    {
        NodoPasajero * aux=this->cabeza;
        while(aux->siguiente!=NULL){
            aux=aux->siguiente;
        }
        aux->siguiente=nuevo;
    }
}

NodoPasajero * ColaPasajeros::Sacar(){
    if(this->cabeza!=NULL){
        NodoPasajero * aux=this->cabeza;
        this->cabeza=this->cabeza->siguiente;
        aux->siguiente=NULL;
        return aux;
    }else{
        return NULL;
    }
}

NodoPila::NodoPila(int id){
    this->id=id;
    this->siguiente=NULL;
}

Pila::Pila(){
    this->cabeza=NULL;
}

void Pila::Insertar(int id){
    NodoPila * nuevo=new NodoPila(id);
    if(this->cabeza==NULL){
        this->cabeza=nuevo;
    }else{
        NodoPila * aux=this->cabeza;
        nuevo->siguiente=aux;
        this->cabeza=nuevo;
    }
}

NodoPila * Pila::Sacar(){
    NodoPila * aux=this->cabeza;
    if(aux!=NULL){
        this->cabeza=aux->siguiente;
        return aux;
    }else{
        return NULL;
    }
}

NodoEscritorio::NodoEscritorio(char * id){
    this->id=(char*)malloc(sizeof(char)*strlen(id));
    strcpy(this->id,id);
    this->cliente=NULL;
    this->cantidad=0;
    this->documentos=0;
    this->turnos=0;
    this->siguiente=NULL;
    this->anterior=NULL;
    this->pila=new Pila();
    this->cola=new ColaPasajeros();
}

NodoMantenimiento::NodoMantenimiento(int id){
    this->id=id;
    this->estado=0;
    this->turnos=0;
    this->avion=NULL;
    this->siguiente=NULL;
}

NodoMaleta::NodoMaleta(int id){
    this->id=id;
    this->siguiente=NULL;
    this->anterior=NULL;
}

ListaEscritorios::ListaEscritorios(){
    this->cabeza=NULL;
}

void ListaEscritorios::Insertar(char * id){
    NodoEscritorio * nuevo=new NodoEscritorio(id);
    if(this->cabeza==NULL){
        this->cabeza=nuevo;
    }else{
        NodoEscritorio * aux=this->cabeza;
       // int entro=0;
        while(aux!=NULL){
            if(strcmp(nuevo->id,aux->id)<0){
                if(aux==this->cabeza){
                    nuevo->siguiente=aux;
                    aux->anterior=nuevo;
                    this->cabeza=nuevo;
                }else{
                    aux->anterior->siguiente=nuevo;
                    nuevo->anterior=aux->anterior;
                    nuevo->siguiente=aux;
                    aux->anterior=nuevo;
                }
                break;
            }else if(aux->siguiente==NULL){
                aux->siguiente=nuevo;
                nuevo->anterior=aux;
                break;
            }
            aux=aux->siguiente;
        }
    }
}

ListaMaletas::ListaMaletas(){
    this->cabeza=NULL;
    this->contador=0;
}

void ListaMaletas::Insertar(){
    this->contador++;
    NodoMaleta * nuevo=new NodoMaleta(this->contador);
    if(this->cabeza==NULL){
        this->cabeza=nuevo;
        nuevo->siguiente=this->cabeza;
        nuevo->anterior=this->cabeza;
    }else{
        nuevo->anterior=this->cabeza->anterior;
        nuevo->siguiente=this->cabeza;
        this->cabeza->anterior->siguiente=nuevo;
        this->cabeza->anterior=nuevo;
    }
}

void ListaMaletas::Eliminar(){
    NodoMaleta * aux=this->cabeza;
    this->cabeza=aux->siguiente;
    aux->anterior->siguiente=this->cabeza;
    this->cabeza->anterior=aux->anterior;
}

ListaMantenimiento::ListaMantenimiento(){
    this->cabeza=NULL;
}

void ListaMantenimiento::Insertar(int id){
    NodoMantenimiento * nuevo = new NodoMantenimiento(id);

    if(this->cabeza==NULL){
        this->cabeza=nuevo;
    }else{
        NodoMantenimiento * aux=this->cabeza;
        while(aux->siguiente!=NULL){
            aux=aux->siguiente;
        }
        aux->siguiente=nuevo;
    }
}
