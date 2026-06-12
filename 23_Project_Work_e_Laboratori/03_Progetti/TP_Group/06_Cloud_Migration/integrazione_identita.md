# Integrazione Identità TP Group

## Architettura IAM TO-BE

```
┌─────────────────────────────────────────────────┐
│                  AD Samba4                      │
│  ┌─────────────┐  ┌─────────────┐              │
│  │  Utenti (50) │  │  Gruppi     │              │
│  │  + password  │  │  + policy   │              │
│  └──────┬──────┘  └──────┬──────┘              │
│         │                │                       │
│  ┌──────┴────────────────┴──────┐               │
│  │    LDAP (porta 389/636)      │               │
│  └──────────────────────────────┘               │
└─────────────────────┬───────────────────────────┘
                      │
        ┌─────────────┴─────────────┐
        │                           │
        ▼                           ▼
┌──────────────────┐     ┌──────────────────┐
│ FortiAuthenticator│     │  GCDS (Google    │
│ + MFA (FortiToken)│     │  Cloud Directory │
│                  │     │  Sync)           │
│ VPN LDAP auth    │     │                  │
│ WiFi auth        │     │  AD → Workspace  │
│ Server access    │     │  utenti/gruppi   │
└──────────────────┘     └────────┬─────────┘
                                  │
                                  ▼
                       ┌──────────────────┐
                       │ Google Workspace │
                       │ (posta, calendar, │
                       │  meet, drive     │
                       │  fino a Fase 4)  │
                       │                  │
                       │ SAML SSO via AD  │
                       └──────────────────┘
```

## Flusso di autenticazione

1. **Utente apre laptop** → login Windows con credenziali AD
2. **Accede a Google Workspace** → redirect SAML a AD → SSO senza password
3. **Accede a VPN** → FortiAuthenticator verifica su AD + richiede MFA (FortiToken push)
4. **Accede a server interni** (SSH/RDP) → autenticazione AD via LDAP
5. **Accede a Odoo** → SAML SSO via AD (se supportato) o password dedicata

## Costi IAM

| Componente | Costo |
| --- | --- |
| AD Samba4 (già esistente, VM Linux) | € 0 |
| Google Cloud Directory Sync (gratuito) | € 0 |
| FortiAuthenticator (virtual edition) | € 1.500 |
| FortiToken mobile (50 unità) | € 500 |
| Configurazione sistemista (5 giorni × €500) | € 2.500 |
| **Totale IAM** | **€ 4.500** |
