#ifndef ESTRUCTURAS_H
#define ESTRUCTURAS_H

typedef struct NodoAvion{
    int id;
    int tipo;
    int pasajeros;
    int desabordaje;
    int mantenimiento;
    NodoAvion();
    NodoAvion * siguiente;
    NodoAvion * anterior;
}NodoAvion;

typedef struct NodoPasajero{
    int id;
    int maletas;
    int documentos;
    int registro;
    NodoPasajero();
    NodoPasajero * siguiente;
}NodoPasajero;

typedef struct ColaAviones{
    NodoAvion * cabeza;
    ColaAviones();
    void Insertar(NodoAvion * nuevo);
    NodoAvion * Sacar();
}ColaAviones;

typedef struct ColaPasajeros{
    NodoPasajero * cabeza;
    ColaPasajeros();
    void Insertar(NodoPasajero * nuevo);
    NodoPasajero * Sacar();
}ColaPasajeros;

typedef struct NodoPila{
    int id;
    NodoPila(int id);
    NodoPila * siguiente;
}NodoPila;

typedef struct Pila{
    NodoPila * cabeza;
    Pila();
    void Insertar(int id);
    NodoPila * Sacar();
}Pila;

typedef struct NodoEscritorio{
    char * id;
    NodoPasajero * cliente;
    int cantidad;
    int documentos;
    int turnos;
    NodoEscritorio(char * id);
    NodoEscritorio * siguiente;
    NodoEscritorio * anterior;
    ColaPasajeros * cola;
    Pila * pila;
}NodoEscritorio;

typedef struct NodoMantenimiento{
    int id;
    int estado;
    int turnos;
    NodoAvion * avion;
    NodoMantenimiento(int id);
    NodoMantenimiento * siguiente;
}NodoMantenimiento;

typedef struct NodoMaleta{
    int id;
    NodoMaleta(int id);
    NodoMaleta * siguiente;
    NodoMaleta * anterior;
}NodoMaleta;

typedef struct ListaEscritorios{
    NodoEscritorio * cabeza;
    ListaEscritorios();
    void Insertar(char * id);
}ListaEscritorios;

typedef struct ListaMaletas{
    NodoMaleta * cabeza;
    void Insertar();
    void Eliminar();
    ListaMaletas();
    int contador;
}ListaMaletas;

typedef struct ListaMantenimiento{
    NodoMantenimiento * cabeza;
    void Insertar(int id);
    ListaMantenimiento();
}ListaMantenimiento;

#endif // ESTRUCTURAS_H
