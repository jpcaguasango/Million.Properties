# 🏠 Million Properties - Backend API

Backend desarrollado en **.NET 9** para el manejo de propiedades inmobiliarias. La API está organizada en capas y utiliza **MongoDB** como base de datos. Las imágenes de las propiedades se obtienen mediante la **API de Unsplash**.

---

## 📝 Requisitos

* **NET 9**
* **MongoDB** (local o en la nube)
* **Visual Studio** o **VS Code**

Antes de ejecutar el proyecto, asegúrate de tener una base de datos MongoDB corriendo y configurada correctamente en `appsettings.json` o variables de entorno.

---

## ⚡ Instalación y ejecución

```bash
# Restaurar paquetes
dotnet restore

# Ejecutar la API
dotnet run --project Million.Properties.WebApi
```

La API estará disponible por defecto en [https://localhost:5114/](http://localhost:5114/).

La documentación Swagger estará disponible en [http://localhost:5114/swagger/index.html](http://localhost:5114/swagger/index.html).

---

## 🚀 Endpoints

| Método | URL                       | Descripción                                                                                              |
|--------|---------------------------|----------------------------------------------------------------------------------------------------------|
| `GET`  | `/api/properties`         | Obtiene la lista de propiedades disponibles en la base de datos. Cada propiedad incluye imágenes obtenidas mediante la API de Unsplash. |
| `GET`  | `/api/properties/populate`| Inserta propiedades de ejemplo en la base de datos y retorna la lista creada. Las imágenes también se obtienen desde Unsplash.       |

### Ejemplo de respuesta (`/api/properties`):

```json
[
  {
    "id": "123",
    "name": "Casa Bonita",
    "address": "Calle 123 #45-67",
    "price": 500000,
    "year": 2020,
    "codeInternal": "A001",
    "owner": {
      "name": "Juan Perez",
      "photo": "/images/owner.jpg"
    },
    "propertyImages": [
       {
         "file": "[https://images.unsplash.com/photo-xxxx](https://images.unsplash.com/photo-xxxx)"   
       }
    ]
  }
]
```

---
## 🛠 Tecnologías utilizadas

* **.NET 9**
* **MongoDB**
* **AutoMapper**
* **ASP.NET Core Web API**
* **Swagger** (documentación integrada)
* **Unsplash API** (para imágenes de propiedades)

---

## ⚠️ Notas importantes

* Configura la conexión a **MongoDB** en `appsettings.json`.
* Las imágenes de propiedades se obtienen dinámicamente desde la **API de Unsplash**, por lo que es necesario tener conexión a Internet.
* La documentación de la API está disponible mediante **Swagger**, por defecto en `/swagger`.
