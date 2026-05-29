#include <stdio.h>
#include <string.h>
#include "prenotazione.h"

// restituisce quanti giorni ha un mese (anno non bisestile)
static int giorniDelMese(int mm)
{
    switch (mm) {
        case 1: case 3: case 5: case 7: case 8: case 10: case 12:
            return 31;
        case 4: case 6: case 9: case 11:
            return 30;
        case 2:
            return 28;
        default:
            return 0;
    }
}

// converte gg-mm in giorno dell'anno (1-365), -1 se data non valida
static int ggmmInGiorno(int gg, int mm)
{
    int i;
    int giorno = gg;
    int maxGiorni = giorniDelMese(mm);

    if (maxGiorni == 0) return -1;
    if (gg < 1 || gg > maxGiorni) return -1;

    for (i = 1; i < mm; i++)
        giorno += giorniDelMese(i);

    return giorno;
}

// legge una data valida in formato gg-mm
static void leggiData(const char *prompt, char risultato[6], int giornoMin)
{
    char buf[64];
    int gg, mm;
    int giorno;

    for (;;) {
        printf("%s", prompt);
        if (!fgets(buf, (int)sizeof(buf), stdin))
            continue;

        if (sscanf(buf, "%d-%d", &gg, &mm) != 2) {
            printf("Formato non valido. Usa gg-mm (es. 15-07).\n");
            continue;
        }

        giorno = ggmmInGiorno(gg, mm);
        if (giorno == -1) {
            printf("Data non valida. Riprova.\n");
            continue;
        }

        if (giorno < giornoMin) {
            printf("La data deve essere successiva a quella di arrivo.\n");
            continue;
        }

        sprintf(risultato, "%02d-%02d", gg, mm);
        return;
    }
}

// calcola numero notti da check-in a check-out (partenza - arrivo)
static int calcolaNotti(const char *arrivo, const char *partenza)
{
    int gg1, mm1, gg2, mm2;
    sscanf(arrivo,   "%d-%d", &gg1, &mm1);
    sscanf(partenza, "%d-%d", &gg2, &mm2);
    return ggmmInGiorno(gg2, mm2) - ggmmInGiorno(gg1, mm1);
}

// tariffe
#define TARIFFA_SINGOLA  60.0f
#define TARIFFA_DOPPIA   90.0f
#define TARIFFA_SUITE   150.0f
#define SUPPLEMENTO_COL  12.0f

float calcolaCostoSoggiorno(int tipo, int notti, int colazione)
{
    float base = 0.0f;
    switch (tipo) {
        case 1: base = TARIFFA_SINGOLA; break;
        case 2: base = TARIFFA_DOPPIA;  break;
        case 3: base = TARIFFA_SUITE;   break;
        default: base = 0.0f;           break;
    }
    if (colazione)
        base += SUPPLEMENTO_COL;
    return base * (float)notti;
}

int cercaPrenotazionePerNome(Prenotazione pren[], int n, const char *nome)
{
    int i;
    for (i = 0; i < n; i++) {
        if (strcmp(pren[i].nomeOspite, nome) == 0)
            return i;
    }
    return -1;
}

void checkIn(Camera camere[], int nCamere, Prenotazione pren[], int *nPren,
             int tipo)
{
    char buf[128];
    Prenotazione p;
    int idx;

    if (*nPren >= MAX_PREN) {
        printf("Numero massimo di prenotazioni raggiunto.\n");
        return;
    }

    idx = trovaPrimaLibera(camere, nCamere, tipo);
    if (idx == -1) {
        printf("Nessuna camera libera del tipo richiesto.\n");
        return;
    }

    // nome ospite 
    printf("Nome ospite: ");
    if (!fgets(buf, (int)sizeof(buf), stdin)) return;
    buf[strcspn(buf, "\n")] = '\0';
    if (buf[0] == '\0') {
        printf("Nome non valido. Check-in annullato.\n");
        return;
    }
    strncpy(p.nomeOspite, buf, (int)sizeof(p.nomeOspite) - 1);
    p.nomeOspite[sizeof(p.nomeOspite) - 1] = '\0';

    // giorno arrivo
    leggiData("Data arrivo (gg-mm, es. 15-07): ", p.giornoArrivo, 1);

    // giorno partenza
    {
        int gg, mm;
        sscanf(p.giornoArrivo, "%d-%d", &gg, &mm);
        leggiData("Data partenza (gg-mm, dopo l'arrivo): ",
                  p.giornoPartenza, ggmmInGiorno(gg, mm) + 1);
    }

    // colazione
    printf("Colazione inclusa? (1=si, 0=no): ");
    if (!fgets(buf, (int)sizeof(buf), stdin)) return;
    if (sscanf(buf, "%d", &p.colazione) != 1)
        p.colazione = 0;
    if (p.colazione != 1)
        p.colazione = 0;

    // registrazione
    p.numeroCamera = camere[idx].numero;
    camere[idx].occupata = 1;
    pren[*nPren] = p;
    (*nPren)++;

    {
        int notti = calcolaNotti(p.giornoArrivo, p.giornoPartenza);
        float costo = calcolaCostoSoggiorno(tipo, notti, p.colazione);
        printf("Check-in effettuato. Camera %d assegnata a %s.\n",
               p.numeroCamera, p.nomeOspite);
        printf("Costo previsto: %.2f EUR (%d notti)\n", costo, notti);
    }
}

static int trovaCameraPerNumero(Camera camere[], int numero)
{
    int i;
    for (i = 0; i < MAX_CAMERE; i++) {
        if (camere[i].numero == numero)
            return i;
    }
    return -1;
}

void checkOut(Camera camere[], Prenotazione pren[], int *nPren,
              int indice, const char *giornoOggi)
{
    int camIdx;
    int notti;
    int tipo;
    float costo;
    FILE *f;
    int i;

    camIdx = trovaCameraPerNumero(camere, pren[indice].numeroCamera);
    tipo   = (camIdx >= 0) ? camere[camIdx].tipo : 1;
    notti  = calcolaNotti(pren[indice].giornoArrivo, pren[indice].giornoPartenza);
    costo  = calcolaCostoSoggiorno(tipo, notti, pren[indice].colazione);

    printf("Check-out: %s | Camera %d | Costo totale: %.2f EUR\n",
           pren[indice].nomeOspite, pren[indice].numeroCamera, costo);

    // log su file
    f = fopen("log_checkout.txt", "a");
    if (f) {
        fprintf(f, "Giorno: %s | Nome: %s | Camera: %d | Totale: %.2f EUR\n",
                giornoOggi, pren[indice].nomeOspite,
                pren[indice].numeroCamera, costo);
        fclose(f);
    }

    // libera camera
    if (camIdx >= 0)
        camere[camIdx].occupata = 0;

    // rimuove prenotazione
    for (i = indice; i < *nPren - 1; i++)
        pren[i] = pren[i + 1];
    (*nPren)--;
}

float incassoTotaleGiorno(Camera camere[], Prenotazione pren[], int nPren,
                          const char *giornoOggi)
{
    float totale = 0.0f;
    int i;
    for (i = 0; i < nPren; i++) {
        if (strcmp(pren[i].giornoPartenza, giornoOggi) == 0) {
            int camIdx = trovaCameraPerNumero(camere, pren[i].numeroCamera);
            int tipo   = (camIdx >= 0) ? camere[camIdx].tipo : 1;
            int notti  = calcolaNotti(pren[i].giornoArrivo, pren[i].giornoPartenza);
            totale += calcolaCostoSoggiorno(tipo, notti, pren[i].colazione);
        }
    }
    return totale;
}
