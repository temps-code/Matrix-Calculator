/* Grupo A5-B
Participaron en el desarrollo del proyecto:
Damaris Jenifer Ruth Mamani
Diego Vargas Urzagaste
Jhonny Acuña Quiñones
Ray Gregorick Copa Cayo
Saul Caceres Vargas
*/
using System.Collections;
using System.Threading;

// Declaración e inicialización de variables
int filas = 0, columnas = 0, contador = 0;
string opcion, respuesta;
bool aux = false, RomperCiclo = false, iniciar = true;

// Declaración de las matrices
int[,] matrizA = new int[filas, columnas];
int[,] matrizB = new int[filas, columnas];
int[,] matrizC = new int[filas, columnas];

// Hashtable para el menú de opciones
Hashtable Menu = new Hashtable()
{
    { "S", "Suma de matrices" },
    { "R", "Resta de matrices" },
    { "M", "Multiplicación de matrices" },
    { "D", "Determinante de una matriz" },
    { "X", "Salir" }
};
//Mensaje de introduccion al programa
Console.ForegroundColor = ConsoleColor.Cyan;
System.Console.WriteLine("\tProyecto de curso\n\n\tProgranacion 2\n\n\tUniversidad Privada Domingo Savio.\n\n\tDocente Ing. Alvaro Rodrigo Antezana Meza\n\nGrupo A5-B\nIntegrantes:\n\n>Damaris Jenifer Ruth Mamani\n>Diego Vargas Urzagaste\n>Jhonny Acuña Quiñones\n>Ray Gregorick Copa Cayo\n>Saul Caceres Vargas");
Console.ForegroundColor = ConsoleColor.Green;
System.Console.WriteLine("No presione ninguna tecla, esta pantalla cambiara automaticamente");
Thread.Sleep(10000);
Console.Clear();
Console.ForegroundColor = ConsoleColor.Red;
System.Console.WriteLine("Este proyecto debe ser ejecutado en modo Administrador, ya que guarda documentos en el disco C, por lo cual se necesita permiso de administrador para este proceso");
Console.ForegroundColor = ConsoleColor.Green;
System.Console.Write("Ingrese S/s si inicio el programa en modo administrador, en caso contrario ingrese cualquier otra para salir del programa: ");
respuesta = Console.ReadLine().ToUpper();
if (respuesta != "S") iniciar = false;
Console.ResetColor();
Console.Clear();
// Programa principal
while (iniciar)
{
    while (true)
    {
        // Mostrar el menú de opciones
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine("=================== Menú ===================");
        foreach (DictionaryEntry i in Menu)
            System.Console.WriteLine($"({i.Key}) {i.Value}");
        System.Console.Write("============================================\nIngrese una de las opciones que se encuentra dentro de los paréntesis: ");
        opcion = Console.ReadLine().ToUpper();

        // Verificar si la opción ingresada es válida
        if (Menu.ContainsKey(opcion))
            break;
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\"{opcion}\" no existe, ingrese una opción válida...");
        }
    }
    Console.Clear();
    // Realizar acciones según la opción seleccionada
    switch (opcion)
    {
        case "S":
            // Opción de suma de matrices
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("=========================== Suma de matrices ===========================");
            Console.ResetColor();
            filas = ValidarN("filas de ambas matrices");
            columnas = ValidarN("columnas de ambas matrices");
            matrizA = AsignacionValores("A", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            matrizB = AsignacionValores("B", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            matrizC = SumarRestar(matrizA, matrizB, "sumar");
            MostrarMatriz(matrizA, "A");
            MostrarMatriz(matrizB, "B");
            MostrarMatriz(matrizC, "C, resultante de la suma de ambas matrices");
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("¿Desea guardar las 3 matrices en un documento de tipo texto?\nIngrese S/s para confirmar, cualquier tecla para omitir: ");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                GuardarMatriz(matrizA, "A", ref contador);
                GuardarMatriz(matrizB, "B", ref contador);
                GuardarMatriz(matrizC, "C", ref contador);
            }
            Console.ResetColor();
            break;
        case "R":
            // Opción de resta de matrices
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("=========================== Resta de matrices ==========================");
            Console.ResetColor();
            filas = ValidarN("filas de ambas matrices");
            columnas = ValidarN("columnas de ambas matrices");
            matrizA = AsignacionValores("A", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            matrizB = AsignacionValores("B", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            matrizC = SumarRestar(matrizA, matrizB, "restar");
            MostrarMatriz(matrizA, "A");
            MostrarMatriz(matrizB, "B");
            MostrarMatriz(matrizC, "C, resultante de la resta de ambas matrices");
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("¿Desea guardar las 3 matrices en un documento de tipo texto?\nIngrese S/s para confirmar, cualquier tecla para omitir: ");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                GuardarMatriz(matrizA, "A", ref contador);
                GuardarMatriz(matrizB, "B", ref contador);
                GuardarMatriz(matrizC, "C", ref contador);
            }
            Console.ResetColor();
            break;
        case "M":
            // Opción de multiplicación de matrices
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("====================== Multiplicación de matrices ======================");
            Console.ResetColor();
            filas = ValidarN("filas para la matriz A");
            columnas = ValidarN("columnas para la matriz A");
            matrizA = AsignacionValores("A", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Recuerde que el número de columnas de la matriz A debe ser igual al número de filas de la matriz B para poder realizar la multiplicación de matrices, por lo tanto se le asignará automáticamente este valor");
            Console.ResetColor();
            filas = columnas;
            columnas = ValidarN("columnas para la matriz B");
            matrizB = AsignacionValores("B", filas, columnas, ref RomperCiclo);
            if (RomperCiclo) break;
            matrizC = MultiplicarMatrices(matrizA, matrizB);
            MostrarMatriz(matrizA, "A");
            MostrarMatriz(matrizB, "B");
            MostrarMatriz(matrizC, "C, resultante del producto de ambas matrices");
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("¿Desea guardar las 3 matrices en un documento de tipo texto?\nIngrese S/s para confirmar, cualquier tecla para omitir: ");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                GuardarMatriz(matrizA, "A", ref contador);
                GuardarMatriz(matrizB, "B", ref contador);
                GuardarMatriz(matrizC, "C", ref contador);
            }
            Console.ResetColor();
            break;
        case "D":
            // Opción de cálculo del determinante de una matriz
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("====================== Determinante de una matriz ======================");
            Console.ResetColor();
            filas = ValidarN("filas y columnas para la matriz");
            matrizA = AsignacionValores("", filas, filas, ref RomperCiclo);
            if (RomperCiclo) break;
            Determinante(matrizA);
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.Write("¿Desea guardar la matriz en un documento de tipo texto?\nIngrese S/s para confirmar, cualquier tecla para omitir: ");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                GuardarMatriz(matrizA, "", ref contador);
            }
            Console.ResetColor();
            break;
        default:
            // Opción de salir del programa
            Console.Clear();
            aux = true;
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("¡Hasta luego!");
            Console.ResetColor();
            Thread.Sleep(1000);
            break;
    }

    if (aux)
        break;
    else
    {
        Thread.Sleep(2000);
        Console.Clear();
    }
}

