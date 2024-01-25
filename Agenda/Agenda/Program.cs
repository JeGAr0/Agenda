// Demanar nom, cognom, DNI, data naixement i correu electronic
// nom, cognom, dni, datnai, correlec

// nom i cognom primera lletra majuscula
// Filtrar nom perque nomes apareguin valors alfabetics
// Ha de validar el DNI
// El telefon ha de tenir 9 numeros i cap valor alfabetic
// Data naixement valida i emmagatzemada com a datetime
// Correu, conjunt de 3 lletres/numeros o mes (tot en minuscula) +@ +domini (3 o mes lletres) .com/es [regex]

// tornar a demanar valor incorrectes
// verificat que es correcte mostrar les dades 3 segons
// Mostrar al costat de la datnaixement l'edat, calculat per metode

// Nom fitxer [ agenda.txt ]

char seleccionarOpcio;
string nom = "", cognom = "", dni = "", datNaix = "", corrElec = "";
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Red;

do
{
    Menu();
    seleccionarOpcio = char.ToLower(Console.ReadKey().KeyChar);

    switch (seleccionarOpcio)
    { 
        case '1':
            EsborrarConsola();
            do
            {
                if (!EsAlfabetic(nom) || !EsAlfabetic(cognom) || !dniValid(dni))
                {
                    Console.WriteLine("Algun dels valors introduits son erronis");
                }
                EsborrarConsola();
                Console.WriteLine("Nom: ");
                nom = Console.ReadLine();

                Console.WriteLine("Cognom: ");
                cognom = Console.ReadLine();

                Console.WriteLine("Dni: ");
                dni = Console.ReadLine();

                Console.WriteLine("Data naixement (dd/MM/yyyy): ");
                datNaix = Console.ReadLine();

                Console.WriteLine("Correu electronic: ");
                corrElec = Console.ReadLine();



            } while (!EsAlfabetic(nom) && !EsAlfabetic(cognom));

            CompteEnrera();
            break;
        case '2':
            EsborrarConsola();
            break;
        case '3':
            EsborrarConsola();
            break;
        case '4':
            EsborrarConsola();
            break;
        case '5':
            EsborrarConsola();
            break;
        case '6':
            EsborrarConsola();
            break;
    }
    EsborrarConsola();
} while (seleccionarOpcio >= '1' && seleccionarOpcio < '5' || seleccionarOpcio == 'Q' || seleccionarOpcio == 'q') ;


// MENU PRINCIPAL
static void Menu()
{

    Console.Write(Centrar(DateTime.Now.ToString("ddd dd MMM")));

    Console.WriteLine(Centrar("                                           "));
    Console.WriteLine(Centrar("                                           "));
    Console.WriteLine(Centrar("                ▄▀▄     ▄▀▄                "));
    Console.WriteLine(Centrar("               ▄█░░▀▀▀▀▀░░█▄               "));
    Console.WriteLine(Centrar("           ▄▄  █░░░░░░░░░░░█  ▄▄           "));
    Console.WriteLine(Centrar("          █▄▄█ █░░▀░░┬░░▀░░█ █▄▄█          "));


    Console.WriteLine(Centrar(" ---------- Selecciona una opcio --------- "));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|            1. AFEGIR                    |"));
    Console.WriteLine(Centrar("|            2. VISUALITZAR               |"));
    Console.WriteLine(Centrar("|            3. MODIFICAR                 |"));
    Console.WriteLine(Centrar("|            4. ELIMINAR                  |"));
    Console.WriteLine(Centrar("|            5. MOSTRAR AGENDA            |"));
    Console.WriteLine(Centrar("|            6. ORDENAR AGENDA            |"));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|            Q. SORTIR                    |"));
    Console.WriteLine(Centrar("|-----------------------------------------|"));

}

// SUBMENUS

    // AFEGIR
static void afegir()
{


}
static void Submenu1()
{
    Console.WriteLine(Centrar(" -------------- AFEGIR ------------------- "));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|            1. AFEGIR                    |"));
    Console.WriteLine(Centrar("|            2. VISUALITZAR               |"));
    Console.WriteLine(Centrar("|            3. MODIFICAR                 |"));
    Console.WriteLine(Centrar("|            4. ELIMINAR                  |"));
    Console.WriteLine(Centrar("|            5. MOSTRAR AGENDA            |"));
    Console.WriteLine(Centrar("|                                         |"));
    Console.WriteLine(Centrar("|-----------------------------------------|"));
}

// VERIFICAR CARACTERS ALFABETICS
static bool EsAlfabetic(string cadena)
{
    foreach (char caracter in cadena)
    {
        if (!char.IsLetter(caracter))
        {
            return false;
        }
    }
    return true;
}

// VERIFICAR DNI
static bool dniValid(string dni)
{
    if (dni.Length != 9)
    {
        return false;
    }

    for (int i = 0; i < 8; i++)
    {
        if (!char.IsDigit(dni[i]))
        {
            return false;
        }
    }

    if (!char.IsLetter(dni[8]))
    {
        return false;
    }

    int valorNumerico;
    if (!int.TryParse(dni.Substring(0, 8), out valorNumerico))
    {
        return false;
    }

    string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
    int resto = valorNumerico % 23;

    if (dni[8] != letras[resto])
    {
        return false;
    }
    return true;
}

// VERIFICAR DATA
static bool dataValida(string datNaix, out DateTime data)
{
    if (DateTime.TryParseExact(datNaix, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
    {
        return true;
    }
    else
    {
        return false;
    }
}

// ESBORRAR CONSOLA
static void EsborrarConsola()
{
    Console.Clear();
}

// CENTRAR
static string Centrar(string valor)
{
    int longitud = (valor.Length + 80) / 2;
    string cadenaAmbEspais = valor.PadLeft(longitud);
    return cadenaAmbEspais;
}

// TEMPS ESPERA
static void CompteEnrera()
{
    int num = 5;
    while (num > 0)
    {
        Console.Write("\r");
        Console.Write(num);
        Thread.Sleep(1000);

        num--;
    }
}
