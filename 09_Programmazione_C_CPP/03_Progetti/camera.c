#include <stdio.h>
#include "camera.h"

// Trova la prima stanza libera
int trovaPrimaLibera(Camera camere[], int n, int tipo)
{
    int i;
    for (i = 0; i < n; i++) {
        if (camere[i].tipo == tipo && camere[i].occupata == 0)
            return i;
    }
    return -1;
}

//Mostra le camere libere
void stampaLibere(Camera camere[], int n, int tipo)
{
    const char *nomiTipo[] = {"", "Singola", "Doppia", "Suite"};
    int trovate = 0;
    int i;
    for (i = 0; i < n; i++) {
        if (camere[i].tipo == tipo && camere[i].occupata == 0) {
            printf("  Camera %d (%s)\n", camere[i].numero, nomiTipo[tipo]);
            trovate++;
        }
    }
    if (trovate == 0)
        printf("  Nessuna camera libera di tipo %s.\n", nomiTipo[tipo]);
}
