#ifndef PERSISTENZA_H
#define PERSISTENZA_H

#include "camera.h"
#include "prenotazione.h"

// Salva lo stato corrente (camere + prenotazioni) su file binario.
void salvaFile(Camera camere[], int nCamere, Prenotazione pren[], int nPren,
               const char *nomefile);

// Carica lo stato da file binario.
int caricaFile(Camera camere[], int *nCamere, Prenotazione pren[], int *nPren,
               const char *nomefile);

#endif