// Función para validar la opción de filas o columnas
static int ValidarN(string mensaje)
{
    int N;
    while (true)
    {
        try
        {
            // Solicita al usuario un valor numérico mayor que 1
            Console.Write($"Ingrese un valor numérico mayor que 1 para las {mensaje}: ");
            // Lee la entrada del usuario y la convierte en un valor entero
            N = int.Parse(Console.ReadLine());
            // Verifica si el valor es mayor que 1
            if (N > 1)
                break; // Salir del bucle si se cumple la condición
        }
        catch
        {
            // Captura una excepción en caso de que se ingrese un valor no numérico
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar un número válido...");
            Console.ResetColor();
        }
    }
    // Retornar el valor validado
    return N;
}

// Función para validar el rango inicial y final
static int ValidarRangos(string mensaje, int inicial)
{
    int N;
    while (true)
    {
        try
        {
            // Verifica si el mensaje es para el rango final
            if (mensaje == "rango final")
            {
                // Muestra un mensaje recordándote que el valor del rango final debe ser mayor que el rango inicial
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Recuerda que el valor del rango final debe ser mayor que el rango inicial.");
                Console.ResetColor();
                // Solicita al usuario un valor para el rango final
                Console.Write($"Ingresa un valor para el {mensaje}: ");
                // Lee la entrada del usuario y la convierte en un valor entero
                N = int.Parse(Console.ReadLine());
                // Verifica si el valor del rango final es mayor que el rango inicial
                if (N > inicial)
                    break; // Sal del bucle si se cumple la condición
            }
            else
            {
                // Solicita al usuario un valor para el rango inicial u otro mensaje
                Console.Write($"Ingresa un valor para el {mensaje}: ");
                // Lee la entrada del usuario y la convierte en un valor entero
                N = int.Parse(Console.ReadLine());
                // Sale del bucle
                break;
            }
        }
        catch
        {
            // Captura una excepción en caso de que se ingrese un valor no numérico
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debes ingresar un número válido...");
            Console.ResetColor();
        }
    }
    // Retorna el valor validado
    return N;
}

