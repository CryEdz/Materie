#ifndef PRENOTAZIONE_H
#define PRENOTAZIONE_H

#include "camera.h"

#define MAX_PREN 50

typedef struct {
    int  numeroCamera;
    char nomeOspite[80];
    char giornoArrivo[6];    // formato gg-mm 
    char giornoPartenza[6];  // formato gg-mm 
    int  colazione;          // 1=inclusa, 0=no 
} Prenotazione;

// Calcola il costo del soggiorno (tipo camera, numero notti, colazione).
float calcolaCostoSoggiorno(int tipo, int notti, int colazione);

// Restituisce l'indice della prenotazione con quel nome, -1 se non trovata.
int cercaPrenotazionePerNome(Prenotazione pren[], int n, const char *nome);

// Effettua il check-in: trova prima camera libera del tipo scelto,
// la segna come occupata e registra la prenotazione.
void checkIn(Camera camere[], int nCamere, Prenotazione pren[], int *nPren,
             int tipo);

// Effettua il check-out: calcola costo, libera la camera, rimuove
// la prenotazione dall'array, scrive su log_checkout.txt.
void checkOut(Camera camere[], Prenotazione pren[], int *nPren,
              int indice, const char *giornoOggi);

// Somma i costi di tutti i check-out del giorno (giornoPartenza == giornoOggi).
float incassoTotaleGiorno(Camera camere[], Prenotazione pren[], int nPren,
                          const char *giornoOggi);

#endif
