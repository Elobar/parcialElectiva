# Sistema Gestor de Ventas e Inventario Express (Mini-POS)

**Estudiante:** Edinso Barros Lopez
**Módulo:** Unidad 1 — Fundamentos de C# (.NET 8)

## Descripción

Aplicación de consola desarrollada en C# (.NET 8) que simula un punto de venta e inventario básico para una tienda local. Permite registrar productos, consultar el inventario, procesar ventas aplicando IVA (19%) y descuento por cliente frecuente (10%), y consultar un reporte de caja con las estadísticas de la sesión.

El proyecto utiliza únicamente los conceptos de la Unidad 1: variables y tipos primitivos, colecciones (List<T>), estructuras de control, métodos estáticos y manejo seguro de errores con TryParse. No se implementa Programación Orientada a Objetos (clases personalizadas) ni bases de datos; toda la información se maneja en memoria durante la ejecución.

## Funcionalidades

- Registro de productos con validación de nombre único, precio mayor a cero y stock no negativo.
- Consulta del inventario completo con alerta de bajo stock (menos de 5 unidades).
- Registro de ventas con validación de stock disponible, cálculo automático de subtotal, descuento, IVA y total, y generación de ticket en pantalla.
- Reporte de caja con total de ventas, dinero acumulado, promedio por venta y producto más vendido.

## Requisitos

- .NET 8 SDK instalado (https://dotnet.microsoft.com/download/dotnet/8.0).

## Cómo clonar y ejecutar

Clona el repositorio, entra a la carpeta y ejecuta:

\`\`\`bash
git clone https://github.com/Elobar/parcialElectiva
cd parcialElectiva
dotnet run
\`\`\`

## Ejemplo de ejecución

\`\`\`
====================================================
                 REGISTRAR VENTA
====================================================
1. Café Colombiano 500g | Precio: $18.000,00 | Stock: 10
2. Pan Tajado Integral  | Precio: $6.500,00 | Stock: 3 [ALERTA: BAJO STOCK]

Seleccione el numero del producto a vender (1-2): 1
Ingrese la cantidad a comprar: 2
Aplica descuento de cliente frecuente (10%)? (S/N): S

====================================================
                  TICKET DE VENTA
====================================================
 Producto:             Café Colombiano 500g (x2)
 Subtotal:             $36.000,00
 Descuento (10%):     -$3.600,00
 IVA (19%):            +$6.156,00
 ---------------------------------------------------
 TOTAL A PAGAR:        $38.556,00
====================================================
[OK] Venta efectuada con exito. Stock actualizado: 8 unidades.
\`\`\`
