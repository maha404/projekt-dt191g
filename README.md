# Projekt DT068G - Hudiksvalls djurklinik

### Välkommen till mitt projekt i kursen DT191G :wave:
Detta projekt skapades som avslutande projekt i kursen DT191G vid Mittuniversitetet.
 
### :open_book: Projektöversikt 
Projektet är uppdelat och består av ett admingränsnitt som kan göra ändringar på den publika webbplatsen genom att lägga till eller ta bort behandlingar som finns att boka.

### :rocket: Funktioner 
+ Admin kan lägga till behandlingstyper, behandlingar och användare. 
+ Vanliga användare kan endast lägga till behandlingstyper och behandlingar. 
+ Användare av webbplatsen kan boka en behandling och se priser på behandlingarna.

### :wrench: Teknologier och Verktyg 
**ASP.NET**: Används för uppbyggnad av admingränssnittet.

**API**: Ett API har skapats för att kunna kommunicera mellan frontend och backend. 

**Blazor WebAssembly**: Används för den publika webbplatsen. 

### :file_folder: Struktur 

#### Admininterface
**admininterface/Areas/Identity/Pages/Account**: Innehåller sidor och relaterad logik för hantering av användarkonton och autentisering, såsom inloggning, registrering och lösenordshantering.

**admininterface/Controllers**: Innehåller controllerklasser som hanterar inkommande HTTP-förfrågningar.

**admininterface/Data**: Innehåller en DbContext-klasser som definerar databasanslutnignar. 

**admininterface/Migrations**: Innehåller Entity Framework-migrationsfiler som används för att hantera ändringar i databasstrukturen över tid.

**admininterface/Models**: Innehåller klasser som speglar databastabeller och används för att överföra data mellan lager i applikationen.

**admininterface/Properties**: Innehåller applikationsmetadata och inställningar.

**admininterface/Views**: Innehåller Razor-vyer som definierar användargränssnittet. Varje vy är kopplad till en specifik controller och dess åtgärder.

**admininterface/wwwroot**: Innehåller statiska filer som JavaScript, CSS, bilder och andra resurser som är tillgängliga för klienten.

---
#### Client 
**client/Layout**: Innehåller layoutfiler som definierar den gemensamma strukturen för undersidorna.Här finns footer, mainLayout och menyn. 

**client/Pages**: Innehåller individuella Razor Pages.

**client/Properties**: Innehåller applikationsmetadata och inställningar.

**client/wwwroot**: innehåller resurser som JavaScript, CSS och bilder som ska användas i klientgränssnittet.

### :star: Vidareutveckling / Förbättrnignar 
+ Skapa djurprofiler och möjligheten att skriva in information om sitt husdjur. Även kunna hantera sina bokningar härifrån. 
+ Implementera ett schema för admingränsnittet för alla anställda. 

### :gear: Installation och körning
1. Klona ner repot: 
    
    `https://github.com/maha404/projekt-dt191g`

2. Se till att XAMPP finns installerat. Skapa en användare i phpMyAdmin som heter "admininterface" och sätt lösenordet till "password" (notera att allt är i gemener). 

3. Efter detta navigera in i mappen för admingränssnittet "admininterface" genom terminalen i Visual studio code.

4. Kör migrationsfilerna som finns genom att skriva `dotnet ef database update` i terminalen.

5. Efter detta är admingränssnittet redo att köras igång! Skriv `dotnet run` i terminalen och klicka in på localhost servern som startas.

6. För att starta den publika webbplatsen öppnas en ny terminal och kommandot `dotnet run` skrivs för att starta en till server med webbplatsen.