// Función para elegir el método de entrada de datos para la matriz y asignar los valores para dicha matriz
static int[,] AsignacionValores(string mensaje, int filas, int columnas, ref bool RomperCiclo)
{
    int[,] matriz = new int[columnas, filas];
    RomperCiclo = false;
    bool Loop = true;
    // Hashtable para almacenar las opciones del menú de entrada de datos
    Hashtable SubMenu = new Hashtable()
    {
        { "A", "Aleatorio (rango de valores)" },
        { "M", "Manualmente (usuario)" },
        { "D", "Desde un archivo texto (separado por un carácter específico)" },
        { "V", "Volver al menú principal" }
    };
    string opcion;
    while (Loop)
    {
        while (true)
        {
            // Muestra el encabezado y las opciones del menú
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"---------------- Ingresar los valores para la matriz {mensaje} ------------------");
            foreach (DictionaryEntry i in SubMenu)
                Console.WriteLine($"{i.Key}) {i.Value}");
            Console.Write("------------------------------------------------------------------------\nIngresa una opción: ");
            // Lee la opción ingresada por el usuario
            opcion = Console.ReadLine().ToUpper();
            // Verifica si la opción ingresada es válida
            if (SubMenu.ContainsKey(opcion))
                break; // Sale del bucle si la opción es válida
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\"{opcion}\" no existe, ingresa una opción válida...");
                Console.ResetColor();
            }
        }
        Console.ResetColor();
        // Procesa la opción seleccionada
        switch (opcion)
        {
            case "A":
                int rangoInicial, rangoFinal;
                // Solicita al usuario los rangos inicial y final
                rangoInicial = ValidarRangos("rango inicial", 0);
                rangoFinal = ValidarRangos("rango final", rangoInicial);
                // Genera la matriz con valores aleatorios dentro del rango especificado
                matriz = GenerarMatriz(filas, columnas, rangoInicial, rangoFinal);
                Loop = false;
                break;
            case "M":
                // Asigna los valores de la matriz manualmente por ti
                matriz = AsignarValoresMatriz(filas, columnas);
                Loop = false;
                break;
            case "D":
                // Lee la matriz desde un archivo de texto
                matriz = Documento(matriz, ref Loop);
                break;
            default:
                RomperCiclo = true; // Indica que se debe romper el ciclo y volver al menú principal
                Loop = false;
                break;
        }
    }
    // Retorna la matriz asignada
    return matriz;
}

