# API CRUD de Productos con .NET

Proyecto de aprendizaje para practicar el uso de .NET con MongoDB.

## Descripción

API REST básica para la gestión de productos (CRUD completo) desarrollada con ASP.NET Core y MongoDB.

## Funcionalidades

- **Crear** producto
- **Leer** todos los productos
- **Leer** producto por ID
- **Actualizar** producto
- **Eliminar** producto

## Tecnologías

- .NET 10.0
- MongoDB
- ASP.NET Core Minimal API
- MongoDB.Driver

## Instalación

1. Clona el repositorio
```bash
git clone https://github.com/FranciscoLopezKanto/Api_productos_.net.git
```

2. Crea un archivo `.env` en la raíz del proyecto con tu conexión a MongoDB:
```
mongodb_uri=tu_conexion_mongodb
```

3. Restaura las dependencias
```bash
dotnet restore
```

4. Ejecuta el proyecto
```bash
dotnet run
```

La API estará disponible en `http://localhost:5005`

## Endpoints

- `GET /api/products` - Obtener todos los productos
- `GET /api/products/{id}` - Obtener producto por ID
- `POST /api/products` - Crear nuevo producto
- `PUT /api/products/{id}` - Actualizar producto
- `DELETE /api/products/{id}` - Eliminar producto

## Ejemplo de Producto

```json
{
  "name": "Taladro Hilti",
  "price": 199990,
  "stock": 3
}
```

## Propósito

Este proyecto fue creado con fines educativos para aprender y practicar el desarrollo de APIs con .NET.
