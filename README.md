# Sistema Gestor de Ventas e Inventario Express (Mini-POS)

**Estudiante:** Edinso Barros Lopez  
**Módulo:** Unidad 1 — Fundamentos de C# (.NET 8)  

## Descripción

Aplicación de consola desarrollada en C# (.NET 8) que simula un punto de venta e inventario básico para una tienda local. Permite registrar productos, consultar el inventario, procesar ventas aplicando IVA (19%) y descuento por cliente frecuente (10%), y consultar un reporte de caja con las estadísticas de la sesión.

El proyecto utiliza únicamente los conceptos de la Unidad 1: variables y tipos primitivos, colecciones (`List<T>`), estructuras de control, métodos estáticos y manejo seguro de errores con `TryParse`. No se implementa Programación Orientada a Objetos (clases personalizadas) ni bases de datos; toda la información se maneja en memoria durante la ejecución.

## Demostración

*(Agrega aquí un GIF o una imagen que muestre la aplicación en ejecución)*

![Captura de pantalla del sistema en consola](ruta/a/tu/imagen-o-gif.png)

## Funcionalidades

- **Registro de productos:** Validación de nombre único, precio mayor a cero y stock no negativo.
- **Consulta de inventario:** Listado completo con alerta visual de bajo stock (menos de 5 unidades).
- **Registro de ventas:** Validación de stock disponible, cálculo automático de subtotal, descuento (10%), IVA (19%) y total, además de la generación de ticket en pantalla.
- **Reporte de caja:** Resumen con total de ventas realizadas, dinero acumulado, promedio por venta y producto más vendido.

## Requisitos

- **.NET 8 SDK** instalado ([Descargar .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0))

## Cómo clonar y ejecutar

Clona el repositorio, entra a la carpeta del proyecto y ejecútalo mediante la consola de comandos:

```bash
git clone [https://github.com/Elobar/parcialElectiva](https://github.com/Elobar/parcialElectiva)
cd parcialElectiva
dotnet run
