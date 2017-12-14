#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include "estructuras.h"

#include <QtGui/QMainWindow>

namespace Ui
{
    class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    ColaAviones * avionesLlegada;
    ColaAviones * avionesMantenimiento;
    ColaPasajeros * pasajeros;
    NodoAvion * desabordaje, * avionArribo;
    ListaEscritorios * escritorios;
    ListaMaletas * maletas;
    ListaMantenimiento * mantenimiento;
    int cantidadAviones, cantidadEscritorios, turnos, cantidadEstaciones, turnoActual;
    char * contenido;
    int contadorMaletas;

public:
    MainWindow(QWidget *parent = 0);
    ~MainWindow();
    void iniciarSimulacion();
    void cambiarTurno();
    void generarGrafo();
    void consola();

private:
    Ui::MainWindow *ui;

private slots:
    void on_botonSiguiente_clicked();
    void on_botonIniciar_clicked();
};

#endif // MAINWINDOW_H
