int opcion;
List<string> nombresProductos = new List<string>();
List<decimal> precioProductos = new List<decimal>();
List<int> stockProductos = new List<int>();
List<int> ventasProductos = new List<int>();
int totalVentas = 0;
decimal totalCaja = 0;

do
{
    Console.WriteLine("====================================================");
    Console.WriteLine("   SISTEMA GESTOR DE VENTAS E INVENTARIO (MINI-POS)  ");
    Console.WriteLine("====================================================");
    Console.WriteLine("1. Registrar nuevo producto en inventario");
    Console.WriteLine("2. Consultar inventario completo");
    Console.WriteLine("3. Registrar una venta");
    Console.WriteLine("4. Ver reporte de caja y estadisticas diarias");
    Console.WriteLine("5. Salir");
    Console.WriteLine("====================================================");

    opcion = LeerEntero("Seleccione una opcion (1-5): ", 1, 5);

    switch (opcion)
    {
        case 1:
            while (true)
            {
                string nombre = LeerString("Digite el nombre del producto: ");
                bool existe = false;
                foreach (string item in nombresProductos)
                {
                    if (item.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    {
                        existe = true;
                    }
                }
                if (existe)
                {
                    Console.WriteLine("El producto ya existe, no puede volver a registrarlo");
                    continue;
                }
                else
                {
                    nombresProductos.Add(nombre);
                }
                decimal precio = LeerDecimal("Digite el precio del producto: $", 0.01m);
                int stock = LeerEntero("Digite el stock disposible: ", 0, 100000000);

                precioProductos.Add(precio);
                stockProductos.Add(stock);
                ventasProductos.Add(0);
                break;
            }

            break;
        case 2:
            if (nombresProductos.Count() > 0)
            {
                imprimirDatos(nombresProductos, precioProductos, stockProductos);
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }
            break;
        case 3:
            if (nombresProductos.Count() > 0)
            {
                disposibles(nombresProductos, precioProductos, stockProductos);

                int seleccion = LeerEntero($"Seleccione el numero del producto a vender (1-{nombresProductos.Count}): ", 1, nombresProductos.Count);
                int indice = seleccion - 1;

                if (stockProductos[indice] == 0)
                {
                    Console.WriteLine("Este producto no tiene stock disponible para la venta.");
                }
                else
                {
                    int cantidad;
                    while (true)
                    {
                        cantidad = LeerEntero("Ingrese la cantidad a comprar: ", 1, 1000000000);
                        if (cantidad > stockProductos[indice])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"[ERROR] Stock insuficiente. Solo quedan {stockProductos[indice]} unidades en inventario.");
                            Console.ResetColor();
                            continue;
                        }
                        break;
                    }

                    string respuesta = LeerString("Aplica descuento de cliente frecuente (10%)? (S/N): ");
                    bool tieneDescuento = respuesta.Equals("S", StringComparison.OrdinalIgnoreCase);

                    decimal montoIva;
                    decimal montoDescuento;
                    decimal total = CalcularFactura(precioProductos[indice], cantidad, tieneDescuento, out montoIva, out montoDescuento);
                    decimal subtotal = precioProductos[indice] * cantidad;

                    stockProductos[indice] -= cantidad;
                    ventasProductos[indice] += cantidad;
                    totalVentas++;
                    totalCaja += total;

                    ImprimirEncabezado("TICKET DE VENTA");
                    Console.WriteLine($" Producto:             {nombresProductos[indice]} (x{cantidad})");
                    Console.WriteLine($" Subtotal:             {subtotal:C}");
                    Console.WriteLine($" Descuento (10%):     -{montoDescuento:C}");
                    Console.WriteLine($" IVA (19%):            +{montoIva:C}");
                    Console.WriteLine(" ---------------------------------------------------");
                    Console.WriteLine($" TOTAL A PAGAR:        {total:C}");
                    Console.WriteLine("====================================================");
                    Console.WriteLine($"[OK] Venta efectuada con exito. Stock actualizado: {stockProductos[indice]} unidades.");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }
            break;
        case 4:
            if (totalVentas > 0)
            {
                decimal promedio = totalCaja / totalVentas;
                int indiceMax = 0;
                for (int i = 1; i < ventasProductos.Count; i++)
                {
                    if (ventasProductos[i] > ventasProductos[indiceMax])
                    {
                        indiceMax = i;
                    }
                }

                ImprimirEncabezado("REPORTE DE CAJA");
                Console.WriteLine($"Total de ventas realizadas: {totalVentas}");
                Console.WriteLine($"Total acumulado en caja: {totalCaja:C}");
                Console.WriteLine($"Promedio por venta: {promedio:C}");
                Console.WriteLine($"Producto mas vendido: {nombresProductos[indiceMax]} ({ventasProductos[indiceMax]} unidades)");
            }
            else
            {
                Console.WriteLine("Aun no se han registrado ventas en esta sesion.");
            }
            break;
        case 5:
            Console.WriteLine("Saliendo del sistema...");
            break;
    }

} while (opcion != 5);

static void disposibles(List<string> nombres, List<decimal> precio, List<int> stock)
{
    ImprimirEncabezado("REGISTRAR VENTA");
    for (int i = 0; i < nombres.Count; i++)
    {
        string alerta = stock[i] < 5 ? " [ALERTA: BAJO STOCK]" : "";
        Console.Write($"{i + 1}. {nombres[i],-25} | Precio: {precio[i]:C} | Stock: {stock[i]}");
        if (alerta != "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(alerta);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static void imprimirDatos(List<string> nombres, List<decimal> precio, List<int> stock)
{
    ImprimirEncabezado("INVENTARIO");
    for (int i = 0; i < nombres.Count; i++)
    {
        string alerta = stock[i] < 5 ? " [ALERTA: BAJO STOCK]" : "";

        Console.Write($"{i + 1}. {nombres[i],-25} | Precio: {precio[i]:C} | Stock: {stock[i]}");
        if (alerta != "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(alerta);
            Console.ResetColor();
        }

        Console.WriteLine();

    }
}

static void ImprimirEncabezado(string titulo)
{
    int ancho = 52;
    int espacios = (ancho - titulo.Length) / 2;
    Console.WriteLine("====================================================");
    Console.WriteLine(new string(' ', espacios) + titulo);
    Console.WriteLine("====================================================");
}

static decimal CalcularFactura(decimal precio, int cantidad, bool tieneDescuento, out decimal montoIva, out decimal montoDescuento)
{
    decimal subtotal = precio * cantidad;
    montoDescuento = tieneDescuento ? subtotal * 0.10m : 0;
    montoIva = (subtotal - montoDescuento) * 0.19m;
    decimal total = subtotal - montoDescuento + montoIva;
    return total;
}

static string LeerString(string mensaje)
{
    string valor;
    while (true)
    {
        Console.Write(mensaje);
        valor = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(valor))
        {
            return valor;
        }
        Console.WriteLine("Este campo no puede estar vacio.");
    }
}

static int LeerEntero(string mensaje, int min, int max)
{
    int valor;
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out valor) && valor >= min && valor <= max)
        {
            return valor;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] Entrada no valida. Debe ingresar un entero entre {min} y {max}.");
        Console.ResetColor();
    }
}

static decimal LeerDecimal(string mensaje, decimal min)
{
    decimal valor;
    while (true)
    {
        Console.Write(mensaje);
        if (decimal.TryParse(Console.ReadLine(), out valor) && valor >= min)
        {
            return valor;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR] Entrada no valida. Debe ser un numero decimal mayor o igual a {min}.");
        Console.ResetColor();
    }
}