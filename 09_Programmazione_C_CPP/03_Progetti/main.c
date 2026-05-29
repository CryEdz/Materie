#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>
#include "camera.h"
#include "prenotazione.h"
#include "persistenza.h"

// Utilità
static void inizializzaCamere(Camera camere[], int n)
{
    int i;
    for (i = 0; i < n; i++) {
        camere[i].numero  = i + 1;
        camere[i].occupata = 0;
        if      (i < 20) camere[i].tipo = 1; // singola  1-20  
        else if (i < 35) camere[i].tipo = 2; // doppia  21-35  
        else             camere[i].tipo = 3; // suite   36-50  
    }
}

// Legge un intero da input con validazione (min-max).
static int leggiIntero(const char *prompt, int min, int max)
{
    char buf[64];
    int val;
    for (;;) {
        printf("%s", prompt);
        if (!fgets(buf, (int)sizeof(buf), stdin))
            continue;
        if (sscanf(buf, "%d", &val) == 1 && val >= min && val <= max)
            return val;
        printf("Inserire un numero tra %d e %d.\n", min, max);
    }
}

// main
int main(void)
{
    Camera       camere[MAX_CAMERE];
    Prenotazione prenotazioni[MAX_PREN];
    int          nCamere = MAX_CAMERE;
    int          nPren   = 0;
    char         giornoOggi[6];
    char         buf[128];
    int          scelta;

    inizializzaCamere(camere, nCamere);

    {
        time_t now = time(NULL);
        struct tm *tm_info = localtime(&now);
        if (tm_info) {
            sprintf(giornoOggi, "%02d-%02d", tm_info->tm_mday, tm_info->tm_mon + 1);
        } else {
            strcpy(giornoOggi, "01-01");
        }
    }

    do {
        printf("\n=== GESTIONE HOTEL ===\n");
        printf("Giorno corrente: %s\n", giornoOggi);
        printf("1. Check-in\n");
        printf("2. Check-out\n");
        printf("3. Cerca prenotazione per nome\n");
        printf("4. Visualizza camere libere per tipo\n");
        printf("5. Incasso totale del giorno\n");
        printf("6. Salva dati su file\n");
        printf("7. Carica dati da file\n");
        printf("0. Esci\n");
        printf("Scelta: ");

        if (!fgets(buf, (int)sizeof(buf), stdin))
            continue;
        if (sscanf(buf, "%d", &scelta) != 1)
            scelta = -1;

        switch (scelta) {

        //check-in
        case 1: {
            int tipo = leggiIntero("Tipo camera (1=Singola, 2=Doppia, 3=Suite): ", 1, 3);
            checkIn(camere, nCamere, prenotazioni, &nPren, tipo);
            break;
        }

        //check-out
        case 2: {
            int idx;
            printf("Nome ospite per check-out: ");
            if (!fgets(buf, (int)sizeof(buf), stdin)) break;
            buf[strcspn(buf, "\n")] = '\0';
            idx = cercaPrenotazionePerNome(prenotazioni, nPren, buf);
            if (idx == -1) {
                printf("Prenotazione non trovata.\n");
            } else {
                int conf;
                printf("Trovata: %s | Camera %d | Arrivo: %s | Partenza: %s\n",
                       prenotazioni[idx].nomeOspite,
                       prenotazioni[idx].numeroCamera,
                       prenotazioni[idx].giornoArrivo,
                       prenotazioni[idx].giornoPartenza);
                printf("Confermare check-out? (1=si, 0=no): ");
                if (!fgets(buf, (int)sizeof(buf), stdin)) break;
                if (sscanf(buf, "%d", &conf) == 1 && conf == 1)
                    checkOut(camere, prenotazioni, &nPren, idx, giornoOggi);
                else
                    printf("Check-out annullato.\n");
            }
            break;
        }

        //cerca prenotazione
        case 3: {
            int idx;
            printf("Nome ospite da cercare: ");
            if (!fgets(buf, (int)sizeof(buf), stdin)) break;
            buf[strcspn(buf, "\n")] = '\0';
            idx = cercaPrenotazionePerNome(prenotazioni, nPren, buf);
            if (idx == -1) {
                printf("Prenotazione non trovata.\n");
            } else {
                printf("Prenotazione trovata:\n");
                printf("  Nome:      %s\n",  prenotazioni[idx].nomeOspite);
                printf("  Camera:    %d\n",  prenotazioni[idx].numeroCamera);
                printf("  Arrivo:    %s\n", prenotazioni[idx].giornoArrivo);
                printf("  Partenza:  %s\n", prenotazioni[idx].giornoPartenza);
                printf("  Colazione: %s\n",
                       prenotazioni[idx].colazione ? "si" : "no");
            }
            break;
        }

        //visualizza camere libere
        case 4: {
            int tipo;
            const char *nomiTipo[] = {"", "Singole", "Doppie", "Suite"};
            tipo = leggiIntero("Tipo camera (1=Singola, 2=Doppia, 3=Suite): ", 1, 3);
            printf("Camere %s libere:\n", nomiTipo[tipo]);
            stampaLibere(camere, nCamere, tipo);
            break;
        }

        //incasso totale del giorno
        case 5: {
            float totale = incassoTotaleGiorno(camere, prenotazioni, nPren, giornoOggi);
            printf("Incasso totale per il giorno %s: %.2f EUR\n", giornoOggi, totale);
            break;
        }

        //salva dati su file
        case 6: {
            salvaFile(camere, nCamere, prenotazioni, nPren, "hotel.dat");
            break;
        }

        //carica dati da file
        case 7: {
            caricaFile(camere, &nCamere, prenotazioni, &nPren, "hotel.dat");
            break;
        }
        
        //esci
        case 0:
            printf("Arrivederci!\n");
            break;

        default:
            printf("Scelta non valida.\n");
            break;
        }

    } while (scelta != 0);

    return 0;
}
