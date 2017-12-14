/********************************************************************************
** Form generated from reading ui file 'mainwindow.ui'
**
** Created: Tue 12. Dec 22:15:16 2017
**      by: Qt User Interface Compiler version 4.5.2
**
** WARNING! All changes made in this file will be lost when recompiling ui file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QLineEdit>
#include <QtGui/QMainWindow>
#include <QtGui/QMenuBar>
#include <QtGui/QPushButton>
#include <QtGui/QStatusBar>
#include <QtGui/QTextEdit>
#include <QtGui/QToolBar>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;
    QLineEdit *textAviones;
    QLineEdit *textEscritorios;
    QLineEdit *textMantenimiento;
    QLabel *label_5;
    QLineEdit *textTurnos;
    QLabel *label_6;
    QTextEdit *textConsola;
    QPushButton *botonIniciar;
    QPushButton *botonSiguiente;
    QPushButton *botonImagen;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(757, 510);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        label = new QLabel(centralWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 10, 81, 21));
        QFont font;
        font.setPointSize(10);
        font.setBold(true);
        font.setWeight(75);
        label->setFont(font);
        label_2 = new QLabel(centralWidget);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(10, 30, 51, 16));
        QFont font1;
        font1.setPointSize(10);
        label_2->setFont(font1);
        label_3 = new QLabel(centralWidget);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(10, 60, 61, 16));
        label_3->setFont(font1);
        label_4 = new QLabel(centralWidget);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(10, 90, 91, 31));
        QFont font2;
        font2.setPointSize(10);
        font2.setUnderline(false);
        label_4->setFont(font2);
        label_4->setLineWidth(1);
        label_4->setTextFormat(Qt::AutoText);
        textAviones = new QLineEdit(centralWidget);
        textAviones->setObjectName(QString::fromUtf8("textAviones"));
        textAviones->setGeometry(QRect(110, 30, 51, 20));
        textEscritorios = new QLineEdit(centralWidget);
        textEscritorios->setObjectName(QString::fromUtf8("textEscritorios"));
        textEscritorios->setGeometry(QRect(110, 60, 51, 20));
        textMantenimiento = new QLineEdit(centralWidget);
        textMantenimiento->setObjectName(QString::fromUtf8("textMantenimiento"));
        textMantenimiento->setGeometry(QRect(110, 100, 51, 20));
        label_5 = new QLabel(centralWidget);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(10, 130, 61, 16));
        label_5->setFont(font1);
        textTurnos = new QLineEdit(centralWidget);
        textTurnos->setObjectName(QString::fromUtf8("textTurnos"));
        textTurnos->setGeometry(QRect(110, 130, 51, 20));
        label_6 = new QLabel(centralWidget);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(10, 190, 81, 21));
        label_6->setFont(font);
        textConsola = new QTextEdit(centralWidget);
        textConsola->setObjectName(QString::fromUtf8("textConsola"));
        textConsola->setGeometry(QRect(10, 210, 151, 241));
        botonIniciar = new QPushButton(centralWidget);
        botonIniciar->setObjectName(QString::fromUtf8("botonIniciar"));
        botonIniciar->setGeometry(QRect(10, 160, 51, 24));
        botonSiguiente = new QPushButton(centralWidget);
        botonSiguiente->setObjectName(QString::fromUtf8("botonSiguiente"));
        botonSiguiente->setGeometry(QRect(70, 160, 91, 31));
        QFont font3;
        font3.setPointSize(11);
        font3.setBold(true);
        font3.setWeight(75);
        botonSiguiente->setFont(font3);
        botonImagen = new QPushButton(centralWidget);
        botonImagen->setObjectName(QString::fromUtf8("botonImagen"));
        botonImagen->setGeometry(QRect(170, 10, 581, 441));
        botonImagen->setIconSize(QSize(575, 435));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QString::fromUtf8("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 757, 21));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        MainWindow->setStatusBar(statusBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "MainWindow", 0, QApplication::UnicodeUTF8));
        label->setText(QApplication::translate("MainWindow", "Simulaci\303\263n", 0, QApplication::UnicodeUTF8));
        label_2->setText(QApplication::translate("MainWindow", "Aviones", 0, QApplication::UnicodeUTF8));
        label_3->setText(QApplication::translate("MainWindow", "Escritorios", 0, QApplication::UnicodeUTF8));
        label_4->setText(QApplication::translate("MainWindow", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:'MS Shell Dlg 2'; font-size:8.25pt; font-weight:400; font-style:normal;\">\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><span style=\" font-size:10pt;\">Estaciones de</span></p>\n"
"<p style=\" margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><span style=\" font-size:10pt;\">Mantenimiento</span></p></body></html>", 0, QApplication::UnicodeUTF8));
        label_5->setText(QApplication::translate("MainWindow", "Turnos", 0, QApplication::UnicodeUTF8));
        label_6->setText(QApplication::translate("MainWindow", "Consola", 0, QApplication::UnicodeUTF8));
        textConsola->setHtml(QApplication::translate("MainWindow", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:'MS Shell Dlg 2'; font-size:8.25pt; font-weight:400; font-style:normal;\">\n"
"<p style=\"-qt-paragraph-type:empty; margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px; font-size:8pt;\"></p></body></html>", 0, QApplication::UnicodeUTF8));
        botonIniciar->setText(QApplication::translate("MainWindow", "Iniciar", 0, QApplication::UnicodeUTF8));
        botonSiguiente->setText(QApplication::translate("MainWindow", "Siguiente", 0, QApplication::UnicodeUTF8));
        botonImagen->setText(QString());
        Q_UNUSED(MainWindow);
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