// Función para generar los valores de una matriz
static int[,] GenerarMatriz(int filas, int columnas, int rangoInicial, int rangoFinal)
{
    int[,] matriz = new int[filas, columnas];
    Random azar = new Random();
    // Itera sobre las filas de la matriz
    for (int f = 0; f < matriz.GetLength(0); f++)
    {
        // Itera sobre las columnas de la matriz
        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            // Genera un valor aleatorio dentro del rango especificado y lo asigna a la posición correspondiente en la matriz
            matriz[f, c] = azar.Next(rangoInicial, rangoFinal);
        }
    }
    // Retorna la matriz generada
    return matriz;
}

// Función para asignar manualmente los valores de una matriz
static int[,] AsignarValoresMatriz(int filas, int columnas)
{
    int[,] matriz = new int[filas, columnas];
    System.Console.WriteLine("Ingresa los valores para la matriz. Solo se aceptan valores numéricos.");
    // Itera sobre las filas de la matriz
    for (int f = 0; f < matriz.GetLength(0); f++)
    {
        // Itera sobre las columnas de la matriz
        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            while (true)
            {
                try
                {
                    // Solicita que ingreses el valor para el elemento de la matriz
                    System.Console.Write($"Elemento [{f + 1},{c + 1}]: ");
                    matriz[f, c] = int.Parse(Console.ReadLine());
                    break; // Sale del bucle si ingresaste un valor numérico correctamente
                }
                catch
                {
                    // Captura una excepción en caso de que ingreses un valor no numérico
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Debes ingresar un número válido...");
                    Console.ResetColor();
                }
            }
        }
    }
    // Retorna la matriz con los valores asignados por el usuario
    return matriz;
}

