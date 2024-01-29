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

using System.Globalization;
using System.Text.RegularExpressions;

char seleccionarOpcio;
string nom = "", cognom = "", dni = "", datNaix = "", corrElec = "";
// "Jose", "Ayala", "12345678A", "2000-01-01", "jose.ayala@example.com"

string rutaArxiu = "Agenda.txt";

Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Red;

do
{
    Menu();
    seleccionarOpcio = char.ToLower(Console.ReadKey().KeyChar);

    switch (seleccionarOpcio)
    { 
        case '1':
            do
            {
                EsborrarConsola();

                Console.WriteLine("Nom: ");
                nom = Console.ReadLine();
                Console.WriteLine("Cognom: ");
                cognom = Console.ReadLine();
                Console.WriteLine("Dni: ");
                dni = Console.ReadLine();
                Console.WriteLine("Data naixement (yyyy-mm-dd): ");
                datNaix = Console.ReadLine();
                Console.WriteLine("Correu electronic: ");
                corrElec = Console.ReadLine();

            } while (!EsAlfabetic(nom) || !EsAlfabetic(cognom) || !DniValid(dni) || !DataValida(datNaix) || !CorreuValid(corrElec));

            Console.WriteLine("Tota la informacio introduida es correcta");
            CompteEnreraReduit();
            EsborrarConsola();

            AfegirArxiu(rutaArxiu, CapitaliTZAR(nom), CapitaliTZAR(cognom), dni, datNaix, corrElec);

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

    // CAPITALITZAR CARACTERS ALFABETICS
    static string CapitaliTZAR(string cadena)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(cadena.ToLower());
    }

// VERIFICAR DNI
static bool DniValid(string dni)
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

    int valorNumeric;
    if (!int.TryParse(dni.Substring(0, 8), out valorNumeric))
    {
        return false;
    }

    string lletres = "TRWAGMYFPDXBNJZSQVHLCKE";
    int resta = valorNumeric % 23;

    if (dni[8] != lletres[resta])
    {
        return false;
    }
    return true;
}

// VERIFICAR DATA
static bool DataValida(string dataTexte)
{
    if (DateTime.TryParse(dataTexte, out DateTime data))
    {
        return true;
    }
    else
    {
        return false;
    }
}

// VALIDACIO DE CORREU ELECTRONIC [REGEX]
static bool CorreuValid(string correu)
{
    string condicio = @"^[a-z\d]{3}@[a-z]{3}\.(com|es)$";
    return Regex.IsMatch(correu, condicio);
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
// TEMPS ESPERA 2
static void CompteEnreraReduit()
{
    int num = 3;
    while (num > 0)
    {
        Console.Write("\r");
        Console.Write(num);
        Thread.Sleep(1000);

        num--;
    }
}

// AFEGIR CONTINGUT A DOCUMENT .TXT
static void AfegirArxiu(string rutaArxiu, string nom, string cognom, string dni, string datNaix, string corrElec)
{
    try
    {
        string informacio = $"{nom}, {cognom}, {dni}, {datNaix}, {corrElec}";

        using (StreamWriter writer = File.AppendText(rutaArxiu))
        {
            writer.WriteLine(informacio);
        }

        Console.WriteLine("S'ha afegit la informació a l'arxiu correctament.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"S'ha produït un error al afegir la informació a l'arxiu: {ex.Message}");
    }
}


// TROBAR INFORMACIO A L'ARXIU
static void Trobar(string rutaArxiu, string valorABuscar)
{
    try
    {
        string[] linies = File.ReadAllLines(rutaArxiu);

        foreach (string linia in linies)
        {
            if (linia.Contains(valorABuscar))
            {
                Console.WriteLine($"S'ha trobat la seguent informació '{valorABuscar}':");
                Console.WriteLine(linia);
                return;
            }
        }

        Console.WriteLine($"No s'ha trobat cap coincidencia'{valorABuscar}'.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al buscar la informacio a l'axiu: {ex.Message}");
    }
}