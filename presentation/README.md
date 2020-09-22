---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('./images/hero-background.jpg')
marp: true
---

![bg left:40% 40%](./images/800px-C_Sharp_logo.svg.png)

# **Dependency Injection**

---

<!-- textAlign: center -->
# Container/ Registry erstellen

Zum Verwenden des Microsoft eigenen DI-Containers wird
__Microsoft.Extensions.DependencyInjection__
benötigt.

```cs

IServiceCollection collection = new ServiceCollection();

```

Bekannte Alternativen: Autofac, Lamar, Castle Windsor

---

# Service lifetimes

- Transient → Wird bei jedem Aufruf erstellt
- Scoped → Wird einmal pro Scope erstellt
- Singleton → Service wird nur einmal erstellt

---

# Services registrieren
##### Über die Extensionmethods

```cs

IServiceCollection collection = new ServiceCollection();

collection.AddTransient<MyService>();

collection.AddScoped<MyService>();

collection.AddSingleton<MyService>();

```

---

# Services registrieren
##### 'Interfaces/Abstrakte Klassen' registrieren

```cs

IServiceCollection collection = new ServiceCollection();

collection.AddScoped<IMyService, MyService>();

collection.AddScoped<MyAbstractType, MyConcreteType>();

```

---

# Services registrieren
##### Mit einer Factory

```cs

AddScoped<T>(Func<IServiceProvider, T> factory);

string connectionString = "...";
collection.AddScoped<MyService>(
    sp => new MyService(
        connectionString,
        sp.GetRequiredService<MyClient>()
    )
);

```

---

# ServiceProvider

```cs

IServiceCollection collection = new ServiceCollection();
services.AddSingleton<MyService>();
IServiceProvider provider = collection.BuildServiceProvider();

// Schmeißt eine Exception, wenn der Service nicht existiert
// => Gibt niemals null zurück
MyService service = provider.GetRequiredService<MyService>();

// Kann null zurückgeben, wenn Service nicht bekannt
MyService service2 = provider.GetService<MyService>();

```

---

# Beschaffenheit von einer Klasse

```cs

public class MyService 
{
    public MyService(MyClient client) { ... }

    // Service-Initialisierung wird bevorzugt
    public MyService(MyClient client, ServiceSettings settings) { ... }
}

```

---

# Vorteile
- Kein Singleton-Pattern mehr (bei Singletons)
- Zentraler Punkt, wo Services registriert oder ggf. ausgetauscht werden können
- Abstraktere Implementierungen/ Interfaces
  - Services müssen nicht wissen, wie andere Services initialisiert werden müssen -> Keine doppelten Service Initialisierungen
  - Erleichtertes mocken
- IDisposable wird automatisch disposed 

---

# Nachteile
- Basiert auf Reflection
  - Kann böse sein (starke Performanceverluste)
  - ABER: Nur beim Erstellen des ServiceProviders
- Komplexität steigt leicht
  - Es ist wichtig, dass alle Services korrekt registriert werden
  - Auto-Discovery von Services