// Función para asignar los valores de una matriz mediante un documento de texto
static int[,] Documento(int[,] matriz, ref bool romper)
{
    // Variable para controlar si se debe romper el bucle principal
    romper = false;
    bool seguir = true;
    while (seguir)
    {
        System.Console.Write("Ingresa la ruta del archivo: ");
        string rutaArchivo = Console.ReadLine();
        string separador, respuesta;
        // Verifica si el archivo existe
        if (File.Exists(rutaArchivo))
        {
            // Lee el archivo y obtiene las líneas de texto
            StreamReader archivo = new StreamReader(rutaArchivo);
            string[] lineas = File.ReadAllLines(rutaArchivo);
            // Obtiene el separador para los elementos de la matriz
            separador = Separador(lineas);
            // Verifica si la dimensión de la matriz en el documento coincide con la esperada
            if (lineas.Length != matriz.GetLength(0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("La dimensión de la matriz que se encuentra dentro del documento no coincide con la dimensión esperada.");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write("¿Deseas volver a ingresar una ruta?\nIngresa S/s para confirmar, cualquier tecla para salir de esta opción y regresar al menú de selección: ");
                respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    seguir = false;
                    romper = true;
                }
                System.Console.WriteLine("------------------------------------------------------------------------");
                Console.ResetColor();
                continue;
            }
            string[] valores;
            // Itera sobre las filas de la matriz en el documento
            for (int f = 0; f < matriz.GetLength(0); f++)
            {
                valores = lineas[f].Split(separador);
                // Verifica si la dimensión de la fila en el documento coincide con la esperada
                if (valores.Length != matriz.GetLength(1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("La dimensión de la matriz que se encuentra dentro del documento no coincide con la dimensión esperada.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write("¿Deseas volver a ingresar una ruta?\nIngresa S/s para confirmar, cualquier tecla para salir de esta opción y regresar al menú de selección: ");
                    respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S")
                    {
                        seguir = false;
                        romper = true;
                    }
                    System.Console.WriteLine("------------------------------------------------------------------------");
                    Console.ResetColor();
                    continue;
                }
                // Asigna los valores de la fila a la matriz
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    while (seguir)
                    {
                        try
                        {
                            matriz[f, c] = int.Parse(valores[c]);
                            break; // Sale del bucle si el elemento se puede convertir correctamente a int
                        }
                        catch
                        {
                            // Captura una excepción en caso de que el elemento no sea un valor numérico
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Se encontró un elemento inválido dentro de la matriz, por lo tanto no es válida.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.Write("¿Deseas volver a ingresar una ruta?\nIngresa S/s para confirmar, cualquier tecla para salir de esta opción y regresar al menú de selección: ");
                            respuesta = Console.ReadLine().ToUpper();
                            if (respuesta != "S")
                            {
                                seguir = false;
                                romper = true;
                            }
                            System.Console.WriteLine("------------------------------------------------------------------------");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
            }
            archivo.Close();
            break; // Sale del bucle si todos los valores se asignaron correctamente
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"La ruta \"{rutaArchivo}\" es incorrecta o el archivo no existe.");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("¿Deseas volver a ingresar una ruta?\nIngresa S/s para confirmar, cualquier tecla para salir de esta opción y regresar al menú de selección: ");
            respuesta = Console.ReadLine().ToUpper();
            if (respuesta != "S")
            {
                seguir = false;
                romper = true;
            }
            System.Console.WriteLine("------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
    // Retorna la matriz con los valores asignados desde el documento
    return matriz;
}

// Función para validar un separador
static string Separador(string[] vector)
{
    // Definición de los símbolos permitidos como separadores
    string simbolos = @": ; \ | ";
    // Variable para almacenar el separador seleccionado
    string caracter;
    // Variable auxiliar para controlar el bucle
    bool aux = false;
    while (true)
    {
        System.Console.Write("Ingresa el separador de los elementos de la matriz (debe ser un carácter dentro de estas opciones \": ; \\ | \"): ");
        caracter = Console.ReadLine();
        // Verifica si el separador tiene una longitud de 1 y si es uno de los símbolos permitidos
        if (caracter.Length == 1 && simbolos.Contains(caracter))
        {
            // Verifica si todas las líneas del vector contienen el separador seleccionado
            foreach (string item in vector)
            {
                if (!item.Contains(caracter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("El archivo no contiene el separador seleccionado.");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    aux = true;
                    break;
                }
            }
            // Si todas las líneas contienen el separador, se sale del bucle
            if (aux) break;
        }
    }
    // Retorna el separador seleccionado
    return caracter;
}

// Función para guardar una matriz en un archivo de texto
static void GuardarMatriz(int[,] matriz, string mensaje, ref int contador)
{
    contador++;
    Console.ForegroundColor = ConsoleColor.Cyan;
    // Ruta del archivo de texto
    string ruta = @"C:\matriz" + contador + ".txt";
    // Definición de los símbolos permitidos como separadores
    string simbolos = @": ; \ | ";
    string caracter;
    while (true)
    {
        System.Console.Write($"Ingresa un separador para los elementos de la matriz{mensaje} (debe ser un carácter dentro de estas opciones \": ; \\ | \"): ");
        caracter = Console.ReadLine();
        // Verifica si el separador tiene una longitud de 1 y si es uno de los símbolos permitidos
        if (caracter.Length == 1 && simbolos.Contains(caracter))
        {
            break;
        }
    }
    // Crea o sobrescribe el archivo de texto
    File.WriteAllText(ruta, string.Empty);
    // Itera sobre las filas de la matriz
    for (int f = 0; f < matriz.GetLength(0); f++)
    {
        string fila = string.Empty;
        // Itera sobre las columnas de la matriz
        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            fila += matriz[f, c] + caracter;
        }
        fila = fila.Remove(fila.Length - 1, 1);
        // Agrega la fila al archivo de texto
        File.AppendAllText(ruta, fila + Environment.NewLine);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine($"La matriz{mensaje} se guardó en la ruta: {ruta}\n");
    Console.ResetColor();
}

// Módulo para mostrar la matriz
static void MostrarMatriz(int[,] matriz, string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    // Muestra el tamaño de la matriz y el mensaje especificado
    Console.WriteLine($"Matriz {matriz.GetLength(0)}x{matriz.GetLength(1)} {mensaje}");
    Console.ForegroundColor = ConsoleColor.Cyan;
    // Itera sobre las filas de la matriz
    for (int f = 0; f < matriz.GetLength(0); f++)
    {
        // Itera sobre las columnas de la matriz
        for (int c = 0; c < matriz.GetLength(1); c++)
        {
            // Muestra el elemento de la matriz seguido de una tabulación
            Console.Write(matriz[f, c] + "\t");
        }
        // Salta a una nueva línea después de mostrar todos los elementos de una fila
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.ResetColor();
}

// Función para calcular la suma o la resta de dos matrices
static int[,] SumarRestar(int[,] matrizA, int[,] matrizB, string mensaje)
{
    // Crea una nueva matriz para almacenar el resultado de la operación
    int[,] matrizC = new int[matrizA.GetLength(0), matrizB.GetLength(1)];

    // Itera sobre las filas de las matrices
    for (int f = 0; f < matrizA.GetLength(0); f++)
    {
        // Itera sobre las columnas de las matrices
        for (int c = 0; c < matrizB.GetLength(1); c++)
        {
            // Verifica el mensaje para determinar si se realiza una suma o una resta
            if (mensaje == "sumar")
                matrizC[f, c] = matrizA[f, c] + matrizB[f, c];
            else
                matrizC[f, c] = matrizA[f, c] - matrizB[f, c];
        }
    }

    // Retorna la matriz resultante
    return matrizC;
}

// Función para calcular el producto de dos matrices
static int[,] MultiplicarMatrices(int[,] matrizA, int[,] matrizB)
{
    // Crea una nueva matriz para almacenar el resultado del producto
    int[,] matrizC = new int[matrizA.GetLength(0), matrizB.GetLength(1)];
    // Itera sobre las filas de la matriz A
    for (int f = 0; f < matrizA.GetLength(0); f++)
    {
        // Itera sobre las columnas de la matriz B
        for (int c = 0; c < matrizB.GetLength(1); c++)
        {
            // Variable para almacenar la suma de los productos de los elementos
            int suma = 0;
            // Itera sobre las columnas de la matriz A o las filas de la matriz B
            for (int i = 0; i < matrizA.GetLength(1); i++)
            {
                // Calcula la suma acumulada de los productos de los elementos correspondientes
                suma += matrizA[f, i] * matrizB[i, c];
            }
            // Asigna el resultado de la suma a la posición correspondiente en la matriz C
            matrizC[f, c] = suma;
        }
    }
    // Retorna la matriz resultante del producto
    return matrizC;
}

// Función para calcular la determinante de una matriz
static void Determinante(int[,] matriz)
{
    int N = matriz.GetLength(0); // Obtener la dimensión de la matriz (número de filas)
    double[,] matrizAux = new double[N, N]; // Crear una matriz auxiliar para realizar los cálculos
    // Copiar los elementos de la matriz original a la matriz auxiliar
    for (int f = 0; f < matriz.GetLength(0); f++)
    {
        for (int c = 0; c < matriz.GetLength(0); c++)
        {
            matrizAux[f, c] = (double)matriz[f, c];
        }
    }
    double determinante = 1;
    // Eliminación de Gauss-Jordan por filas
    for (int k = 0; k < N - 1; k++)
    {
        for (int i = k + 1; i < N; i++)
        {
            double multiplicador = matrizAux[i, k] / matrizAux[k, k];
            // Actualizar los elementos de la fila i de la matriz auxiliar
            // restando el multiplicador multiplicado por los elementos de la fila k
            for (int j = k + 1; j < N; j++)
            {
                matrizAux[i, j] -= multiplicador * matrizAux[k, j];
            }
        }
    }
    // Cálculo del determinante multiplicando los elementos diagonales de la matriz auxiliar
    for (int i = 0; i < N; i++)
    {
        determinante *= matrizAux[i, i];
    }
    MostrarMatriz(matriz, ""); // Muestra la matriz original
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"El determinante de la matriz es: {determinante}\n");
    Console.ResetColor();
}
