#ifndef CAMERA_H
#define CAMERA_H

#define MAX_CAMERE 50

typedef struct {
    int numero;   // numero camera (1-50)         
    int tipo;     // 1=singola, 2=doppia, 3=suite 
    int occupata; // 0=libera, 1=occupata         
} Camera;

// Restituisce l'indice della prima camera libera del tipo specificato,
// -1 se non trovata.
int trovaPrimaLibera(Camera camere[], int n, int tipo);

// Stampa tutte le camere libere del tipo specificato.
void stampaLibere(Camera camere[], int n, int tipo);

#endif 
