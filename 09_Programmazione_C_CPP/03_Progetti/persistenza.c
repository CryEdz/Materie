#include <stdio.h>
#include "persistenza.h"

//Salva su file 
void salvaFile(Camera camere[], int nCamere, Prenotazione pren[], int nPren,
               const char *nomefile)
{
    FILE *f = fopen(nomefile, "wb");
    if (!f) {
        printf("Errore: impossibile aprire '%s' per la scrittura.\n", nomefile);
        return;
    }
    fwrite(&nCamere, sizeof(int), 1, f);
    fwrite(camere, sizeof(Camera), (size_t)nCamere, f);
    fwrite(&nPren, sizeof(int), 1, f);
    fwrite(pren, sizeof(Prenotazione), (size_t)nPren, f);
    fclose(f);
    printf("Dati salvati su '%s'.\n", nomefile);
}

//Carica dal file 
int caricaFile(Camera camere[], int *nCamere, Prenotazione pren[], int *nPren,
               const char *nomefile)
{
    FILE *f = fopen(nomefile, "rb");
    if (!f) {
        printf("File '%s' non trovato.\n", nomefile);
        return 0;
    }

    if (fread(nCamere, sizeof(int), 1, f) != 1 ||
        *nCamere < 0 || *nCamere > MAX_CAMERE) {
        fclose(f);
        return 0;
    }
    if (fread(camere, sizeof(Camera), (size_t)*nCamere, f) != (size_t)*nCamere) {
        fclose(f);
        return 0;
    }
    if (fread(nPren, sizeof(int), 1, f) != 1 ||
        *nPren < 0 || *nPren > MAX_PREN) {
        fclose(f);
        return 0;
    }
    if (fread(pren, sizeof(Prenotazione), (size_t)*nPren, f) != (size_t)*nPren) {
        fclose(f);
        return 0;
    }

    fclose(f);
    printf("Dati caricati da '%s'.\n", nomefile);
    return 1;
}
