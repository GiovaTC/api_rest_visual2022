# apirestVisual2022

![image](https://github.com/user-attachments/assets/c46f5b3a-55a0-4f58-84e6-dc8fdb18b7cd)


# Documentación de la API REST

Esta API REST permite realizar operaciones CRUD sobre un catálogo de productos.

## Endpoints

### **GET** `/api/Productos`
Obtiene la lista de todos los productos.

#### Respuesta exitosa:
- **Código:** `200 OK`
- **Ejemplo de respuesta:**
```json
[
    {
        "id": 1,
        "nombre": "Laptop",
        "precio": 1500.99,
        "stock": 10
    },
    {
        "id": 2,
        "nombre": "Mouse",
        "precio": 25.50,
        "stock": 100
    }
]
```

---

### **GET** `/api/Productos/{id}`
Obtiene un producto específico por su ID.

#### Parámetros:
- **id:** (int) ID del producto.

#### Respuesta exitosa:
- **Código:** `200 OK`
- **Ejemplo de respuesta:**
```json
{
    "id": 1,
    "nombre": "Laptop",
    "precio": 1500.99,
    "stock": 10
}
```

#### Respuesta en caso de error:
- **Código:** `404 Not Found`

---

### **POST** `/api/Productos`
Crea un nuevo producto.

#### Cuerpo de la solicitud:
```json
{
    "nombre": "Teclado",
    "precio": 50.75,
    "stock": 20
}
```

#### Respuesta exitosa:
- **Código:** `201 Created`
- **Ejemplo de respuesta:**
```json
{
    "id": 3,
    "nombre": "Teclado",
    "precio": 50.75,
    "stock": 20
}
```

---

### **PUT** `/api/Productos/{id}`
Actualiza un producto existente.

#### Parámetros:
- **id:** (int) ID del producto.

#### Cuerpo de la solicitud:
```json
{
    "nombre": "Mouse Inalámbrico",
    "precio": 30.00,
    "stock": 80
}
```

#### Respuesta exitosa:
- **Código:** `204 No Content`

#### Respuesta en caso de error:
- **Código:** `404 Not Found`

---

### **DELETE** `/api/Productos/{id}`
Elimina un producto por su ID.

#### Parámetros:
- **id:** (int) ID del producto.

#### Respuesta exitosa:
- **Código:** `204 No Content`

#### Respuesta en caso de error:
- **Código:** `404 Not Found`

---

## Configuración Adicional

### Habilitar CORS
Si necesitas permitir el acceso desde otros dominios, agrega el siguiente código en `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

app.UseCors("PermitirTodos");
```

### Swagger
La API incluye documentación generada automáticamente con Swagger. Accede a ella en la URL base del proyecto.

---

## Ejecución
1. Clona el repositorio.
2. Ejecuta el proyecto en Visual Studio 2022.
3. Accede a la API en `https://localhost:{puerto}/api/Productos`.

---

¡Gracias por usar esta API REST!

