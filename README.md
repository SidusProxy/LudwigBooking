# LudwigBooking


Ludwig è una piattaforma backend progettata per semplificare la gestione delle prenotazioni tra pazienti e medici, garantendo integrità dei dati, controllo degli accessi e gestione intelligente delle sovrapposizioni degli appuntamenti.

🚀 Obiettivi del progetto

L'obiettivo di Ludwig è fornire un'API moderna, leggera e scalabile per la gestione delle visite mediche, consentendo:

Prenotazione di visite da parte dei pazienti.
Gestione degli slot disponibili da parte dei medici.
Controllo degli accessi tramite autenticazione e autorizzazione.
Individuazione e gestione di conflitti tra prenotazioni.
Garanzia di consistenza e integrità dei dati.
✨ Funzionalità principali
🔐 Autenticazione e Autorizzazione

Il sistema implementa meccanismi di autenticazione e autorizzazione per distinguere i diversi ruoli applicativi:

Pazienti
Medici
Amministratori (se previsti)

Le policy di autorizzazione consentono di limitare l'accesso alle risorse e alle operazioni in base al ruolo dell'utente autenticato.

📅 Gestione delle Prenotazioni

Ludwig permette la creazione, modifica e consultazione delle prenotazioni delle visite mediche.

Funzionalità incluse:

Creazione di nuove prenotazioni.
Visualizzazione delle prenotazioni associate a pazienti e medici.
Aggiornamento dello stato delle prenotazioni.
Gestione delle cancellazioni.
⚠️ Gestione Overlapping e Conflitti

Il sistema rileva automaticamente eventuali sovrapposizioni temporali tra appuntamenti.

Caratteristiche:

Verifica della disponibilità del medico durante la prenotazione.
Identificazione di slot che entrano in conflitto con appuntamenti esistenti.
Segnalazione delle prenotazioni che presentano overlapping.
🔍 Filtraggio degli Slot Disponibili

Per migliorare l'esperienza di prenotazione, Ludwig espone funzionalità di ricerca degli slot realmente prenotabili.

Il filtraggio tiene conto di:

Disponibilità del medico.
Prenotazioni già confermate.
Eventuali conflitti esistenti.
Regole di business configurate.
🚩 Prenotazioni con Flag di Overlapping

In scenari specifici è possibile registrare una prenotazione anche in presenza di sovrapposizioni.

In questi casi il sistema:

Consente la registrazione della prenotazione.
Applica un flag dedicato di Overlapping.
Mantiene traccia del conflitto per successive verifiche o approvazioni.
🛡️ Integrità e Gestione dei Dati

Ludwig garantisce la consistenza delle informazioni attraverso:

Validazione degli input.
Vincoli applicativi e di persistenza.
Controlli sulle relazioni tra entità.
Gestione delle transazioni.
Prevenzione di dati inconsistenti o duplicati.
🏗️ Architettura

Il progetto è sviluppato utilizzando:

ASP.NET Core Minimal API
Entity Framework Core
JWT Authentication
Database relazionale (SQL Server/PostgreSQL)
Dependency Injection
RESTful API Design
